using KeePassLib;

namespace OnePIF.Records
{
    public class LicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Software License Data
        public string product_version { get; set; }

        public string reg_code { get; set; }
        #endregion

        #region Customer
        public string reg_name { get; set; }

        public string reg_email { get; set; }

        public string company { get; set; }
        #endregion

        #region Publisher
        public string download_link { get; set; }

        public string publisher_name { get; set; }
        
        public string publisher_website { get; set; }
        
        public string retail_price { get; set; }
        
        public string support_email { get; set; }
        #endregion

        #region Order
        #region Purchase Date
        public string order_date_yy { get; set; }

        public string order_date_mm { get; set; }
        
        public string order_date_dd { get; set; }
        #endregion
     
        public string order_number { get; set; }
        
        public string order_total { get; set; }
        #endregion
#pragma warning restore IDE1006
    }

    public class LicenseRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public LicenseSecureContents secureContents { get; set; }

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
