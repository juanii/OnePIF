using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class DriversLicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Driver's License Data
        public string fullname { get; set; }

        public string address { get; set; }

        #region Date of birth
        public string birthdate_yy { get; set; }

        public string birthdate_mm { get; set; }

        public string birthdate_dd { get; set; }
        #endregion

        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        public string height { get; set; }

        public string number { get; set; }

        public string @class { get; set;}

        public string conditions { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        #region Expiration Date
        public string expiry_date_yy { get; set; }

        public string expiry_date_mm { get; set; }
        #endregion
        #endregion
#pragma warning restore IDE1006
    }

    public class DriversLicenseRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public DriversLicenseSecureContents secureContents { get; set; }

        public ScopedOpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Certificate;

            return pwEntry;
        }
    }
}
