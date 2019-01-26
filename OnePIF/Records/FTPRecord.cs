using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class FTPSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region FTP Data
        [ItemField(SectionFieldType.@string)]
        public string server { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string path { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string username { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }
        #endregion

        #region Contact Information
        [ItemField(SectionFieldType.@string, sectionName = "Contact Information")]
        public string provider { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "Contact Information")]
        public string provider_website { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "Contact Information")]
        public string phone_local { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "Contact Information")]
        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "username"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "server"); }
    }

    public class FTPRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public FTPSecureContents secureContents { get; set; }

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
