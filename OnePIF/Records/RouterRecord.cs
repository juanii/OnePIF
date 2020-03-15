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
        [ItemField(SectionFieldType.@string)]
        public string name { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string server { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string airport_id { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string network_name { get; set; }

        [ItemField(SectionFieldType.menu)]
        [JsonConverter(typeof(EnumConverter<WirelessSecurity>))]
        public WirelessSecurity wireless_security { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string wireless_password { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string disk_password { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "server"); }
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
