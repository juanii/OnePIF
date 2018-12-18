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

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Key;

            if (!string.IsNullOrEmpty(this.secureContents.password))
                pwEntry.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwDatabase.MemoryProtection.ProtectPassword, this.secureContents.password));

            return pwEntry;
        }
    }
}
