using KeePassLib;

namespace OnePIF.Records
{
    public class RewardProgramSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Reward Program Data
        public string company_name { get; set; }

        public string member_name { get; set; }

        public string membership_no { get; set; }

        public string pin { get; set; }
        #endregion

        #region More Information

        public string additional_no { get; set; }

        #region Member Since
        public string member_since_yy { get; set; }

        public string member_since_mm { get; set; }
        #endregion

        public string customer_service_phone { get; set; }

        public string reservations_phone { get; set; }

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
