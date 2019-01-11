using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class EmailSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region E-Mail Account Data
        [JsonConverter(typeof(EnumConverter<EMailPOPType>))]
        public EMailPOPType pop_type { get; set; }

        public string pop_username { get; set; }

        public string pop_server { get; set; }

        public string pop_port { get; set; }

        public string pop_password { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailPOPUseSSL>))]
        public EMailPOPUseSSL pop_use_ssl { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailPOPAuthentication>))]
        public EMailPOPAuthentication pop_authentication { get; set; }
        #endregion

        #region SMTP
        public string smtp_server { get; set; }

        public string smtp_port { get; set; }

        public string smtp_username { get; set; }

        public string smtp_password { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailSMTPUseSSL>))]
        public EMailSMTPUseSSL smtp_use_ssl { get; set; }

        [JsonConverter(typeof(EnumConverter<EMailSMTPAuthentication>))]
        public EMailSMTPAuthentication smtp_authentication { get; set; }
        #endregion

        #region Contact Information
        public string provider { get; set; }

        public string provider_website { get; set; }

        public string phone_local { get; set; }

        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "pop_username"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "pop_password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "pop_server"); }
    }

    public class EMailRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public EmailSecureContents secureContents { get; set; }

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
