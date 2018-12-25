using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class CreditCardSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Credit Card Data
        public string cardholder { get; set; }

        [JsonConverter(typeof(EnumConverter<CreditCardType>))]
        public CreditCardType type { get; set; }

        public string ccnum { get; set; }

        public string cvv { get; set; }

        #region Expiration date
        public string expiry_yy { get; set; }

        public string expiry_mm { get; set; }
        #endregion

        #region Valid from
        public string validFrom_yy { get; set; }

        public string validFrom_mm { get; set; }
        #endregion
        #endregion

        #region Contact Information
        public string bank { get; set; }

        public string phoneLocal { get; set; }

        public string phoneTollFree { get; set; }

        public string phoneIntl { get; set; }

        public string website { get; set; }
        #endregion

        #region Additional Details
        public string pin { get; set; }

        public string creditLimit { get; set; }

        public string cashLimit { get; set; }

        public string interest { get; set; }

        public string issuenumber { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class CreditCardRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public CreditCardSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Money;
        }
    }
}
