using KeePassLib;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class HuntingLicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Outdoor License Data
        [ItemField(Types.SectionFieldType.@string)]
        public string name { get; set; }

        #region Valid From
        [ItemField(SectionFieldType.date, fieldName = "valid_from")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string valid_from_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "valid_from")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string valid_from_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "valid_from")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string valid_from_dd { get; set; }
        #endregion

        #region Expiration Date
        [ItemField(SectionFieldType.date, fieldName = "expires")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string expires_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "expires")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string expires_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "expires")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string expires_dd { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string)]
        public string game { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string quota { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string state { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string country { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class HuntingLicenseRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public HuntingLicenseSecureContents secureContents { get; set; }

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
