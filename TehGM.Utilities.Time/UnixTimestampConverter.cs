using System;
using System.ComponentModel;
using System.Globalization;

namespace TehGM.Utilities.ComponentModel
{
    /// <summary>Provides a type converter to convert <see cref="UnixTimestamp"/> objects to and from various other representations.</summary>
    public class UnixTimestampConverter : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return IsSupportedType(sourceType) || sourceType == typeof(int) || base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return IsSupportedType(destinationType) || base.CanConvertTo(context, destinationType);
        }

        /// <inheritdoc/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is DateTime dt)
                return new UnixTimestamp(dt);
            if (value is DateTimeOffset dto)
                return new UnixTimestamp(dto);
            if (value is long number64)
                return new UnixTimestamp(number64);
            if (value is int number32)
                return new UnixTimestamp(number32);
            if (value is string str)
                return UnixTimestamp.Parse(str, culture);
            if (value is UnixTimestampMilliseconds)
                return (UnixTimestamp)value;
            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            UnixTimestamp timestamp = (UnixTimestamp)value;
            if (destinationType == typeof(DateTime))
                return timestamp.ToDateTime();
            if (destinationType == typeof(DateTimeOffset))
                return timestamp.ToDateTimeOffset();
            if (destinationType == typeof(long))
                return timestamp.Value;
            if (destinationType == typeof(string))
                return timestamp.ToString();
            if (destinationType == typeof(UnixTimestampMilliseconds))
                return new UnixTimestampMilliseconds(timestamp.Value * 1000);
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static bool IsSupportedType(Type type)
            => type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(long) || type == typeof(string) || type == typeof(UnixTimestampMilliseconds);
    }
}
