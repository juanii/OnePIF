using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;
using System;

namespace OnePIF.Records
{
    public class DotMacSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region DotMac Data
        public string email { get; set; }

        public string member_name { get; set; }

        public string password { get; set; }

        public string idisk_storage { get; set; }

        #region Renewal date
        public string renewal_date_yy { get; set; }

        public string renewal_hdate_mm { get; set; }

        public string renewal_hdate_dd { get; set; }
        #endregion

        public string activation_key { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class DotMacRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public DotMacSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Apple;
        }
    }
}
