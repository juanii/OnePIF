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

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            // Fill the URL before processing the rest of the fields so duplicate URLs can be detected
            if (!string.IsNullOrEmpty(this.location))
                pwEntry.Strings.Set(PwDefs.UrlField, new ProtectedString(pwDatabase.MemoryProtection.ProtectUrl, this.location));

            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
        }
    }
}
