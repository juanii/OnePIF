using KeePassLib;
using KeePassLib.Security;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace OnePIF.Records
{
#pragma warning disable IDE1006
    [JsonConverter(typeof(SectionFieldConverter))]
    public class SectionField
    {
        public string n { get; set; }

        public string t { get; set; }

        [JsonConverter(typeof(EnumConverter<SectionFieldType>))]
        public SectionFieldType k { get; set; }

        public SectionFieldAttributes a { get; set; }
    }

    public class SectionFieldAttributes
    {
        [JsonConverter(typeof(FlexibleBooleanConverter))]
        public bool guarded { get; set; }

        [JsonConverter(typeof(FlexibleBooleanConverter))]
        public bool multiline { get; set; }

        [JsonConverter(typeof(FlexibleBooleanConverter))]
        public bool generate { get; set; }

        public string clipboardFilter { get; set; }
    }

    public class GeneralSectionField : SectionField
    {
        public string v { get; set; }
    }

    public class DateSectionField : SectionField
    {
        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime v { get; set; }
    }

    public class MonthYearSectionField : SectionField
    {
        [JsonConverter(typeof(MonthYearConverter))]
        public DateTime v { get; set; }
    }

    public class AddressValue
    {
        public string street { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        public string region { get; set; }
    }

    public class AddressSectionField : SectionField
    {
        public AddressValue v { get; set; }
    }

    public class SecureContentsSection
    {
        public string name { get; set; }

        public string title { get; set; }

        public IList<SectionField> fields { get; set; }
    }
#pragma warning restore IDE1006

    //identities.Identity
    //wallet.government.DriversLicense
    //wallet.government.HuntingLicense
    //wallet.government.Passport
    //wallet.computer.License
    public class ItemSecureContents : SecureContents
    {
#pragma warning disable IDE1006
        public string notesPlain { get; set; }

        public IList<SecureContentsSection> sections { get; set; }

        public byte[] customIcon { get; set; }
#pragma warning restore IDE1006

        public PwCustomIcon PwCustomIcon { get; private set; }

        private static readonly string LINKED_ITEMS_SECTION_NAME = "linked items";

        private static readonly Regex USER_SECTION_NAME = new Regex("^Section_[0-9A-F]{32}$", RegexOptions.Compiled);

        private static readonly Regex OTP_FIELD_NAME = new Regex("^TOTP_[0-9A-F]{32}$", RegexOptions.Compiled);

        private static readonly string OTP_DEFAULT_PERIOD = "30";

        private static readonly string OTP_DEFAULT_DIGITS = "6";

        protected class SectionFieldLocator
        {
            public string SectionName { get; private set; }

            public string FieldName { get; private set; }

            public SectionFieldLocator(string sectionName, string fieldName)
            {
                this.SectionName = sectionName;
                this.FieldName = fieldName;
            }

            public bool Equals(string sectionName, string fieldName)
            {
                return this.SectionName.Equals(sectionName) && this.FieldName.Equals(fieldName);
            }
        }

        protected virtual SectionFieldLocator GetUsernameFieldLocator() { return null; }

        protected virtual SectionFieldLocator GetPasswordFieldLocator() { return null; }

        protected virtual SectionFieldLocator GetURLFieldLocator() { return null; }

        private void setOTPField(PwEntry pwEntry, bool protectSecret, GeneralSectionField sectionField, OTPFormat otpFormat)
        {
            if (otpFormat == OTPFormat.KeeWeb)
            {
                // KeeWeb uses the otpauth URI, same as 1Password
                pwEntry.Strings.Set("otp", new ProtectedString(protectSecret, sectionField.v));
            }
            else
            {
                // Decompose otpauth URI
                if (!Uri.IsWellFormedUriString(sectionField.v, UriKind.RelativeOrAbsolute))
                    return;

                Uri totpUri = new Uri(sectionField.v);
                string queryString = totpUri.Query;
                Dictionary<string, string> totpParams = UriExt.GetParams(queryString);

                string secret = null, period = null, digits = null;

                // If we have no secret, it's not worth setting the OTP field
                if (!totpParams.TryGetValue("secret", out secret))
                    return;

                totpParams.TryGetValue("period", out period);
                totpParams.TryGetValue("digits", out digits);

                if (otpFormat == OTPFormat.KeeOtp)
                {
                    StringBuilder keeOtpString = new StringBuilder();
                    keeOtpString.AppendFormat("key={0}", secret);

                    if (!string.IsNullOrEmpty(period))
                        keeOtpString.AppendFormat("&step={0}", period);
                    if (!string.IsNullOrEmpty(digits))
                        keeOtpString.AppendFormat("&size={0}", digits);

                    pwEntry.Strings.Set("otp", new ProtectedString(protectSecret, keeOtpString.ToString()));
                }
                else if (otpFormat == OTPFormat.TrayTOTP)
                {
                    pwEntry.Strings.Set("TOTP Seed", new ProtectedString(protectSecret, secret));
                    // Some Kee* implementations don't show the OTP unless these optional values are set
                    pwEntry.Strings.Set("TOTP Settings", new ProtectedString(false, string.Join(";", new string[] { period ?? OTP_DEFAULT_PERIOD, digits ?? OTP_DEFAULT_DIGITS })));
                }
            }
        }

        private List<string> getTokenizedAddressComponents(string addressFormatString, AddressSectionField addressSectionField)
        {
            string[] tokens = addressFormatString.Split(new char[] { '|' });
            List<string> components = new List<string>();

            foreach (string token in tokens)
            {
                string[] subtokens = token.Split(new char[] { ' ' });
                List<string> subcomponents = new List<string>();

                foreach (string subtoken in subtokens)
                {
                    PropertyInfo propertyInfo = addressSectionField.v.GetType().GetProperty(subtoken);
                    if (propertyInfo != null)
                    {
                        string tokenValue = propertyInfo.GetValue(addressSectionField.v, null) as string;

                        if (string.IsNullOrEmpty(tokenValue))
                            continue;

                        // Find the localized country name
                        if (subtoken.Equals("country"))
                        {
                            // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
                            tokenValue = Properties.Strings.ResourceManager.GetString(string.Join("_", new string[] { "Menu", "country", tokenValue.Replace('-', '_') }));

                            // If no localized country name is found, use the ISO country code
                            if (string.IsNullOrEmpty(tokenValue))
                                tokenValue = tokenValue.ToUpper().Replace('_', ' ');
                        }
                        else if (subtoken.Equals("street"))
                        {
                            // Older format had two address lines, which may be joined with a new line
                            tokenValue = StringExt.ReplaceNewLines(tokenValue, " ");
                        }

                        subcomponents.Add(tokenValue);
                    }
                }

                if (subcomponents.Count > 0)
                    components.Add(string.Join(" ", subcomponents.ToArray()));
            }

            return components;
        }

        private void setCompactAddressField(PwEntry pwEntry, string sectionTitle, AddressSectionField addressSectionField)
        {
            string addressLocale = addressSectionField.v.country;

            if (string.IsNullOrEmpty(addressLocale))
                addressLocale = "us";

            // Find the address format used in the country where this address is located
            // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
            string addressFormatString = Properties.CompactAddressFormat.ResourceManager.GetString(string.Join("_", new string[] { "Country", addressLocale.Replace('-', '_') }));

            // If we couldn't find a specific format for the country, use a generic one
            if (string.IsNullOrEmpty(addressFormatString))
                addressFormatString = Properties.CompactAddressFormat.Country_us;

            List<string> components = this.getTokenizedAddressComponents(addressFormatString, addressSectionField);

            if (components.Count > 0)
            {
                string fieldValue = string.Join(", ", components.ToArray());
                string fieldLabel = addressSectionField.t;

                // If the field is in a named section, prefix its name to avoid collisions
                if (!string.IsNullOrEmpty(sectionTitle))
                    fieldLabel = string.Concat(sectionTitle, " - ", addressSectionField.t);

                pwEntry.Strings.Set(fieldLabel, new ProtectedString(false, fieldValue));
            }
        }

        private void setMultilineAddressField(PwEntry pwEntry, string sectionTitle, AddressSectionField addressSectionField)
        {
            string addressLocale = addressSectionField.v.country;

            if (string.IsNullOrEmpty(addressLocale))
                addressLocale = "us";

            // Find the address format used in the country where this address is located
            // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
            string addressFormatString = Properties.MultilineAddressFormat.ResourceManager.GetString(string.Join("_", new string[] { "Country", addressLocale.Replace('-', '_') }));

            // If we couldn't find a specific format for the country, use a generic one
            if (string.IsNullOrEmpty(addressFormatString))
                addressFormatString = Properties.MultilineAddressFormat.Country_us;

            List<string> components = this.getTokenizedAddressComponents(addressFormatString, addressSectionField);

            if (components.Count > 0)
            {
                string fieldValue = string.Join(Environment.NewLine, components.ToArray());
                string fieldLabel = addressSectionField.t;

                // If the field is in a named section, prefix its name to avoid collisions
                if (!string.IsNullOrEmpty(sectionTitle))
                    fieldLabel = string.Concat(sectionTitle, " - ", addressSectionField.t);

                pwEntry.Strings.Set(fieldLabel, new ProtectedString(false, fieldValue));
            }
        }

        private void setExpandedAddressField(PwEntry pwEntry, string sectionTitle, AddressSectionField addressSectionField)
        {
            string addressLocale = addressSectionField.v.country;

            if (string.IsNullOrEmpty(addressLocale))
                addressLocale = "us";

            foreach (PropertyInfo propertyInfo in addressSectionField.v.GetType().GetProperties())
            {
                List<string> fieldLabelParts = new List<string>();
                string fieldLabel = null;
                string fieldValue = propertyInfo.GetValue(addressSectionField.v, null) as string;

                // Skip the field if it's empty
                if (string.IsNullOrEmpty(fieldValue))
                    continue;

                // Find how this address part is called in the country where this address is located
                string addressPartName = Properties.ExpandedAddressParts.ResourceManager.GetString(string.Join("_", new string[] { "Address", addressLocale.Replace('-', '_'), propertyInfo.Name }));

                // Find the localized address part name
                if (!string.IsNullOrEmpty(addressPartName))
                    fieldLabel = Properties.Strings.ResourceManager.GetString(string.Join("_", new string[] { "Address", addressPartName }));

                // If no localized version of the address part name is found, use the generic field name
                if (string.IsNullOrEmpty(fieldLabel))
                    fieldLabel = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(propertyInfo.Name.ToLower());

                // If the field is in a named section, prefix its name to avoid collisions
                if (!string.IsNullOrEmpty(sectionTitle))
                    fieldLabelParts.Add(sectionTitle);

                // Then add the field title, if it has one
                if (!string.IsNullOrEmpty(addressSectionField.t))
                    fieldLabelParts.Add(addressSectionField.t);

                // And finally the address part name
                fieldLabelParts.Add(fieldLabel);

                // Join all parts together
                fieldLabel = string.Join(" - ", fieldLabelParts.ToArray());

                // Find the localized country name
                if (propertyInfo.Name.Equals("country"))
                {
                    // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
                    fieldValue = Properties.Strings.ResourceManager.GetString(string.Join("_", new string[] { "Menu", "country", fieldValue.Replace('-', '_') }));

                    // If no localized country name is found, use the ISO country code
                    if (string.IsNullOrEmpty(fieldValue))
                        fieldValue = fieldValue.ToUpper();
                }
                else if (propertyInfo.Name.Equals("street"))
                {
                    // Older format had two address lines, which may be joined with a new line
                    fieldValue = StringExt.ReplaceNewLines(fieldValue, " ");
                }

                pwEntry.Strings.Set(fieldLabel, new ProtectedString(false, fieldValue));
            }
        }

        protected bool IsUserSection(SecureContentsSection section)
        {
            return section.name != null && USER_SECTION_NAME.IsMatch(section.name);
        }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (this.sections != null)
            {
                int unnamedSectionNumber = 1;
                SectionFieldLocator usernameFieldLocator = this.GetUsernameFieldLocator();
                SectionFieldLocator passwordFieldLocator = this.GetPasswordFieldLocator();
                SectionFieldLocator urlFieldLocator = this.GetURLFieldLocator();

                foreach (SecureContentsSection section in this.sections)
                {
                    // Linked items are not supported
                    if (section.name.Equals(LINKED_ITEMS_SECTION_NAME))
                        continue;

                    // Section without fields, nothing to import
                    if (section.fields == null)
                        continue;

                    string sectionTitle = section.title;

                    // If it's an unnamed user-defined section, set a generic unique name (prevents field name collisions)
                    if (string.IsNullOrEmpty(section.title) && this.IsUserSection(section))
                        sectionTitle = string.Format("{0} {1}", Properties.Strings.Section_Title, unnamedSectionNumber++);

                    foreach (SectionField field in section.fields)
                    {
                        // Special treatment fields
                        if (field.k == SectionFieldType.concealed && OTP_FIELD_NAME.IsMatch(field.n ?? string.Empty))
                        {
                            // OTP fields must be formatted to comply with one of the OTP plugins
                            this.setOTPField(pwEntry, pwDatabase.MemoryProtection.ProtectPassword, field as GeneralSectionField, userPrefs.OTPFormat);
                            continue;
                        }
                        else if (field.k == SectionFieldType.address && (field as AddressSectionField).v != null)
                        {
                            // Addresses can be imported as a single composite field or splitting each component in a separate field
                            if (userPrefs.AddressFormat == AddressFormat.Compact)
                                this.setCompactAddressField(pwEntry, sectionTitle, field as AddressSectionField);
                            else if (userPrefs.AddressFormat == AddressFormat.Multiline)
                                this.setMultilineAddressField(pwEntry, sectionTitle, field as AddressSectionField);
                            else
                                this.setExpandedAddressField(pwEntry, sectionTitle, field as AddressSectionField);

                            continue;
                        }

                        string fieldLabel = field.t;
                        string fieldValue = null;

                        // If the field is in a named section, prefix its name to avoid collisions
                        if (!string.IsNullOrEmpty(sectionTitle))
                            fieldLabel = string.Concat(sectionTitle, " - ", field.t);

                        // Format the field value according to its type
                        if (field.k == SectionFieldType.date)
                        {
                            DateSectionField dateSectionField = field as DateSectionField;

                            if (!DateTime.MinValue.Equals(dateSectionField.v))
                                fieldValue = DateTimeFormatter.FormatDate(dateSectionField.v, userPrefs.DateFormat);
                        }
                        else if (field.k == SectionFieldType.monthYear)
                        {
                            MonthYearSectionField monthYearSectionField = field as MonthYearSectionField;

                            if (!DateTime.MinValue.Equals(monthYearSectionField.v))
                                fieldValue = DateTimeFormatter.FormatMonthYear(monthYearSectionField.v, userPrefs.DateFormat);
                        }
                        else if (field.k == SectionFieldType.menu || field.k == SectionFieldType.cctype || field.k == SectionFieldType.gender)
                        {
                            GeneralSectionField generalSectionField = field as GeneralSectionField;

                            // Combo-box values can't be empty
                            if (!string.IsNullOrEmpty(generalSectionField.v))
                                fieldValue = Properties.Strings.ResourceManager.GetString(string.Join("_", new string[] { "Menu", generalSectionField.n, generalSectionField.v }));
                        }
                        else
                        {
                            fieldValue = (field as GeneralSectionField).v;
                        }

                        // Use the proper line terminator in multiline values
                        if (field.a != null && field.a.multiline)
                            fieldValue = StringExt.FixNewLines(fieldValue);

                        // No point in importing an empty template field. If it's user-defined it might be there for a reason.
                        if (string.IsNullOrEmpty(fieldValue) && !this.IsUserSection(section))
                            continue;

                        bool protect;

                        if (usernameFieldLocator != null && usernameFieldLocator.Equals(section.name, field.n))
                        {
                            protect = pwDatabase.MemoryProtection.ProtectUserName;
                            pwEntry.Strings.Set(PwDefs.UserNameField, new ProtectedString(protect, fieldValue ?? string.Empty));
                            fieldValue = "{USERNAME}";
                        }
                        else if (passwordFieldLocator != null && passwordFieldLocator.Equals(section.name, field.n))
                        {
                            protect = pwDatabase.MemoryProtection.ProtectPassword;
                            pwEntry.Strings.Set(PwDefs.PasswordField, new ProtectedString(protect, fieldValue ?? string.Empty));
                            fieldValue = "{PASSWORD}";
                        }
                        else if (urlFieldLocator != null && urlFieldLocator.Equals(section.name, field.n))
                        {
                            protect = pwDatabase.MemoryProtection.ProtectUrl;
                            pwEntry.Strings.Set(PwDefs.UrlField, new ProtectedString(protect, fieldValue ?? string.Empty));
                            fieldValue = "{URL}";
                        }
                        else
                        {
                            protect = (field.k == SectionFieldType.concealed && pwDatabase.MemoryProtection.ProtectPassword) || (field.k == SectionFieldType.URL && pwDatabase.MemoryProtection.ProtectUrl);
                        }

                        // If it's one of the three special fields (username, password, url) and the 1Password field
                        // has the same name as the KeePass entry field, don't overwrite its value with the placeholder.
                        if (!pwEntry.Strings.Exists(fieldLabel))
                            pwEntry.Strings.Set(fieldLabel, new ProtectedString(protect, fieldValue ?? string.Empty));
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.notesPlain))
                pwEntry.Strings.Set(PwDefs.NotesField, new ProtectedString(pwDatabase.MemoryProtection.ProtectNotes, StringExt.FixNewLines(this.notesPlain)));

            if (this.customIcon != null)
            {
                byte[] customIconData = null;

                try
                {
                    using (MemoryStream originalIconStream = new MemoryStream(this.customIcon))
                    using (Bitmap originalIcon = new Bitmap(originalIconStream))
                    using (MemoryStream convertedIconStream = new MemoryStream())
                    {
                        originalIcon.Save(convertedIconStream, ImageFormat.Png);
                        customIconData = convertedIconStream.ToArray();

                        using (MD5 md5 = MD5.Create())
                        {
                            PwUuid customIconUuid = new PwUuid(md5.ComputeHash(customIconData));
                            this.PwCustomIcon = new PwCustomIcon(customIconUuid, customIconData);
                            pwEntry.CustomIconUuid = customIconUuid;
                        }
                    }
                }
                catch (ArgumentException)
                {
                    // Image format is not supported or one of its dimensions is bigger than 65,535
                }
            }
        }
    }
}
