namespace TehGM.Utilities.Randomization.Services
{
    /// <inheritdoc/>
    public class RandomizerService : IRandomizer
    {
        private readonly System.Random _random;

        /// <summary>Creates a new randomizer service.</summary>
        public RandomizerService()
        {
            this._random = new System.Random();
        }

        /// <summary>Creates a new randomizer service with a specific starting seed.</summary>
        /// <param name="seed">Starting seed.</param>
        public RandomizerService(RandomSeed seed)
        {
            this._random = new System.Random(seed);
        }

        /// <inheritdoc/>
        public int GetRandomNumber(int min, int max, bool inclusive)
        {
            max = inclusive ? ++max : max;
            return this._random.Next(min, max);
        }

        /// <inheritdoc/>
        public double GetRandomNumber(double min, double max)
        {
            double range = max - min;
            return min + this._random.NextDouble() * range;
        }

#if NET6_0_OR_GREATER
        /// <inheritdoc/>
        public long GetRandomNumber(long min, long max, bool inclusive)
        {
            max = (inclusive) ? ++max : max;
            return this._random.NextInt64(min, max);
        }

        /// <inheritdoc/>
        public float GetRandomNumber(float min, float max)
        {
            float range = max - min;
            return min + this._random.NextSingle() * range;
        }
#endif
    }
}
