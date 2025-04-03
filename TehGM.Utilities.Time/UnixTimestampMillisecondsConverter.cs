using System;
using System.ComponentModel;
using System.Globalization;

namespace TehGM.Utilities.ComponentModel
{
    /// <summary>Provides a type converter to convert <see cref="UnixTimestampMilliseconds"/> objects to and from various other representations.</summary>
    public class UnixTimestampMillisecondsConverter : TypeConverter
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
                return new UnixTimestampMilliseconds(dt);
            if (value is DateTimeOffset dto)
                return new UnixTimestampMilliseconds(dto);
            if (value is long number64)
                return new UnixTimestampMilliseconds(number64);
            if (value is int number32)
                return new UnixTimestampMilliseconds(number32);
            if (value is string str)
                return UnixTimestampMilliseconds.Parse(str, culture);
            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            UnixTimestampMilliseconds timestamp = (UnixTimestampMilliseconds)value;
            if (destinationType == typeof(DateTime))
                return timestamp.ToDateTime();
            if (destinationType == typeof(DateTimeOffset))
                return timestamp.ToDateTimeOffset();
            if (destinationType == typeof(long))
                return timestamp.Value;
            if (destinationType == typeof(string))
                return timestamp.ToString();
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static bool IsSupportedType(Type type)
            => type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(long) || type == typeof(string);
    }
}
