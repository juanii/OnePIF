using KeePassLib;

namespace OnePIF.Records
{
    public class SsnUsSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        public string name { get; set; }

        public string number { get; set; }
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "number"); }
    }

    public class SsnUsRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public SsnUsSecureContents secureContents { get; set; }

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
