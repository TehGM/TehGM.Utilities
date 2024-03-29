﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TehGM.Utilities.Randomization
{
    /// <summary>Extensions for <see cref="Random"/>.</summary>
    public static class RandomExtensions
    {
        /// <summary>Gets one random value from the provided enumerable.</summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="random"><see cref="Random"/> instance to use for generating random index.</param>
        /// <param name="values">Enumerable of all values.</param>
        /// <returns></returns>
        public static T GetRandomValue<T>(this Random random, IEnumerable<T> values)
        {
            ThrowIfNullOrEmpty(values);
            int max = values.Count();
            int index = random.Next(0, max);
            return values.ElementAt(index);
        }

        /// <summary>Gets a random chance value, 0 for 0%, 1 for 100%.</summary>
        /// <param name="random"><see cref="Random"/> instance to use to generate the value.</param>
        /// <returns>Random value between 0.0 and 1.0.</returns>
        public static double GetRandomChance(this Random random)
            => random.NextDouble();

        /// <summary>Returns true or false based on given chance.</summary>
        /// <param name="random"><see cref="Random"/> instance to use to generate the value.</param>
        /// <param name="chance">Chance of true outcome. Any value below 0.0 for 0% chance, 1.0 for 100% chance.</param>
        /// <returns>True if rolled value is below <paramref name="chance"/>; otherwise false.</returns>
        public static bool RollChance(this Random random, double chance)
            => random.GetRandomChance() <= chance;

        /// <summary>Returns a random boolean value. Both true or false have equal chance.</summary>
        /// <param name="random"><see cref="Random"/> instance to use to generate the value.</param>
        /// <returns>True or false, depending on the generated RNG.</returns>
        public static bool GetRandomBoolean(this Random random)
            => random.RollChance(0.5);

        /// <summary>Gets a random value of an enum.</summary>
        /// <typeparam name="T">Type of the enum.</typeparam>
        /// <param name="random"><see cref="Random"/> instance to use to generate the value.</param>
        /// <returns>A random value picked from all declared values in the enum.</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum.</exception>
        public static T GetRandomEnumValue<T>(this Random random) where T : struct, Enum
        {
            Type t = typeof(T);
            if (!t.IsEnum)
                throw new InvalidOperationException($"{nameof(GetRandomEnumValue)} can only be used on enums. {t.Name} is not an enum");
#if NET5_0_OR_GREATER
            T[] values = Enum.GetValues<T>();
#else
            IEnumerable<T> values = Enum.GetValues(t).Cast<T>();
#endif
            return random.GetRandomValue(values);
        }

        /// <summary>Builds a random string of given length using specified characters.</summary>
        /// <param name="random"><see cref="Random"/> instance to use to generate the string.</param>
        /// <param name="length">Length of the randomly generated string.</param>
        /// <param name="charset">Set of characters to use when generating the string.</param>
        /// <returns>A randomy generated string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Requested length is invalid.</exception>
        /// <exception cref="ArgumentNullException">Random instance or charset are null.</exception>
        /// <exception cref="ArgumentException">Charset is empty.</exception>
        public static string GetRandomString(this Random random, int length, string charset = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890")
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Random string length cannot be less than 0.");
            if (charset == null)
                throw new ArgumentNullException(nameof(charset));
            if (charset.Length == 0)
                throw new ArgumentException("Charset cannot be empty.", nameof(charset));
            if (length == 0)
                return string.Empty;

#if NET7_0_OR_GREATER
            Span<char> chars = stackalloc char[length];
#else
            char[] chars = new char[length];
#endif
            for (int i = 0; i < length; i++)
                chars[i] = charset[random.Next(0, charset.Length)];

            return new string(chars);
        }

        private static void ThrowIfNullOrEmpty<T>(IEnumerable<T> values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (!values.Any())
                throw new ArgumentException("Values set must contain at least one value.", nameof(values));
        }
    }
}
