using KeePassLib;

namespace OnePIF.Records
{
    public class WebFormRecord : SiteItemRecord
    {
#pragma warning disable IDE1006
        public WebFormSecureContents secureContents { get; set; }

        public SubmittableOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.World;

            return pwEntry;
        }
    }
}
