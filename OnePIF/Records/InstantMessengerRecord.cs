using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class InstantMessengerSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Instant Messenger Data
        public string username { get; set; }

        public string password { get; set; }

        [JsonConverter(typeof(EnumConverter<InstantMessengerAccountType>))]
        public InstantMessengerAccountType account_type { get; set; }

        public string server { get; set; }

        public string port { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class InstantMessengerRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public InstantMessengerSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.UserCommunication;
        }
    }
}
