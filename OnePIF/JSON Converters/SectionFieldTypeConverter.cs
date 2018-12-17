using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class SectionFieldTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SectionFieldType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "string": return SectionFieldType.String;
                case "URL": return SectionFieldType.URL;
                case "email": return SectionFieldType.EMail;
                case "concealed": return SectionFieldType.Concealed;
                case "phone": return SectionFieldType.Phone;
                case "address": return SectionFieldType.Address;
                case "date": return SectionFieldType.Date;
                case "monthYear": return SectionFieldType.MonthYear;
                default: break;
            }

            return SectionFieldType.Unknown;
        }
    }
}
