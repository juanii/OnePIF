using Newtonsoft.Json;
using System;

namespace OnePIF.Converters
{
    public class UUIDConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Guid).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string idString = (string)reader.Value;

            // Newer 1pif formats contain a (seemingly) Base32 encoded UUID
            if (idString.Length == Base32.EncodedSize(16))
                return new Guid(Base32.Decode(idString));
            else
                return new Guid((string)reader.Value);
        }
    }
}
