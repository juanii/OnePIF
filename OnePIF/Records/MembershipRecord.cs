using KeePassLib;

namespace OnePIF.Records
{
    public class MembershipSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Membership Data
        public string org_name { get; set; }

        public string website { get; set; }

        public string phone { get; set; }

        public string member_name { get; set; }

        #region Member Since
        public string member_since_yy { get; set; }

        public string member_since_mm { get; set; }
        #endregion

        #region Expiration Date
        public string expiry_date_yy { get; set; }

        public string expiry_date_mm { get; set; }
        #endregion

        public string membership_no { get; set; }

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
