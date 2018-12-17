using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class GenderConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Gender).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "male":
                    return Gender.Male;
                case "female":
                    return Gender.Female;
                default:
                    break;
            }

            return Gender.Unknown;
        }
    }
}
