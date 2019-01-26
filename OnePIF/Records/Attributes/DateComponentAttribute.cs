using System;
using System.Collections.Generic;

namespace OnePIF.Records
{
    public class DateComponentAttribute : Attribute
    {
        public enum DatePart
        {
            Day,
            Month,
            Year
        }

        public DatePart datePart { get; }

        public DateComponentAttribute(DatePart datePart)
        {
            this.datePart = datePart;
        }
    }
}
