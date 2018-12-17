using KeePassLib;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class IdentitySecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Identification
        #region Full name
        public string firstName { get; set; }

        public string initial { get; set; }

        public string lastName { get; set; }
        #endregion

        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        #region Birth date
        public int birthdate_yy { get; set; }

        public int birthdate_mm { get; set; }

        public int birthdate_dd { get; set; }
        #endregion

        #region Job
        public string occupation { get; set; }

        public string company { get; set; }

        public string department { get; set; }

        public string jobtitle { get; set; }
        #endregion
#pragma warning disable IDE1006
#pragma warning disable IDE1006
        #endregion

        #region Address
        public string address1 { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        #region Default phone
        public string defphone_local { get; set; }

        public string defphone { get; set; }
        #endregion

        #region Home phone
        public string homephone_local { get; set; }

        public string homephone { get; set; }
        #endregion

        #region Cell phone
        public string cellphone_local { get; set; }

        public string cellphone { get; set; }
        #endregion

        #region Business phone
        public string busphone_local { get; set; }

        public string busphone { get; set; }
        #endregion
        #endregion

        #region Internet Details
        public string username { get; set; }

        public string reminderq { get; set; }

        public string remindera { get; set; }

        public string email { get; set; }

        public string website { get; set; }

        public string icq { get; set; }

        public string skype { get; set; }

        public string aim { get; set; }

        public string yahoo { get; set; }

        public string msn { get; set; }

        public string forumsig { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class IdentityRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public IdentitySecureContents secureContents { get; set; }

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
