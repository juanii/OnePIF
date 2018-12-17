using Newtonsoft.Json;
using System;

namespace OnePIF.Converters
{
    public class UnixEpochConverter : JsonConverter
    {
        private static readonly long MillisecondsThreshold = 99999999999L;
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTime).Equals(objectType) || typeof(long).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long timestamp = (long)reader.Value;

            if (timestamp > MillisecondsThreshold)
                return UnixEpoch.AddMilliseconds(timestamp);
            else
                return UnixEpoch.AddSeconds(timestamp);
        }
    }
}
