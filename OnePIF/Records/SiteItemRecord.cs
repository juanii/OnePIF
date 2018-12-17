using KeePassLib;
using KeePassLib.Security;

namespace OnePIF.Records
{
    public abstract class SiteItemRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public string locationKey { get; set; }

        public string location { get; set; }
#pragma warning restore IDE1006

        public override PwEntry CreatePwEntry(PwDatabase pwStorage, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwStorage, userPrefs);

            if (!string.IsNullOrEmpty(this.location))
                pwEntry.Strings.Set(PwDefs.UrlField, new ProtectedString(pwStorage.MemoryProtection.ProtectUrl, this.location));

            return pwEntry;
        }
    }
}
