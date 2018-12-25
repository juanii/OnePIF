using KeePassLib;

namespace OnePIF.Records
{
    public class HuntingLicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Outdoor License Data
        public string name { get; set; }

        #region Valid From
        public string valid_from_yy { get; set; }

        public string valid_from_mm { get; set; }

        public string valid_from_dd { get; set; }
        #endregion

        #region Expiration Date
        public string expires_yy { get; set; }

        public string expires_mm { get; set; }

        public string expires_dd { get; set; }
        #endregion

        public string game { get; set; }

        public string quota { get; set; }

        public string state { get; set; }

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
