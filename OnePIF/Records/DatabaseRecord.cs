﻿using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class DatabaseSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        #region Database Data
        [JsonConverter(typeof(EnumConverter<DatabaseType>))]
        public DatabaseType database_type { get; set; }

        public string hostname { get; set; }

        public string port { get; set; }

        public string database { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string sid { get; set; }

        public string alias { get; set; }

        public string options { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "username"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "hostname"); }
    }

    public class DatabaseRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public DatabaseSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Drive;
        }
    }
}
