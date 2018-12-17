using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnePIF.Records;
using System;

namespace OnePIF.Converters
{
    public class SectionFieldConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SectionField).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonRecord = JObject.Load(reader);

            SectionField sectionField = createSectionField((string)jsonRecord.Property("k"));
            serializer.Populate(jsonRecord.CreateReader(), sectionField);

            return sectionField;
        }

        private SectionField createSectionField(string fieldKind)
        {
            switch (fieldKind)
            {
                case "string":
                case "cctype":
                case "URL":
                case "email":
                case "concealed":
                case "phone":
                case "menu":
                case "gender":
                    return new GeneralSectionField();
                case "address":
                    return new AddressSectionField();
                case "date":
                    return new DateSectionField();
                case "monthYear":
                    return new MonthYearSectionField();
                default:
                    break;
            }

            return new GeneralSectionField();
        }
    }
}
