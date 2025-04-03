using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using TehGM.Utilities.ComponentModel;

namespace TehGM.Utilities
{
    /// <summary>Represents an unix timestamp (seconds only).</summary>
    [DebuggerDisplay("{Value,nq}")]
    [TypeConverter(typeof(UnixTimestampConverter))]
    public struct UnixTimestamp : IEquatable<UnixTimestamp>, IEquatable<long>, IEquatable<DateTime>, IEquatable<DateTimeOffset>, 
        IComparable<UnixTimestamp>, IComparable<DateTime>, IComparable<DateTimeOffset>, IComparable<long>, IConvertible
#if NET7_0_OR_GREATER
        , IParsable<UnixTimestamp>, ISpanParsable<UnixTimestamp>
#endif
    {
        /// <summary>DateTime value of Unix Epoch.</summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTimeOffset _epochOffset = new DateTimeOffset(Epoch);

        /// <summary>Seconds value of the timestamp.</summary>
        public long Value { get; }

        /// <summary>Creates a new unix timestamp.</summary>
        /// <param name="value">Raw value of the timestamp.</param>
        public UnixTimestamp(long value)
        {
            this.Value = value;
        }

        /// <summary>Creates a new unix timestamp.</summary>
        /// <param name="value">DateTime to get unix timestamp from.</param>
        public UnixTimestamp(DateTime value)
        {
            double seconds = ((DateTime)value - Epoch).TotalSeconds;
            this.Value = (long)seconds;
        }

        /// <summary>Creates a new unix timestamp.</summary>
        /// <param name="value">DateTimeOffset to get unix timestamp from.</param>
        public UnixTimestamp(DateTimeOffset value)
        {
            this.Value = value.ToUnixTimeSeconds();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is UnixTimestamp ut)
                return this.Equals(ut);
            if (obj is DateTime dt)
                return this.Equals(dt);
            if (obj is DateTimeOffset dto)
                return this.Equals(dto);
            if (obj is long value)
                return this.Equals(value);
            return false;
        }

        /// <summary>Converts the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">String representation of UnixTimestamp.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>Parsed UnixTimestamp value.</returns>
        public static UnixTimestamp Parse(string value)
            => Parse(value, null);

        /// <summary>Converts the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">String representation of UnixTimestamp.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>Parsed UnixTimestamp value.</returns>
        public static UnixTimestamp Parse(string value, IFormatProvider provider)
        {
            long numberValue = long.Parse(value, provider);
            return new UnixTimestamp(numberValue);
        }

#if NET7_0_OR_GREATER
        /// <summary>Converts the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">The span of characters to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>Parsed UnixTimestamp value.</returns>
        public static UnixTimestamp Parse(ReadOnlySpan<char> value, IFormatProvider provider)
        {
            long numberValue = long.Parse(value, provider);
            return new UnixTimestamp(numberValue);
        }
#endif

        /// <summary>Attempts to convert the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">String representation of UnixTimestamp.</param>
        /// <param name="result">Parsed UnixTimestamp value.</param>
        public static bool TryParse(string value, out UnixTimestamp result)
        {
            if (long.TryParse(value, out long numberValue))
            {
                result = new UnixTimestamp(numberValue);
                return true;
            }
            result = default;
            return false;
        }

        /// <summary>Attempts to convert the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">String representation of UnixTimestamp.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <param name="result">Parsed UnixTimestamp value.</param>
        public static bool TryParse(string value, IFormatProvider provider, out UnixTimestamp result)
        {

#if NET7_0_OR_GREATER
            if (long.TryParse(value, provider, out long numberValue))
#else

            if (long.TryParse(value, System.Globalization.NumberStyles.Integer, provider, out long numberValue))
#endif
            {
                result = new UnixTimestamp(numberValue);
                return true;
            }
            result = default;
            return false;
        }

#if NET7_0_OR_GREATER
        /// <summary>Attempts to convert the string representation of a UnixTimestamp or Int64 to a UnixTimestamp instance.</summary>
        /// <param name="value">The span of characters to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <param name="result">Parsed UnixTimestamp value.</param>
        public static bool TryParse(ReadOnlySpan<char> value, IFormatProvider provider, [MaybeNullWhen(false)] out UnixTimestamp result)
        {
            if (long.TryParse(value, provider, out long numberValue))
            {
                result = new UnixTimestamp(numberValue);
                return true;
            }
            result = default;
            return false;
        }
#endif

        /// <inheritdoc/>
        public bool Equals(UnixTimestamp other)
            => this.Equals(other.Value);

