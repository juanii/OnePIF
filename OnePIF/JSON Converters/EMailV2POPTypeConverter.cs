using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class EMailV2POPTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(EMailV2POPType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing e-mail POP type. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "pop3": return EMailV2POPType.POP3;
                case "imap": return EMailV2POPType.IMAP;
                case "either": return EMailV2POPType.Either;
                default: break;
            }

            return EMailV2POPType.Unknown;
        }
    }
}
