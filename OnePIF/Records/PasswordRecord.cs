using KeePassLib;
using KeePassLib.Security;

namespace OnePIF.Records
{
    public class PasswordSecureContents : URLListSecureContents
    {
#pragma warning disable IDE1006
        public string password { get; set; }
#pragma warning restore IDE1006
    }

    public class PasswordRecord : SiteItemRecord
    {
#pragma warning disable IDE1006
        public PasswordSecureContents secureContents { get; set; }

        public OpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            if (!string.IsNullOrEmpty(this.secureContents.password))
                pwEntry.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwDatabase.MemoryProtection.ProtectPassword, this.secureContents.password));

            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            pwEntry.IconId = PwIcon.Key;
        }
    }
}
