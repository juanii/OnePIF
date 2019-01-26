using System;

namespace OnePIF.Records
{
    public class MonthYearComponentAttribute : Attribute
    {
        public enum MonthYearPart
        {
            Month,
            Year
        }

        public MonthYearPart monthYearPart { get; }

        public MonthYearComponentAttribute(MonthYearPart monthYearPart)
        {
            this.monthYearPart = monthYearPart;
        }
    }
}
