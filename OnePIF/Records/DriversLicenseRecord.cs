using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class DriversLicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Driver's License Data
        [ItemField(SectionFieldType.@string)]
        public string fullname { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string address { get; set; }

        #region Date of birth
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

        [ItemField(SectionFieldType.gender)]
        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string height { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string number { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string @class { get; set;}

        [ItemField(SectionFieldType.@string)]
        public string conditions { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string state { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string country { get; set; }

        #region Expiration Date
        [ItemField(SectionFieldType.monthYear, fieldName = "expiry_date")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string expiry_date_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, fieldName = "expiry_date")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string expiry_date_mm { get; set; }
        #endregion
        #endregion
#pragma warning restore IDE1006
    }

    public class DriversLicenseRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public DriversLicenseSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Certificate;
        }
    }
}
