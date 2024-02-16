namespace TehGM.Utilities.Randomization
{
    /// <summary>Represents random number generator as a service.</summary>
    public interface IRandomizer
    {
        /// <summary>Gets a random 32-bit integer.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="inclusive">Whether <paramref name="max"/> is inclusive.</param>
        /// <returns>A randomly generated number.</returns>
        int GetRandomNumber(int min, int max, bool inclusive = false);
        /// <summary>Gets a random double.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <returns>A randomly generated number.</returns>
        double GetRandomNumber(double min, double max);
#if NET6_0_OR_GREATER
        /// <summary>Gets a random 64-bit integer.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="inclusive">Whether <paramref name="max"/> is inclusive.</param>
        /// <returns>A randomly generated number.</returns>
        long GetRandomNumber(long min, long max, bool inclusive = false);
        /// <summary>Gets a random float.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <returns>A randomly generated number.</returns>
        float GetRandomNumber(float min, float max);
#endif
    }
}
