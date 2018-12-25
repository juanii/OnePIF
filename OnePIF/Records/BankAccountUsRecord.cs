using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class BankAccountUsSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Bank Account Data
        public string bankName { get; set; }

        public string owner { get; set; }

        [JsonConverter(typeof(EnumConverter<BankAccountType>))]
        public BankAccountType accountType { get; set; }

        public string routingNo { get; set; }

        public string accountNo { get; set; }

        public string swift { get; set; }

        public string iban { get; set; }

        public string telephonePin { get; set; }
        #endregion

        #region Branch Information
        public string branchPhone { get; set; }

        public string branchAddress { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class BankAccountUsRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public BankAccountUsSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Homebanking;
        }
    }
}
