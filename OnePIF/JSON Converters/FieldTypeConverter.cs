using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class FieldTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(FieldType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing field type. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "T": return FieldType.Text;
                case "P": return FieldType.Password;
                case "E": return FieldType.Email;
                case "R": return FieldType.Radio;
                case "N": return FieldType.Number;
                case "TEL": return FieldType.Telephone;
                case "C": return FieldType.Checkbox;
                case "U": return FieldType.URL;
                default: break;
            }

            return FieldType.Unknown;
        }
    }
}
