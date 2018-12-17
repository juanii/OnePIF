using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnePIF.Records;
using System;
using System.Collections.Generic;

namespace OnePIF.Converters
{
    public class BaseRecordConverter : JsonConverter
    {
        private static Dictionary<string, Type> classTypesByItemType = new Dictionary<string, Type>()
        {
            { "system.folder.SavedSearch", typeof(SavedSearchRecord) },
            { "system.folder.Regular", typeof(RegularFolderRecord) },
            { "webforms.WebForm", typeof(WebFormRecord) },
            { "securenotes.SecureNote", typeof(SecureNoteRecord) },
            { "wallet.financial.CreditCard", typeof(CreditCardRecord) },
            { "passwords.Password", typeof(PasswordRecord) },
            { "identities.Identity", typeof(IdentityRecord) },
            { "wallet.financial.BankAccountUS", typeof(BankAccountUsRecord) },
            { "wallet.computer.Database", typeof(DatabaseRecord) },
            { "wallet.government.DriversLicense", typeof(DriversLicenseRecord) },
            { "wallet.membership.Membership", typeof(MembershipRecord) },
            { "wallet.onlineservices.Email.v2", typeof(EmailV2Record) },
            { "wallet.government.HuntingLicense", typeof(HuntingLicenseRecord) },
            { "wallet.membership.RewardProgram", typeof(RewardProgramRecord) },
            { "wallet.government.Passport", typeof(PassportRecord) },
            { "wallet.computer.UnixServer", typeof(UnixServerRecord) },
            { "wallet.government.SsnUS", typeof(SsnUsRecord) },
            { "wallet.computer.Router", typeof(RouterRecord) },
            { "wallet.computer.License", typeof(LicenseRecord) }
        };

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseRecord).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonRecord = JObject.Load(reader);

            string recordType = (string)jsonRecord.Property("typeName");
            BaseRecord record = null;

            if (!string.IsNullOrEmpty(recordType) && classTypesByItemType.ContainsKey(recordType))
                record = Activator.CreateInstance(classTypesByItemType[recordType]) as BaseRecord;
            else
                record = new UnknownRecord();

            serializer.Populate(jsonRecord.CreateReader(), record);

            return record;
        }
    }
}
