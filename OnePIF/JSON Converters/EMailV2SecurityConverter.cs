using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class EMailV2SecurityConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(EMailV2Security).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing e-mail security. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "none": return EMailV2Security.None;
                case "SSL": return EMailV2Security.SSL;
                case "TLS": return EMailV2Security.TLS;
                default: break;
            }

            return EMailV2Security.Unknown;
        }
    }
}
