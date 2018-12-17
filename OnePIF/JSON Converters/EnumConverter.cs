using Newtonsoft.Json;
using System;

namespace OnePIF.Converters
{
    public class EnumConverter<T> : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing enum. Expected String, got {0}.", reader.TokenType));
            }

            if (Enum.IsDefined(typeof(T), (string)reader.Value))
            {
                return Enum.Parse(typeof(T), (string)reader.Value);
            }

            return Enum.Parse(typeof(T), "-1");
        }
    }
}
