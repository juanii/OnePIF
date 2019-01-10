using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class ITunesSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region iTunes Data
        public string username { get; set; }

        public string password { get; set; }

        public string question { get; set; }

        public string answer { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class ITunesRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public ITunesSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Apple;
        }
    }
}
