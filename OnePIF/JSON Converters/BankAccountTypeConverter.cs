using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class BankAccountTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(BankAccountType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing bank account type. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "checking":
                    return BankAccountType.Checking;
                case "savings":
                    return BankAccountType.Savings;
                case "loc":
                    return BankAccountType.LineOfCredit;
                case "atm":
                    return BankAccountType.ATM;
                case "money_market":
                    return BankAccountType.MoneyMarket;
                case "other":
                    return BankAccountType.Other;
                default:
                    break;
            }

            return BankAccountType.Unknown;
        }
    }
}
