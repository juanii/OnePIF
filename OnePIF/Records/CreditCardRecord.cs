using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class CreditCardSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Credit Card Data
        [ItemField(SectionFieldType.@string)]
        public string cardholder { get; set; }

        [ItemField(SectionFieldType.cctype)]
        [JsonConverter(typeof(EnumConverter<CreditCardType>))]
        public CreditCardType type { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string ccnum { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string cvv { get; set; }

        #region Expiration date
        [ItemField(SectionFieldType.monthYear, fieldName = "expiry")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string expiry_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, fieldName = "expiry")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string expiry_mm { get; set; }
        #endregion

        #region Valid from
        [ItemField(SectionFieldType.monthYear, fieldName = "validFrom")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string validFrom_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, fieldName = "validFrom")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string validFrom_mm { get; set; }
        #endregion
        #endregion

        #region Contact Information
        [ItemField(SectionFieldType.@string, sectionName = "contactInfo")]
        public string bank { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "contactInfo")]
        public string phoneLocal { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "contactInfo")]
        public string phoneTollFree { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "contactInfo")]
        public string phoneIntl { get; set; }

        [ItemField(SectionFieldType.URL, sectionName = "contactInfo")]
        public string website { get; set; }
        #endregion

        #region Additional Details
        [ItemField(SectionFieldType.concealed, sectionName = "details")]
        public string pin { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "details")]
        public string creditLimit { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "details")]
        public string cashLimit { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "details")]
        public string interest { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "details")]
        public string issuenumber { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "cvv"); }
    }

    public class CreditCardRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public CreditCardSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Money;
        }
    }
}
