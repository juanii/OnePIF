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

        private static readonly string LINKED_ITEMS_SECTION_NAME = "linked items";

        private static readonly Regex USER_SECTION_NAME = new Regex("^Section_[0-9A-F]{32}$", RegexOptions.Compiled);

        private static readonly Regex OTP_FIELD_NAME = new Regex("^TOTP_[0-9A-F]{32}$", RegexOptions.Compiled);

        private static readonly string OTP_DEFAULT_PERIOD = "30";

        private static readonly string OTP_DEFAULT_DIGITS = "6";

        private void setupOTPField(PwEntry pwEntry, bool protectSecret, GeneralSectionField sectionField, OTPFormat otpFormat)
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
                    // Some Kee* implementations don't show the OTP if these optional values are missing
                    pwEntry.Strings.Set("TOTP Settings", new ProtectedString(false, string.Join(";", new string[] { period ?? OTP_DEFAULT_PERIOD, digits ?? OTP_DEFAULT_DIGITS })));
                }
            }
        }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (this.sections != null)
            {
                int i = 1;

                foreach (SecureContentsSection section in this.sections)
                {
                    if (section.name.Equals(LINKED_ITEMS_SECTION_NAME))
                        continue;

                    if (section.fields != null)
                    {
                        string sectionTitle = section.title;
                        bool isUserSection = USER_SECTION_NAME.IsMatch(section.name);

                        if (string.IsNullOrEmpty(section.title) && isUserSection)
                            sectionTitle = string.Format("{0} {1}", Properties.Strings.Section_Title, i++);

                        foreach (SectionField field in section.fields)
                        {
                            string fieldLabel = field.t;
                            string fieldValue = null;

                            if (field.k == SectionFieldType.concealed && OTP_FIELD_NAME.IsMatch(field.n ?? string.Empty))
                            {
                                this.setupOTPField(pwEntry, pwDatabase.MemoryProtection.ProtectPassword, field as GeneralSectionField, userPrefs.OTPFormat);
                                continue;
                            }

                            if (!string.IsNullOrEmpty(sectionTitle))
                                fieldLabel = string.Concat(sectionTitle, " - ", field.t);

                            if (field.k == SectionFieldType.address)
                            {
                                AddressSectionField addressSectionField = field as AddressSectionField;

                                // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
                                string addressFormat = Properties.CompactAddressFormat.ResourceManager.GetString(string.Join("_", new string[] { "Country", addressSectionField.v.country.Replace('-', '_') }));

                                if (string.IsNullOrEmpty(addressFormat))
                                    addressFormat = Properties.CompactAddressFormat.Country_us;

                                string[] tokens = addressFormat.Split(new char[] { '|' });
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

                                            // Locale IDs can contain dashes (-) which are illegal characters in resource files, so they're replaced with underscores (_)
                                            if (subtoken.Equals("country") && !string.IsNullOrEmpty(tokenValue))
                                                tokenValue = Properties.Strings.ResourceManager.GetString(string.Join("_", new string[] { "Menu", "country", tokenValue.Replace('-', '_') }));

                                            if (!string.IsNullOrEmpty(tokenValue))
                                                subcomponents.Add(tokenValue);
                                        }
                                    }
                                    
                                    if (subcomponents.Count > 0)
                                        components.Add(string.Join(" ", subcomponents.ToArray()));
                                }

                                fieldValue = string.Join(", ", components.ToArray());
                            }
                            else if (field.k == SectionFieldType.date)
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

                            if (field.a != null && field.a.multiline)
                                fieldValue = StringExt.FixNewLines(fieldValue);

                            // No point in importing an empty template field.
                            // But, if it's a user-defined field, it might be there for a reason.
                            if (fieldValue == null && !isUserSection)
                                continue;

                            bool protect = (field.k == SectionFieldType.concealed && pwDatabase.MemoryProtection.ProtectPassword) || (field.k == SectionFieldType.URL && pwDatabase.MemoryProtection.ProtectUrl);
                            pwEntry.Strings.Set(fieldLabel, new ProtectedString(protect, fieldValue ?? string.Empty));
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.notesPlain))
                pwEntry.Strings.Set(PwDefs.NotesField, new ProtectedString(pwDatabase.MemoryProtection.ProtectNotes, StringExt.FixNewLines(this.notesPlain)));
        }

        // Ugly
        public override PwCustomIcon GetCustomIcon()
        {
            PwCustomIcon pwCustomIcon = null;

            if (this.customIcon != null && this.customIcon.Length > 0)
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
                            pwCustomIcon = new PwCustomIcon(customIconUuid, customIconData);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    // Image format is not supported or one of its dimensions is bigger than 65,535
                }
            }

            return pwCustomIcon;
        }
    }
}
