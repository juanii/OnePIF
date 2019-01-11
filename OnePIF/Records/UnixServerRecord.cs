using KeePassLib;

namespace OnePIF.Records
{
    public class UnixServerSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Server Data
        public string url { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        #endregion

        #region Admin Console
        public string admin_console_url { get; set; }

        public string admin_console_username { get; set; }

        public string admin_console_password { get; set; }
        #endregion

        #region Hosting Provider
        public string name { get; set; }

        public string website { get; set; }

        public string support_contact_url { get; set; }

        public string support_contact_phone { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "username"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "url"); }
    }

    public class UnixServerRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public UnixServerSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.NetworkServer;
        }
    }
}
