using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class EMailV2AuthenticationConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(EMailV2Authentication).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing e-mail authentication. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "none": return EMailV2Authentication.None;
                case "password": return EMailV2Authentication.Password;
                case "md5_challenge_response": return EMailV2Authentication.MD5ChallengeResponse;
                case "kerberized_pop": return EMailV2Authentication.KerberizedPop;
                case "kerberos_v4": return EMailV2Authentication.KerberosV4;
                case "kerberos_v5": return EMailV2Authentication.KerberosV5;
                case "ntlm": return EMailV2Authentication.NTLM;
                default: break;
            }

            return EMailV2Authentication.Unknown;
        }
    }
}
