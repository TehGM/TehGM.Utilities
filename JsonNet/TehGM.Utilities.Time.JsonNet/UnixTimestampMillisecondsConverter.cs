using System;
using TehGM.Utilities;

namespace Newtonsoft.Json.Converters
{
    /// <summary>A JSON converter that can convert <see cref="UnixTimestampMilliseconds"/>, <see cref="DateTime"/> and <see cref="DateTimeOffset"/> into unix timestamp representation (with milliseconds).</summary>
    /// <example><code>
    /// [JsonConverter(typeof(UnixTimestampMillisecondsConverter))]
    /// public UnixTimestampMilliseconds Timestamp { get; set; }
    /// [JsonConverter(typeof(UnixTimestampMillisecondsConverter))]
    /// public DateTime DateTime { get; set; }
    /// [JsonConverter(typeof(UnixTimestampMillisecondsConverter))]
    /// public DateTimeOffset DateTimeOffset { get; set; }
    /// </code></example>
    public class UnixTimestampMillisecondsConverter : DateTimeConverterBase
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(UnixTimestampMilliseconds) || objectType == typeof(UnixTimestampMilliseconds?))
                return true;

            return base.CanConvert(objectType);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else if (value is UnixTimestampMilliseconds ut)
                writer.WriteValue(ut.Value);
            else if (value is DateTime dt)
                writer.WriteValue(new UnixTimestampMilliseconds(dt).Value);
            else if (value is DateTimeOffset dto)
                writer.WriteValue(new UnixTimestampMilliseconds(dto).Value);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            UnixTimestampMilliseconds ut = new UnixTimestampMilliseconds((long)reader.Value);
            if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
                return ut.ToDateTimeOffset();
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
                return ut.ToDateTime();
            return ut;
        }
    }
}
