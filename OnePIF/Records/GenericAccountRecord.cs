using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class GenericAccountSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Generic Account Data
        public string username { get; set; }

        public string password { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class GenericAccountRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public GenericAccountSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Key;
        }
    }
}
