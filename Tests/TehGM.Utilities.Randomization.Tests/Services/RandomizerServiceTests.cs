using TehGM.Utilities.Randomization.Services;

namespace TehGM.Utilities.Randomization.Tests
{
    [TestFixture]
    [TestOf(typeof(RandomizerService))]
    public class RandomizerServiceTests : TestBase
    {
        [Test]
        [Repeat(10)]
        [Category(nameof(RandomizerService.GetRandomNumber))]
        public void GetRandomNumber_Int32_WithinSpecifiedRange()
        {
            int min = 2;
            int max = 4;
            RandomizerService randomizer = new RandomizerService();

            int result = randomizer.GetRandomNumber(min, max, true);

            result.Should().BeGreaterThanOrEqualTo(min);
            result.Should().BeLessThanOrEqualTo(max);
        }

        [Test]
        [Repeat(10)]
        [Category(nameof(RandomizerService.GetRandomNumber))]
        public void GetRandomNumber_Double_WithinSpecifiedRange()
        {
            double min = 2.0;
            double max = 4.0;
            RandomizerService randomizer = new RandomizerService();

            double result = randomizer.GetRandomNumber(min, max);

            result.Should().BeGreaterThanOrEqualTo(min);
            result.Should().BeLessThanOrEqualTo(max);
        }

        [Test]
        [TestCase(123, 10, 9, 8)]
        [TestCase(321, 4, 0, 1)]
        [TestCase(12345678, 4, 6, 4)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_WithGivenSeed_OutputsSameSequence(int seed, int expectedResult1, int expectedResult2, int expectedResult3)
        {
            int min = 0;
            int max = 10;
            RandomizerService randomizer = new RandomizerService(seed);

            int result1 = randomizer.GetRandomNumber(min, max, true);
            int result2 = randomizer.GetRandomNumber(min, max, true);
            int result3 = randomizer.GetRandomNumber(min, max, true);

            result1.Should().Be(expectedResult1);
            result2.Should().Be(expectedResult2);
            result3.Should().Be(expectedResult3);
        }

        [Test]
        [Repeat(10)]
        [Category(nameof(RandomizerExtensions.GetRandomChance))]
        public void GetRandomChance_ShouldReturnBetween0And1()
        {
            RandomizerService randomizer = new RandomizerService();

            double result = randomizer.GetRandomChance();

            result.Should().BeGreaterThanOrEqualTo(0.0);
            result.Should().BeLessThanOrEqualTo(1.0);
        }
    }
}
