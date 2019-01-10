using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OnePIF.Converters
{
    public class RecordTypeConverter : JsonConverter
    {
        private static Dictionary<string, Records.RecordType> recordTypesByItemType = new Dictionary<string, Records.RecordType>()
        {
            { "system.folder.Regular", Records.RecordType.RegularFolder },
            { "webforms.WebForm", Records.RecordType.WebForm },
            { "securenotes.SecureNote", Records.RecordType.SecureNote },
            { "wallet.financial.CreditCard", Records.RecordType.CreditCard },
            { "passwords.Password", Records.RecordType.Password },
            { "identities.Identity", Records.RecordType.Identity },
            { "wallet.financial.BankAccountUS", Records.RecordType.BankAccountUS },
            { "wallet.computer.Database", Records.RecordType.Database },
            { "wallet.government.DriversLicense", Records.RecordType.DriversLicense },
            { "wallet.membership.Membership", Records.RecordType.Membership },
            { "wallet.onlineservices.Email.v2", Records.RecordType.EmailV2 },
            { "wallet.government.HuntingLicense", Records.RecordType.HuntingLicense },
            { "wallet.membership.RewardProgram", Records.RecordType.RewardProgram },
            { "wallet.government.Passport", Records.RecordType.Passport },
            { "wallet.computer.UnixServer", Records.RecordType.UnixServer },
            { "wallet.government.SsnUS", Records.RecordType.SsnUS },
            { "wallet.computer.Router", Records.RecordType.Router },
            { "wallet.computer.License", Records.RecordType.License },
            // Legacy
            { "wallet.onlineservices.Email", Records.RecordType.Email },
            { "wallet.onlineservices.iTunes", Records.RecordType.iTunes },
            { "wallet.computer.MySQLConnection", Records.RecordType.MySQLConnection },
            { "wallet.onlineservices.FTP", Records.RecordType.FTP },
            { "wallet.onlineservices.DotMac", Records.RecordType.DotMac },
            { "wallet.onlineservices.GenericAccount", Records.RecordType.GenericAccount },
            { "wallet.onlineservices.InstantMessenger", Records.RecordType.InstantMessenger },
            { "wallet.onlineservices.ISP", Records.RecordType.ISP },
            { "wallet.onlineservices.AmazonS3", Records.RecordType.AmazonS3 }
        };

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Records.RecordType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string itemType = (string)reader.Value;

            if (!string.IsNullOrEmpty(itemType) && recordTypesByItemType.ContainsKey(itemType))
                return recordTypesByItemType[itemType];

            return Records.RecordType.Unknown;
        }
    }
}
