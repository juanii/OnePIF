using System;

namespace OnePIF.Records
{
    public class AddressComponentAttribute : Attribute
    {
        public enum AddressPart
        {
            Address1,
            Address2,
            ZIP,
            City,
            State,
            Region,
            Country
        }

        public AddressPart addressPart { get; }

        public AddressComponentAttribute(AddressPart addressPart)
        {
            this.addressPart = addressPart;
        }
    }
}
