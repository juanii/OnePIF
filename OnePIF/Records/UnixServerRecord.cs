using KeePassLib;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class UnixServerSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Server Data
        [ItemField(SectionFieldType.@string)] // WTF: Not URL?
        public string url { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string username { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }
        #endregion

        #region Admin Console
        [ItemField(SectionFieldType.@string, sectionName = "admin_console")]
        public string admin_console_url { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "admin_console")]
        public string admin_console_username { get; set; }

        [ItemField(SectionFieldType.concealed, sectionName = "admin_console")]
        public string admin_console_password { get; set; }
        #endregion

        #region Hosting Provider
        [ItemField(SectionFieldType.@string, sectionName = "hosting_provider_details")]
        public string name { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "hosting_provider_details")]
        public string website { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "hosting_provider_details")]
        public string support_contact_url { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "hosting_provider_details")]
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
