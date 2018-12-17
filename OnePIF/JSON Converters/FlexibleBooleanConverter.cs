using Newtonsoft.Json;
using System;

namespace OnePIF.Converters
{
    public class FlexibleBooleanConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(bool).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String && reader.TokenType != JsonToken.Integer)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing Bool. Expected String, got {0}.", reader.TokenType));
            }

            bool value = false;

            if (reader.TokenType == JsonToken.String)
            {
                long integralValue;

                if (long.TryParse((string)reader.Value, out integralValue))
                {
                    value = integralValue != 0;
                }
                else
                {
                    switch (((string)reader.Value).ToLower())
                    {
                        case "true":
                        case "t":
                        case "on":
                        case "yes":
                        case "y":
                            value = true;
                            break;
                        case "false":
                        case "f":
                        case "off":
                        case "no":
                        case "n":
                            value = false;
                            break;
                        default:
                            throw new JsonSerializationException(string.Format("Cannot convert invalid value to {0}.", objectType));
                    }
                }
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                value = (long)reader.Value != 0;
            }

            return value;
        }
    }
}
