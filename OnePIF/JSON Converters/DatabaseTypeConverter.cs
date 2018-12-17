using Newtonsoft.Json;
using OnePIF.Types;
using System;

namespace OnePIF.Converters
{
    class DatabaseTypeConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DatabaseType).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException(string.Format("Unexpected token parsing database type. Expected String, got {0}.", reader.TokenType));
            }

            switch ((string)reader.Value)
            {
                case "db2": return DatabaseType.DB2;
                case "filemaker": return DatabaseType.FileMaker;
                case "msaccess": return DatabaseType.MSAccess;
                case "mssql": return DatabaseType.MSSQL;
                case "mysql": return DatabaseType.MySQL;
                case "oracle": return DatabaseType.Oracle;
                case "postgresql": return DatabaseType.PostgreSQL;
                case "sqlite": return DatabaseType.SQLite;
                case "other": return DatabaseType.Other;
                default: break;
            }

            return DatabaseType.Unknown;
        }
    }
}
