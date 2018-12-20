using KeePassLib;
using KeePassLib.Security;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;
using System;
using System.Drawing;

namespace OnePIF.Records
{
    [JsonConverter(typeof(BaseRecordConverter))]
    public class BaseRecord
    {
#pragma warning disable IDE1006
        [JsonConverter(typeof(UUIDConverter))]
        public Guid uuid { get; set; }

        [JsonConverter(typeof(UUIDConverter))]
        public Guid folderUuid { get; set; }

        [JsonConverter(typeof(RecordTypeConverter))]
        public RecordType typeName { get; set; }

        public string title { get; set; }

        public string securityLevel { get; set; }

        public string contentsHash { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime txTimestamp { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime createdAt { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime updatedAt { get; set; }
#pragma warning restore IDE1006

        public virtual PwEntry CreatePwEntry(PwDatabase pwStorage, UserPrefs userPrefs)
        {
            PwEntry entry = new PwEntry(true, true)
            {
                CreationTime = this.createdAt,
                LastModificationTime = this.updatedAt
            };

            if (!string.IsNullOrEmpty(this.title))
                entry.Strings.Set(PwDefs.TitleField, new ProtectedString(pwStorage.MemoryProtection.ProtectTitle, this.title));

            return entry;
        }
    }
}
