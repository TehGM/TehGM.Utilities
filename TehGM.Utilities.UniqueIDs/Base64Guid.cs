using System;

namespace TehGM.Utilities
{
    /// <summary>A wrapper for <see cref="Guid"/> that allows displaying value in a 22 character URL-friendly string. Collission of this Unique ID is very unlikely.</summary>
    public struct Base64Guid : IEquatable<Base64Guid>, IEquatable<Guid>, IEquatable<string>
    {
        private const int _packedLength = 22;
        private const int _unpackedLength = 24;

        /// <summary>The actual GUID value.</summary>
        public Guid Value { get; }

        /// <summary>Wraps GUID into a new Base64Guid.</summary>
        /// <param name="value">Actual GUID value.</param>
        public Base64Guid(Guid value)
        {
            this.Value = value;
        }

        /// <summary>Creates a Base64Guid from a display value.</summary>
        /// <param name="value">Display value of the GUID.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        public Base64Guid(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            value = value.Trim();
            if (!IsLengthValid(value))
                throw new FormatException("A valid DisplayGuid string is either 22 or 24 characters long");

            value = this.Unpack(value);
            byte[] valueBytes = Convert.FromBase64String(value);
            this.Value = new Guid(valueBytes);
        }

        /// <summary>Generates a new GUID wrapped into a Base64Guid.</summary>
        /// <returns>A new display guid.</returns>
        public static Base64Guid GenerateNew()
            => new Base64Guid(Guid.NewGuid());

        private string Unpack(string value)
        {
            if (value.Length == _packedLength)
                value += "==";

            value = value.Replace('-', '+');
            value = value.Replace('_', '/');

            return value;
        }

        private string Pack(string value)
        {
            if (value.Length == _unpackedLength)
                value = value.Remove(_packedLength);

            value = value.Replace('+', '-');
            value = value.Replace('/', '_');

            return value;
        }

        /// <summary>Converts the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <exception cref="ArgumentNullException">Given value is null.</exception>
        /// <exception cref="FormatException">Given value is in invalid format.</exception>
        /// <returns>The parsed</returns>
        public static Base64Guid Parse(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            value = value.Trim();
            if (Guid.TryParse(value, out Guid result))
                return result;

            return new Base64Guid(value);
        }

        /// <summary>Attempts to convert the string representation of a Guid or Base64Guid to a Base64Guid instance.</summary>
        /// <param name="value">String representation of a Guid or Base64Guid.</param>
        /// <param name="result">Display value of the GUID.</param>
        public static bool TryParse(string value, out Base64Guid result)
        {
            value = value?.Trim();
            if (Guid.TryParse(value, out Guid guidResult))
            {
                result = guidResult;
                return true;
            }

            if (!IsLengthValid(value))
                return false;
            try
            {
                result = Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsLengthValid(string value)
            => value != null && (value.Length == _packedLength || value.Length == _unpackedLength);

        /// <inheritdoc/>
        public override string ToString()
        {
            string result = Convert.ToBase64String(this.Value.ToByteArray());
            result = this.Pack(result);
            return result;
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
            => this.Equals(other.Value);
        /// <inheritdoc/>
        public bool Equals(Guid other)
            => this.Value.Equals(other);
        /// <inheritdoc/>
        public bool Equals(string other)
            => this.Equals(new Base64Guid(other));
        /// <inheritdoc/>
        public override int GetHashCode()
            => -1937169414 + this.Value.GetHashCode();

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
            => value.Value;
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
            => new Base64Guid(value);
    }
}
