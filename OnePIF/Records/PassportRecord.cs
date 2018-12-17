using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class PassportSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Passport Data
        public string type { get; set; }

        public string issuing_country { get; set; }

        public string number { get; set; }

        public string fullname { get; set; }

        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        public string nationality { get; set; }

        public string issuing_authority { get; set; }

        #region Birth Date
        public int birthdate_yy { get; set; }

        public int birthdate_mm { get; set; }

        public int birthdate_dd { get; set; }
        #endregion

        public string birthplace { get; set; }

        #region Issue Date
        public int issue_date_yy { get; set; }

        public int issue_date_mm { get; set; }

        public int issue_date_dd { get; set; }
        #endregion

        #region Expiration Date
        public int expiry_date_yy { get; set; }

        public int expiry_date_mm { get; set; }

        public int expiry_date_dd { get; set; }
        #endregion
        #endregion
#pragma warning restore IDE1006
    }

    public class PassportRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public PassportSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Identity;

            return pwEntry;
        }
    }
}
