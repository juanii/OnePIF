using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class WirelessSecurityConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(WirelessSecurity).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "none":
                    return WirelessSecurity.None;
                case "wpa2p":
                    return WirelessSecurity.WPA2Personal;
                case "wpa2e":
                    return WirelessSecurity.WPA2Enterprise;
                case "wpa":
                    return WirelessSecurity.WPA;
                case "wep":
                    return WirelessSecurity.WEP;
                default:
                    break;
            }

            return WirelessSecurity.Unknown;
        }
    }
}
