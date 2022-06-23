using System;

namespace TehGM.Utilities.Randomization
{
    /// <summary>Represents a seed for random number generators such as <see cref="Random"/>.</summary>
    /// <remarks>Hash code in later versions on .NET is deterministic only in one application domain.
    /// This means that every time you run the application, the same string seed can generate different set of values.
    /// Depending on use case, this may defeat using string as seed for whatever random operation required.<br/>
    /// This wrapper is designed to solve this issue and provide cross app domain deterministic hashcode for string values.</remarks>
    public struct RandomSeed : IEquatable<RandomSeed>, IEquatable<int>
    {
        /// <summary>The seed's value.</summary>
        public int Value { get; }

        /// <summary>Creates a new seed value from given integer.</summary>
        /// <param name="value">Seed value.</param>
        public RandomSeed(int value)
        {
            this.Value = value;
        }

        /// <summary>Retrieves seed's value.</summary>
        /// <param name="seed">The seed.</param>
        public static implicit operator int(RandomSeed seed)
            => seed.Value;
        /// <summary>Creates a new seed value from given integer.</summary>
        /// <param name="seed">Seed value.</param>
        public static implicit operator RandomSeed(int seed)
            => new RandomSeed(seed);
        /// <summary>Creates a new seed value from given string.</summary>
        /// <param name="seed">Seed value.</param>
        public static explicit operator RandomSeed(string seed)
            => FromString(seed, false);

        /// <summary>Creates a new seed value from given string.</summary>
        /// <param name="seed">Seed value.</param>
        /// <param name="caseInsensitive">Whether given seed should ignore the character casing for seed value computation.</param>
        /// <returns>New random seed.</returns>
        public static RandomSeed FromString(string seed, bool caseInsensitive = false)
        {
            if (caseInsensitive)
                seed = seed.ToLowerInvariant();

            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < seed.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ seed[i];
                    if (i == seed.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ seed[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        /// <inheritdoc/>
        public bool Equals(RandomSeed other)
            => this.Equals(other.Value);
        /// <inheritdoc/>
        public bool Equals(int other)
            => this.Value.Equals(other);
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is RandomSeed seed)
                return this.Equals(seed);
            if (obj is int value)
                return this.Equals(value);
            if (obj is string stringValue)
                return this.Equals(FromString(stringValue));
            return false;
        }

        /// <inheritdoc/>
        public static bool operator ==(RandomSeed left, RandomSeed right)
            => left.Equals(right);
        /// <inheritdoc/>
        public static bool operator !=(RandomSeed left, RandomSeed right)
            => !(left == right);

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Value.GetHashCode();
        /// <inheritdoc/>
        public override string ToString()
            => this.Value.ToString();
    }
}
