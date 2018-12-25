using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class RouterSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Wireless Router Data
        public string name { get; set; }

        public string password { get; set; }

        public string server { get; set; }

        public string airport_id { get; set; }

        public string network_name { get; set; }

        [JsonConverter(typeof(EnumConverter<WirelessSecurity>))]
        public WirelessSecurity wireless_security { get; set; }

        public string wireless_password { get; set; }

        public string disk_password { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class RouterRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public RouterSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.IRCommunication;
        }
    }
}
