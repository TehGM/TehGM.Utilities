using System;
using System.ComponentModel;
using System.Globalization;

namespace TehGM.Utilities.ComponentModel
{
    /// <summary>Provides a type converter to convert <see cref="Base64Guid"/> objects to and from various other representations.</summary>
    public class Base64GuidConverter : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(Guid) || sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(Guid) || destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        /// <inheritdoc/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is Guid guid)
                return new Base64Guid(guid);
            if (value is string str)
                return Base64Guid.Parse(str);
            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            Base64Guid b64guid = (Base64Guid)value;
            if (destinationType == typeof(Guid))
                return b64guid.Value;
            if (destinationType == typeof(string))
                return b64guid.ToString();
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
