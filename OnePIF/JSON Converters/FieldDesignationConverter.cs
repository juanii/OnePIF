using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class FieldDesignationConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(FieldDesignation).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing field designation. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "username": return FieldDesignation.username;
                case "password": return FieldDesignation.password;
                default: break;
            }

            return FieldDesignation.unknown;
        }
    }
}
