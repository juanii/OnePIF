﻿using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class AmazonS3SecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Amazon S3 Data
        public string email { get; set; }

        public string password { get; set; }

        public string access_key_id { get; set; }

        public string access_key { get; set; }

        public string path { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "email"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }
    }

    public class AmazonS3Record : ItemRecord
    {
#pragma warning disable IDE1006
        public AmazonS3SecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.NetworkServer;
        }
    }
}
