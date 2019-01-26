using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class PassportSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Passport Data
        [ItemField(SectionFieldType.@string)]
        public string type { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string issuing_country { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string number { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string fullname { get; set; }

        [ItemField(SectionFieldType.gender)]
        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string nationality { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string issuing_authority { get; set; }

        #region Birth Date
        [ItemField(SectionFieldType.date, fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string birthdate_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string birthdate_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string birthdate_dd { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string)]
        public string birthplace { get; set; }

        #region Issue Date
        [ItemField(SectionFieldType.date, fieldName = "issue_date")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string issue_date_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "issue_date")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string issue_date_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "issue_date")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string issue_date_dd { get; set; }
        #endregion

        #region Expiration Date
        [ItemField(SectionFieldType.date, fieldName = "expiry_date")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string expiry_date_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "expiry_date")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string expiry_date_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "expiry_date")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string expiry_date_dd { get; set; }
        #endregion
        #endregion
#pragma warning restore IDE1006
    }

    public class PassportRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public PassportSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Identity;
        }
    }
}
