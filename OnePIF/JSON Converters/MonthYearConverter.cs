using Newtonsoft.Json;
using System;

namespace OnePIF.Converters
{
    public class MonthYearConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(int).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long monthYear = (long)reader.Value;
            return new DateTime((int)(monthYear / 100), (int)(monthYear % 100), 1, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}
