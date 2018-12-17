using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class CreditCardTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(CreditCardType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing credit card type. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "mc": return CreditCardType.MasterCard;
                case "visa": return CreditCardType.Visa;
                case "amex": return CreditCardType.AmericanExpress;
                case "diners": return CreditCardType.DinersClub;
                case "carteblanche": return CreditCardType.CarteBlanche;
                case "discover": return CreditCardType.Discover;
                case "jcb": return CreditCardType.JCB;
                case "maestro": return CreditCardType.Maestro;
                case "visaelectron": return CreditCardType.VisaElectron;
                case "laser": return CreditCardType.Laser;
                case "unionpay": return CreditCardType.UnionPay;
                default: break;
            }

            return CreditCardType.Unknown;
        }
    }
}
