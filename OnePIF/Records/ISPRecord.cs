using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class ISPSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region ISP Data
        [ItemField(SectionFieldType.@string)]
        public string userid { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string pin { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string dialup_number { get; set; }
        #endregion

        #region Contact Information
        [ItemField(SectionFieldType.@string, sectionName = "Contact Information")]
        public string website { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "Contact Information")] // WTF: Type String (subtype Phone)
        public string phone_local { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "Contact Information")] // WTF: Type String (subtype Phone)
        public string phone_tollfree { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "userid"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }
    }

    public class ISPRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public ISPSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.WorldComputer;
        }
    }
}
