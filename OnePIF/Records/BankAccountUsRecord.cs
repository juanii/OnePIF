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
        [ItemField(SectionFieldType.@string)]
        public string bankName { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string owner { get; set; }

        [ItemField(SectionFieldType.menu)]
        [JsonConverter(typeof(EnumConverter<BankAccountType>))]
        public BankAccountType accountType { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string routingNo { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string accountNo { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string swift { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string iban { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string telephonePin { get; set; }
        #endregion

        #region Branch Information
        [ItemField(SectionFieldType.phone, sectionName = "branchInfo")]
        public string branchPhone { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "branchInfo")]
        public string branchAddress { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "telephonePin"); }
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
