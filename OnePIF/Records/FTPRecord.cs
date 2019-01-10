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
        public string server { get; set; }

        public string path { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        #endregion

        #region Contact Information
        public string provider { get; set; }

        public string provider_website { get; set; }

        public string phone_local { get; set; }

        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006
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
