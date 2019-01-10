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
            { "wallet.computer.License", typeof(LicenseRecord) },
            // Legacy
            { "wallet.onlineservices.Email", typeof(EMailRecord) },
            { "wallet.onlineservices.iTunes", typeof(ITunesRecord) },
            { "wallet.computer.MySQLConnection", typeof(MySQLConnectionRecord) },
            { "wallet.onlineservices.FTP", typeof(FTPRecord) },
            { "wallet.onlineservices.DotMac", typeof(DotMacRecord) },
            { "wallet.onlineservices.GenericAccount", typeof(GenericAccountRecord) },
            { "wallet.onlineservices.InstantMessenger", typeof(InstantMessengerRecord) },
            { "wallet.onlineservices.ISP", typeof(ISPRecord) },
            { "wallet.onlineservices.AmazonS3", typeof(AmazonS3Record) }
        };

        private static Dictionary<string, string> itemTypeByCategory = new Dictionary<string, string>()
        {
            { "001", "webforms.WebForm" },
            { "002", "wallet.financial.CreditCard" },
            { "003", "securenotes.SecureNote" },
            { "004", "identities.Identity" },
            { "005", "passwords.Password" },
            { "100", "wallet.computer.License" },
            { "101", "wallet.financial.BankAccountUS" },
            { "102", "wallet.computer.Database" },
            { "103", "wallet.government.DriversLicense" },
            { "104", "wallet.government.HuntingLicense" },
            { "105", "wallet.membership.Membership" },
            { "106", "wallet.government.Passport" },
            { "107", "wallet.membership.RewardProgram" },
            { "108", "wallet.government.SsnUS" },
            { "109", "wallet.computer.Router" },
            { "110", "wallet.computer.UnixServer" },
            { "111", "wallet.onlineservices.Email.v2" }
        };

        private void convertWinToMac(JObject jsonRecord)
        {
            // Rename top-level members
            if (jsonRecord.ContainsKey("tx"))
                JPropertyExt.Rename(jsonRecord.Property("tx"), "txTimestamp");

            if (jsonRecord.ContainsKey("parent")) // Folders call their parent folder "parent"
                JPropertyExt.Rename(jsonRecord.Property("parent"), "folderUuid");
            else if (jsonRecord.ContainsKey("folder")) // Items call their parent folder "folder"
                JPropertyExt.Rename(jsonRecord.Property("folder"), "folderUuid");

            if (jsonRecord.ContainsKey("fave"))
                JPropertyExt.Rename(jsonRecord.Property("fave"), "faveIndex");

            if (jsonRecord.ContainsKey("created"))
                JPropertyExt.Rename(jsonRecord.Property("created"), "createdAt");

            if (jsonRecord.ContainsKey("updated"))
                JPropertyExt.Rename(jsonRecord.Property("updated"), "updatedAt");

            if (jsonRecord.ContainsKey("details"))
                JPropertyExt.Rename(jsonRecord.Property("details"), "secureContents");

            if (jsonRecord.ContainsKey("overview"))
                JPropertyExt.Rename(jsonRecord.Property("overview"), "openContents");

            // Convert item category to item type
            if (jsonRecord.ContainsKey("category"))
            {
                string category = (string)jsonRecord.Property("category");
                string itemType;

                if (!itemTypeByCategory.TryGetValue(category, out itemType))
                    itemType = category;

                jsonRecord.Add("typeName", itemType);
            }

            // Rearrange/rename members from openContents/secureContents
            JObject openContents = (JObject)jsonRecord.GetValue("openContents");
            if (openContents == null)
                openContents = new JObject();

            JObject secureContents = (JObject)jsonRecord.GetValue("secureContents");
            if (secureContents == null)
                secureContents = new JObject();

            if (jsonRecord.ContainsKey("scope"))
                JPropertyExt.Move(jsonRecord.Property("scope"), openContents);

            if (openContents.ContainsKey("title"))
                JPropertyExt.Move(openContents.Property("title"), jsonRecord);

            if (openContents.ContainsKey("url"))
                JPropertyExt.Move(JPropertyExt.Rename(openContents.Property("url"), "location"), jsonRecord);

            if (openContents.ContainsKey("URLs"))
            {
                JArray urls = (JArray)openContents.GetValue("URLs");

                foreach (JToken url in urls)
                {
                    if (url.Type == JTokenType.Object)
                    {
                        JPropertyExt.Rename((url as JObject).Property("u"), "url");
                        JPropertyExt.Rename((url as JObject).Property("l"), "label");
                    }
                }

                JPropertyExt.Move(openContents.Property("URLs"), secureContents);
            }

            if (openContents.ContainsKey("icon"))
                JPropertyExt.Move(JPropertyExt.Rename(openContents.Property("icon"), "customIcon"), secureContents);

            // If there wasn't an openContents member and we needed to add properties to one
            if (openContents.Parent == null && openContents.Count > 0)
                jsonRecord.Add(new JProperty("openContents", openContents));

            // If there wasn't a secureContents member and we needed to add poperties to one
            if (secureContents.Parent == null && secureContents.Count > 0)
                jsonRecord.Add(new JProperty("secureContents", secureContents));
        }

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseRecord).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonRecord = JObject.Load(reader);

            if (jsonRecord.ContainsKey("tx")) // 1P4 for MS-Windows
                this.convertWinToMac(jsonRecord);

            string recordType = (string)jsonRecord.GetValue("typeName");
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
