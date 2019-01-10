using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class ISPSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region ISP Data
        public string userid { get; set; }

        public string password { get; set; }

        public string pin { get; set; }

        public string dialup_number { get; set; }
        #endregion

        #region Contact Information
        public string website { get; set; }

        public string phone_local { get; set; }

        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class ISPRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public ISPSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.WorldComputer;
        }
    }
}
