namespace TehGM.Utilities.Randomization
{
    /// <summary>Manages and allows retrieving of <see cref="IRandomizer"/> instances.</summary>
    public interface IRandomizerProvider
    {
        /// <summary>Get default, shared randomizer.</summary>
        /// <returns>Randomizer instance.</returns>
        IRandomizer GetSharedRandomizer();
        /// <summary>Creates a new randomizer service with a specific starting seed.</summary>
        /// <param name="seed">Starting seed.</param>
        /// <returns>New randomizer instance.</returns>
        IRandomizer GetRandomizerWithSeed(RandomSeed seed);
    }
}