        /// <inheritdoc/>
        public bool Equals(long other)
            => this.Value.Equals(other);

        /// <inheritdoc/>
        public bool Equals(DateTime other)
            => this.Equals(new UnixTimestamp(other));

        /// <inheritdoc/>
        public bool Equals(DateTimeOffset other)
            => this.Equals(new UnixTimestamp(other));

        /// <inheritdoc/>
        public override int GetHashCode()
            => -1937169414 + this.Value.GetHashCode();

        /// <summary>Gets DateTime value of the timestamp.</summary>
        public DateTime ToDateTime()
            => Epoch.AddSeconds(this.Value);
        /// <summary>Gets DateTimeOffset value of the timestamp.</summary>
        public DateTimeOffset ToDateTimeOffset()
            => _epochOffset.AddSeconds(this.Value);

        /// <inheritdoc/>
        public static bool operator ==(UnixTimestamp left, UnixTimestamp right)
            => left.Equals(right);

        /// <inheritdoc/>
        public static bool operator !=(UnixTimestamp left, UnixTimestamp right)
            => !(left == right);

        /// <summary>Creates a new unix timestamp.</summary>
        /// <param name="value">DateTime to get unix timestamp from.</param>
        public static explicit operator UnixTimestamp(DateTime value)
            => new UnixTimestamp(value);
        /// <summary>Creates a new unix timestamp.</summary>
        /// <param name="value">DateTimeOffset to get unix timestamp from.</param>
        public static explicit operator UnixTimestamp(DateTimeOffset value)
            => new UnixTimestamp(value);

        /// <summary>Gets DateTime value of the timestamp.</summary>
        /// <param name="value">Unix timestamp.</param>
        public static implicit operator DateTime(UnixTimestamp value)
            => value.ToDateTime();
        /// <summary>Gets DateTimeOffset value of the timestamp.</summary>
        /// <param name="value">Unix timestamp.</param>
        public static implicit operator DateTimeOffset(UnixTimestamp value)
            => value.ToDateTimeOffset();

        /// <inheritdoc/>
        public override string ToString()
            => this.Value.ToString();

#region IComparable
        /// <inheritdoc/>
        public int CompareTo(long other)
            => this.Value.CompareTo(other);

        /// <inheritdoc/>
        public int CompareTo(DateTime other)
            => this.ToDateTime().CompareTo(other);

        /// <inheritdoc/>
        public int CompareTo(UnixTimestamp other)
            => this.Value.CompareTo(other.Value);

        /// <inheritdoc/>
        public int CompareTo(DateTimeOffset other)
            => this.ToDateTimeOffset().CompareTo(other);
#endregion

#region IConvertible
        /// <inheritdoc/>
        TypeCode IConvertible.GetTypeCode()
            => TypeCode.Int64;
        /// <inheritdoc/>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
            => this.ToDateTime();
        /// <inheritdoc/>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
            => this.Value;
        /// <inheritdoc/>
        double IConvertible.ToDouble(IFormatProvider provider)
            => this.Value;
        /// <inheritdoc/>
        float IConvertible.ToSingle(IFormatProvider provider)
            => this.Value;
        /// <inheritdoc/>
        string IConvertible.ToString(IFormatProvider provider)
            => this.ToString();
        /// <inheritdoc/>
        long IConvertible.ToInt64(IFormatProvider provider)
            => this.Value;
        /// <inheritdoc/>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
            => (ulong)this.Value;
        /// <inheritdoc/>
        bool IConvertible.ToBoolean(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(Boolean).FullName}");
        /// <inheritdoc/>
        byte IConvertible.ToByte(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(Byte).FullName}");
        /// <inheritdoc/>
        char IConvertible.ToChar(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(Char).FullName}");
        /// <inheritdoc/>
        short IConvertible.ToInt16(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(Int16).FullName}");
        /// <inheritdoc/>
        int IConvertible.ToInt32(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(Int32).FullName}");
        /// <inheritdoc/>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(SByte).FullName}");
        /// <inheritdoc/>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(UInt16).FullName}");
        /// <inheritdoc/>
        uint IConvertible.ToUInt32(IFormatProvider provider)
            => throw new InvalidCastException($"Cannot cast {this.GetType().FullName} to {typeof(UInt32).FullName}");

        /// <inheritdoc/>
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType.IsAssignableFrom(this.GetType()))
                return this;
            return Convert.ChangeType(this.Value, conversionType);
        }
#endregion
    }
}
