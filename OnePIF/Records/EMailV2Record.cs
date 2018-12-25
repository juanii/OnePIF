using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class EmailV2SecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region E-Mail Account Data
        [JsonConverter(typeof(EnumConverter<EMailV2POPType>))]
        public EMailV2POPType pop_type { get; set; }

        public string pop_username { get; set; }

        public string pop_server { get; set; }

        public string pop_port { get; set; }

        public string pop_password { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailV2POPSecurity>))]
        public EMailV2POPSecurity pop_security { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailV2POPAuthentication>))]
        public EMailV2POPAuthentication pop_authentication { get; set; }
        #endregion

        #region SMTP
        public string smtp_server { get; set; }

        public string smtp_port { get; set; }

        public string smtp_username { get; set; }

        public string smtp_password { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailV2SMTPSecurity>))]
        public EMailV2SMTPSecurity smtp_security { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailV2SMTPAuthentication>))]
        public EMailV2SMTPAuthentication smtp_authentication { get; set; }
        #endregion

        #region Contact Information
        public string provider { get; set; }

        public string provider_website { get; set; }

        public string phone_local { get; set; }

        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class EmailV2Record : ItemRecord
    {
#pragma warning disable IDE1006
        public EmailV2SecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.EMail;
        }
    }
}
