namespace TehGM.Utilities.Random.Services
{
    /// <inheritdoc/>
    public class RandomizerProvider : IRandomizerProvider
    {
        private readonly IRandomizer _sharedRandomizer;

        /// <summary>Creates a new randomizer provider.</summary>
        /// <remarks>It'll also create a new shared randomizer for this provider.</remarks>
        public RandomizerProvider()
        {
            this._sharedRandomizer = new RandomizerService();
        }

        /// <inheritdoc/>
        public IRandomizer GetSharedRandomizer()
            => this._sharedRandomizer;

        /// <inheritdoc/>
        public IRandomizer GetRandomizerWithSeed(RandomSeed seed)
            => new RandomizerService(seed);
    }
}
