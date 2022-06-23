using TehGM.Utilities.Random.Services;

namespace TehGM.Utilities.Random.Tests
{
    [TestFixture]
    [TestOf(typeof(RandomizerProvider))]
    public class RandomizerProviderTests : TestBase
    {
        [Test]
        [Category(nameof(RandomizerProvider.GetSharedRandomizer))]
        public void GetSharedRandomizer_ShouldReturnSameRandomizer()
        {
            RandomizerProvider provider = new RandomizerProvider();

            IRandomizer result1 = provider.GetSharedRandomizer();
            IRandomizer result2 = provider.GetSharedRandomizer();

            result1.Should().NotBeNull();
            result1.Should().Be(result2);
        }

        [Test]
        [Category(nameof(RandomizerProvider.GetRandomizerWithSeed))]
        public void GetRandomizerWithSeed_ShouldReturnDifferentRandomizer()
        {
            RandomizerProvider provider = new RandomizerProvider();

            IRandomizer result1 = provider.GetRandomizerWithSeed(1);
            IRandomizer result2 = provider.GetRandomizerWithSeed(2);

            result1.Should().NotBeNull();
            result2.Should().NotBeNull();
            result1.Should().NotBe(result2);
        }
    }
}
