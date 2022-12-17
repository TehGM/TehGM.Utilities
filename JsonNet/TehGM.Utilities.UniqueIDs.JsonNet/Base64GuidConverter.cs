using System;
using TehGM.Utilities;

namespace Newtonsoft.Json.Converters
{
    /// <summary>A JSON converter that can convert <see cref="Base64Guid"/>.</summary>
    /// <example><code>
    /// [JsonConverter(typeof(Base64GuidConverter))]
    /// public Base64Guid ID { get; set; }
    /// </code></example>
    public class Base64GuidConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Base64Guid)
                || objectType == typeof(Base64Guid?);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            Base64Guid result = serializer.Deserialize<Guid>(reader);
            return result;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            Base64Guid guid = (Base64Guid)value;
            serializer.Serialize(writer, guid.Value);
        }
    }
}
