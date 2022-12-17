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

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_ReturnsRandomString_WithRequestedLength()
        {
            RandomizerService randomizer = new RandomizerService();
            int length = new Bogus.Randomizer().Number(1, 10);

            string result = randomizer.GetRandomString(length);

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveLength(length);
        }

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_WithRequestedZeroLength_ReturnsEmptyString()
        {
            RandomizerService randomizer = new RandomizerService();

            string result = randomizer.GetRandomString(0);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        [Repeat(5)]
        [TestCase("ab")]
        [TestCase("aB3")]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_ReturnsRandomString_UsingCharsetCharacters(string charset)
        {
            RandomizerService randomizer = new RandomizerService();

            string result = randomizer.GetRandomString(10, charset);

            result.Should().NotBeNullOrEmpty();
            result.AsEnumerable().Should().OnlyContain(c => charset.Contains(c));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_WithInvalidLength_ShouldThrow(int length)
        {
            RandomizerService randomizer = new RandomizerService();

            Action act = () => randomizer.GetRandomString(length);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_WithNullCharset_ShouldThrow()
        {
            RandomizerService randomizer = new RandomizerService();

            Action act = () => randomizer.GetRandomString(10, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [Category(nameof(RandomizerExtensions.GetRandomString))]
        public void GetRandomString_WithEmptyCharset_ShouldThrow()
        {
            RandomizerService randomizer = new RandomizerService();

            Action act = () => randomizer.GetRandomString(10, null);

            act.Should().Throw<ArgumentException>();
        }
    }
}
