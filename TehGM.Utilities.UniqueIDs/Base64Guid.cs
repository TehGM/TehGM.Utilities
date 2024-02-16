using System;
using System.ComponentModel;
using TehGM.Utilities.ComponentModel;
#if NET7_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Buffers.Text;
#endif

namespace TehGM.Utilities
{
    /// <summary>A wrapper for <see cref="Guid"/> that allows displaying value in a 22 character URL-friendly string. Collission of this Unique ID is very unlikely.</summary>
    [TypeConverter(typeof(Base64GuidConverter))]
    public struct Base64Guid : IEquatable<Base64Guid>, IEquatable<Guid>, IEquatable<string>
#if NET7_0_OR_GREATER
        , IParsable<Base64Guid>, ISpanParsable<Base64Guid>
#endif
    {
        private const int _trimmedLength = 22;
        private const int _untrimmedLength = 24;

        /// <summary>The actual GUID value.</summary>
        public Guid Value => this._value;
        private Guid _value;

        /// <summary>Wraps GUID into a new Base64Guid.</summary>
        /// <param name="value">Actual GUID value.</param>
        public Base64Guid(Guid value)
        {
            this._value = value;
        }

        /// <summary>Creates a Base64Guid from a display value.</summary>
        /// <param name="value">Display value of the GUID.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        [Obsolete("Use Parse method instead.")]
        public Base64Guid(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            value = value.Trim();
            if (!IsLengthValid(value.Length))
                throw new FormatException("A valid DisplayGuid string is either 22 or 24 characters long");

            this._value = ConvertStringToGuid(value);
        }

#if NET7_0_OR_GREATER
        /// <summary>Creates a Base64Guid from a display value.</summary>
        /// <param name="value">Display value of the GUID.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        [Obsolete("Use Parse method instead.")]
        public Base64Guid(ReadOnlySpan<char> value)
        {
            this._value = ConvertStringToGuid(value);
        }
#endif

        /// <summary>Generates a new GUID wrapped into a Base64Guid.</summary>
        /// <returns>A new display guid.</returns>
        public static Base64Guid GenerateNew()
            => new Base64Guid(Guid.NewGuid());

        private static Guid ConvertStringToGuid(string value)
        {
#if NET7_0_OR_GREATER
            return ConvertStringToGuid(value.AsSpan());
#else

            if (!IsLengthValid(value.Length))
                throw new FormatException("A valid Base64Guid string is either 22 or 24 characters long");
            if (value.Length == _trimmedLength)
                value += "==";

            value = value.Replace('-', '+');
            value = value.Replace('_', '/');

            byte[] valueBytes = Convert.FromBase64String(value);
            return new Guid(valueBytes);
#endif
        }

#if NET7_0_OR_GREATER
        // gotta give credit where it's due:
        // span-based implementation heavily based on Nick Chapsas' video
        // https://www.youtube.com/watch?v=B2yOjLyEZk0
        private static Guid ConvertStringToGuid(ReadOnlySpan<char> value)
        {
            if (!IsLengthValid(value.Length))
                throw new FormatException("A valid Base64Guid string is either 22 or 24 characters long");

            Span<char> result = stackalloc char[24];

            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                result[i] = c switch
                {
                    '-' => '+',
                    '_' => '/',
                    _ => c
                };
            }

            result[22] = '=';
            result[23] = '=';

            Span<byte> resultBytes = stackalloc byte[16];
            if (!Convert.TryFromBase64Chars(result, resultBytes, out _))
                throw new FormatException("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.");
            return new Guid(resultBytes);
        }
#endif

        /// <summary>Converts the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>The parsed Base64Guid value.</returns>
        public static Base64Guid Parse(string value)
            => Parse(value, null);

        /// <summary>Converts the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>The parsed Base64Guid value.</returns>
        public static Base64Guid Parse(string value, IFormatProvider provider)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if NET7_0_OR_GREATER
            return Parse(value.AsSpan(), provider);
#else
            value = value.Trim();
            if (!Guid.TryParse(value, out Guid guidResult))
                guidResult = ConvertStringToGuid(value);
            return new Base64Guid(guidResult);
#endif
        }

#if NET7_0_OR_GREATER
        /// <summary>Converts the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">The span of characters to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>The parsed Base64Guid value.</returns>
        public static Base64Guid Parse(ReadOnlySpan<char> value, IFormatProvider provider)
        {
            value = value.Trim();
            if (!Guid.TryParse(value, provider, out Guid guidResult))
                guidResult = ConvertStringToGuid(value);

            return new Base64Guid(guidResult);
    }
