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
        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string firstname { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string initial { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string lastname { get; set; }
        #endregion

        [ItemField(SectionFieldType.menu, sectionName = "name")]
        [JsonConverter(typeof(EnumConverter<Gender>))]
        public Gender sex { get; set; }

        #region Birth date
        [ItemField(SectionFieldType.date, sectionName = "name", fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Year)]
        public string birthdate_yy { get; set; }

        [ItemField(SectionFieldType.date, sectionName = "name", fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Month)]
        public string birthdate_mm { get; set; }

        [ItemField(SectionFieldType.date, sectionName = "name", fieldName = "birthdate")]
        [DateComponent(DateComponentAttribute.DatePart.Day)]
        public string birthdate_dd { get; set; }
        #endregion

        #region Job
        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string occupation { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string company { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string department { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "name")]
        public string jobtitle { get; set; }
        #endregion
        #endregion

        #region Address
        #region Address
        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.Address1)]
        public string address1 { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.Address2)]
        public string address2 { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.ZIP)]
        public string zip { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.City)]
        public string city { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.State)]
        public string state { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.Region)]
        public string region { get; set; }

        [ItemField(SectionFieldType.address, sectionName = "address", fieldName = "address")]
        [AddressComponent(AddressComponentAttribute.AddressPart.Country)]
        public string country { get; set; }
        #endregion

        #region Default phone
        public string defphone_local { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "address")]
        public string defphone { get; set; }
        #endregion

        #region Home phone
        public string homephone_local { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "address")]
        public string homephone { get; set; }
        #endregion

        #region Cell phone
        public string cellphone_local { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "address")]
        public string cellphone { get; set; }
        #endregion

        #region Business phone
        public string busphone_local { get; set; }

        [ItemField(SectionFieldType.phone, sectionName = "address")]
        public string busphone { get; set; }
        #endregion
        #endregion

        #region Internet Details
        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string username { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string reminderq { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string remindera { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string email { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string website { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string icq { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string skype { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string aim { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string yahoo { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
        public string msn { get; set; }

        [ItemField(SectionFieldType.@string, sectionName = "internet")]
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

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Identity;
        }
    }
}
