using KeePassLib;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class MembershipSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Membership Data
        [ItemField(SectionFieldType.@string)]
        public string org_name { get; set; }

        [ItemField(SectionFieldType.URL)]
        public string website { get; set; }

        [ItemField(SectionFieldType.phone)]
        public string phone { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string member_name { get; set; }

        #region Member Since
        [ItemField(SectionFieldType.monthYear, fieldName = "member_since")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string member_since_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, fieldName = "member_since")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string member_since_mm { get; set; }
        #endregion

        #region Expiration Date
        [ItemField(SectionFieldType.monthYear, fieldName = "expiry_date")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Year)]
        public string expiry_date_yy { get; set; }

        [ItemField(SectionFieldType.monthYear, fieldName = "expiry_date")]
        [MonthYearComponent(MonthYearComponentAttribute.MonthYearPart.Month)]
        public string expiry_date_mm { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string)]
        public string membership_no { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string pin { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "pin"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "website"); }
    }

    public class MembershipRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public MembershipSecureContents secureContents { get; set; }

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
