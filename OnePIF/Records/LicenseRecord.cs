using KeePassLib;
using OnePIF.Types;

namespace OnePIF.Records
{
    public class LicenseSecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        #region Software License Data
        [ItemField(SectionFieldType.@string)]
        public string product_version { get; set; }

        [ItemField(SectionFieldType.@string, multiline = true)]
        public string reg_code { get; set; }
        #endregion

        #region Customer
        [ItemField(SectionFieldType.@string, sectionName = "customer")]
        public string reg_name { get; set; }

        [ItemField(SectionFieldType.email, sectionName = "customer")]
        public string reg_email { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "customer")]
        public string company { get; set; }
        #endregion

        #region Publisher
        [ItemField(SectionFieldType.URL, sectionName = "publisher")]
        public string download_link { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "publisher")]
        public string publisher_name { get; set; }
        
        [ItemField(SectionFieldType.URL, sectionName = "publisher")]
        public string publisher_website { get; set; }
        
        [ItemField(SectionFieldType.@string, sectionName = "publisher")]
        public string retail_price { get; set; }
        
        [ItemField(SectionFieldType.email, sectionName = "publisher")]
        public string support_email { get; set; }
        #endregion

        #region Order
        #region Purchase Date
        [ItemField(SectionFieldType.date, sectionName = "order", fieldName = "order_date")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string order_date_yy { get; set; }

        [ItemField(SectionFieldType.date, sectionName = "order", fieldName = "order_date")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string order_date_mm { get; set; }

        [ItemField(SectionFieldType.date, sectionName = "order", fieldName = "order_date")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string order_date_dd { get; set; }
        #endregion

        [ItemField(SectionFieldType.@string, sectionName = "order")]
        public string order_number { get; set; }
        
        [ItemField(SectionFieldType.@string, sectionName = "order")]
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

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Certificate;
        }
    }
}
