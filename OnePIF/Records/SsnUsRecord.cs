using KeePassLib;

namespace OnePIF.Records
{
    public class SsnUsSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        public string name { get; set; }

        public string number { get; set; }
#pragma warning restore IDE1006
    }

    public class SsnUsRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public SsnUsSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Identity;

            return pwEntry;
        }
    }
}
