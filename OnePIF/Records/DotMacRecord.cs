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
        [ItemField(SectionFieldType.@string)]
        public string email { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string member_name { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string idisk_storage { get; set; }

        #region Renewal date
        [ItemField(SectionFieldType.date, fieldName = "renewal_date")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string renewal_date_yy { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "renewal_date")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string renewal_date_mm { get; set; }

        [ItemField(SectionFieldType.date, fieldName = "renewal_date")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string renewal_date_dd { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string)]
        public string activation_key { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "email"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }
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
