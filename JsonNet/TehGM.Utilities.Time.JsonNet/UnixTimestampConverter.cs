using System;
using TehGM.Utilities;

namespace Newtonsoft.Json.Converters
{
    /// <summary>A JSON converter that can convert <see cref="UnixTimestamp"/>, <see cref="DateTime"/> and <see cref="DateTimeOffset"/> into unix timestamp representation.</summary>
    /// <example><code>
    /// [JsonConverter(typeof(UnixTimestampConverter))]
    /// public UnixTimestamp Timestamp { get; set; }
    /// [JsonConverter(typeof(UnixTimestampConverter))]
    /// public DateTime DateTime { get; set; }
    /// [JsonConverter(typeof(UnixTimestampConverter))]
    /// public DateTimeOffset DateTimeOffset { get; set; }
    /// </code></example>
    public class UnixTimestampConverter : DateTimeConverterBase
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(UnixTimestamp) || objectType == typeof(UnixTimestamp?))
                return true;

            return base.CanConvert(objectType);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else if (value is UnixTimestamp ut)
                writer.WriteValue(ut.Value);
            else if (value is DateTime dt)
                writer.WriteValue(new UnixTimestamp(dt).Value);
            else if (value is DateTimeOffset dto)
                writer.WriteValue(new UnixTimestamp(dto).Value);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            UnixTimestamp ut = new UnixTimestamp((long)reader.Value);
            if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
                return ut.ToDateTimeOffset();
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
                return ut.ToDateTime();
            return ut;
        }
    }
}
