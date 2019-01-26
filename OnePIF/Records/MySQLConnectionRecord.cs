using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class MySQLConnectionSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region MySQL Connection Data
        [ItemField(SectionFieldType.@string)]
        public string hostname { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string port { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string database { get; set; }

        [ItemField(SectionFieldType.@string)]
        public string username { get; set; }

        [ItemField(SectionFieldType.concealed)]
        public string password { get; set; }
        #endregion
#pragma warning restore IDE1006

        protected override SectionFieldLocator GetUsernameFieldLocator() { return new SectionFieldLocator(string.Empty, "username"); }

        protected override SectionFieldLocator GetPasswordFieldLocator() { return new SectionFieldLocator(string.Empty, "password"); }

        protected override SectionFieldLocator GetURLFieldLocator() { return new SectionFieldLocator(string.Empty, "hostname"); }
    }

    public class MySQLConnectionRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public MySQLConnectionSecureContents secureContents { get; set; }

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
