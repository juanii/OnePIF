using KeePassLib;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class RewardProgramSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Reward Program Data
        [ItemField(SectionFieldType.@string)]
        public string company_name { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string member_name { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string membership_no { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string pin { get; set; }
        #endregion

        #region More Information

        [ItemField(SectionFieldType.@string, sectionName = "extra")]
        public string additional_no { get; set; }

        #region Member Since
        [ItemField(SectionFieldType.monthYear, sectionName = "extra", fieldName = "member_since")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string member_since_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, sectionName = "extra", fieldName = "member_since")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string member_since_mm { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string, sectionName = "extra")]
        public string customer_service_phone { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "extra")]
        public string reservations_phone { get; set; }

        [ItemField(SectionFieldType.URL, sectionName = "extra")]
        public string website { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "pin"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator("extra", "website"); }
    }

    public class RewardProgramRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public RewardProgramSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Homebanking;
        }
    }
}