#endif

        /// <summary>Attempts to convert the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <param name="result">Display value of the GUID.</param>
        public static bool TryParse(string value, out Base64Guid result)
            => TryParse(value, null, out result);

        /// <summary>Attempts to convert the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <param name="result">Display value of the GUID.</param>
        public static bool TryParse(string value, IFormatProvider provider, out Base64Guid result)
        {
            if (value == null)
            {
                result = default;
                return false;
            }

#if NET7_0_OR_GREATER
            return TryParse(value.AsSpan(), provider, out result);
#else
            if (Guid.TryParse(value, out Guid guidResult))
            {
                result = guidResult;
                return true;
            }
            
            value = value.Trim();
            if (!IsLengthValid(value.Length))
            {
                result = default;
                return false;
            }
            try
            {
                result = Parse(value, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
#endif
        }

#if NET7_0_OR_GREATER
        /// <summary>Attempts to convert the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">The span of characters to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about value.</param>
        /// <param name="result">Display value of the GUID.</param>
        public static bool TryParse(ReadOnlySpan<char> value, IFormatProvider provider, [MaybeNullWhen(false)] out Base64Guid result)
        {
            if (Guid.TryParse(value, provider, out Guid guidResult))
            {
                result = guidResult;
                return true;
            }

            value = value.Trim();
            if (!IsLengthValid(value.Length))
            {
                result = default;
                return false;
            }
            try
            {
                result = Parse(value, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
#endif

        private static bool IsLengthValid(int length)
            => length == _trimmedLength || length == _untrimmedLength;

        // gotta give credit where it's due:
        // span-based implementation heavily based on Nick Chapsas' video
        // https://www.youtube.com/watch?v=B2yOjLyEZk0
        /// <inheritdoc/>
        public override string ToString()
        {
#if NET7_0_OR_GREATER
            Span<byte> valueBytes = stackalloc byte[16];
            Span<byte> resultBytes = stackalloc byte[24];
            Span<char> result = stackalloc char[_trimmedLength];

            MemoryMarshal.TryWrite(valueBytes, ref this._value);
            Base64.EncodeToUtf8(valueBytes, resultBytes, out _, out _);

            for (int i = 0; i < _trimmedLength; i++)
            {
                byte c = resultBytes[i];
                result[i] = c switch
                {
                    (byte)'+' => '-',
                    (byte)'/' => '_',
                    _ => (char)c
                };
            }

            return new string(result);
#else
            string result = Convert.ToBase64String(this.Value.ToByteArray());
            result = result.Remove(_trimmedLength);
            result = result.Replace('+', '-');
            result = result.Replace('/', '_');
            return result;
#endif
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Base64Guid displayGuid)
                return this.Equals(displayGuid);
            if (obj is Guid guid)
                return this.Equals(guid);
            if (obj is string display)
                return this.Equals(display);
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Base64Guid other)
            => this.Equals(other._value);
        /// <inheritdoc/>
        public bool Equals(Guid other)
            => this._value.Equals(other);
        /// <inheritdoc/>
        public bool Equals(string other)
            => this.Equals(Parse(other));
        /// <inheritdoc/>
        public override int GetHashCode()
            => -1937169414 + this._value.GetHashCode();

        /// <inheritdoc/>
        public static bool operator ==(Base64Guid left, Base64Guid right)
            => left.Equals(right);
        /// <inheritdoc/>
        public static bool operator !=(Base64Guid left, Base64Guid right)
            => !(left == right);
        /// <inheritdoc/>
        public static bool operator ==(Base64Guid left, Guid right)
            => left.Equals(right);
        /// <inheritdoc/>
        public static bool operator !=(Base64Guid left, Guid right)
            => !(left == right);
        /// <inheritdoc/>
        public static bool operator ==(Base64Guid left, string right)
            => left.Equals(right);
        /// <inheritdoc/>
        public static bool operator !=(Base64Guid left, string right)
            => !(left == right);

        /// <summary>Converts base64 guid wrapper to a normal guid.</summary>
        /// <param name="value">Normal guid value.</param>
        public static implicit operator Guid(Base64Guid value)
            => value._value;
        /// <summary>Converts base64 guid wrapper to string representation.</summary>
        /// <param name="value">22 character string ID.</param>
        public static implicit operator string(Base64Guid value)
            => value.ToString();
        /// <summary>Converts a standard guid into a base64 wrapper.</summary>
        /// <param name="value">Base64 wrapped guid.</param>
        public static implicit operator Base64Guid(Guid value)
            => new Base64Guid(value);
        /// <summary>Converts string representation ID to base64 guid wrapper.</summary>
        /// <param name="value">Base64 wrapped guid.</param>
        public static implicit operator Base64Guid(string value)
            => Parse(value);
    }
}
