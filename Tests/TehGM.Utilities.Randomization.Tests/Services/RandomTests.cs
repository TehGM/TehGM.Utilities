using TehGM.Utilities.Randomization.Services;

namespace TehGM.Utilities.Randomization.Tests
{
    [TestFixture]
    [TestOf(typeof(Random))]
    public class RandomTests : TestBase
    {
        [Test]
        [Repeat(5)]
        [Category(nameof(RandomExtensions.GetRandomValue))]
        [AutoNSubstituteData]
        public void GetRandomValue_ReturnsValueFromCollection(IEnumerable<int> values)
        {
            Random random = new Random();

            int result = random.GetRandomValue(values);

            result.Should().BeOneOf(values);
        }

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomExtensions.GetRandomChance))]
        public void GetRandomChance_ShouldReturnBetween0And1()
        {
            Random random = new Random();

            double result = random.GetRandomChance();

            result.Should().BeGreaterThanOrEqualTo(0.0);
            result.Should().BeLessThanOrEqualTo(1.0);
        }

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomExtensions.GetRandomEnumValue))]
        public void GetRandomEnumValue_ReturnsOneOfDefinedValues()
        {
            Random random = new Random();

            EnumValues result = random.GetRandomEnumValue<EnumValues>();

            result.Should().BeDefined();
        }

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_ReturnsRandomString_WithRequestedLength()
        {
            Random random = new Random();
            int length = new Bogus.Randomizer().Number(1, 10);

            string result = random.GetRandomString(length);

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveLength(length);
        }

        [Test]
        [Repeat(5)]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_WithRequestedZeroLength_ReturnsEmptyString()
        {
            Random random = new Random();

            string result = random.GetRandomString(0);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        [Repeat(5)]
        [TestCase("ab")]
        [TestCase("aB3")]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_ReturnsRandomString_UsingCharsetCharacters(string charset)
        {
            Random random = new Random();

            string result = random.GetRandomString(10, charset);

            result.Should().NotBeNullOrEmpty();
            result.AsEnumerable().Should().OnlyContain(c => charset.Contains(c));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_WithInvalidLength_ShouldThrow(int length)
        {
            Random random = new Random();

            Action act = () => random.GetRandomString(length);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_WithNullCharset_ShouldThrow()
        {
            Random random = new Random();

            Action act = () => random.GetRandomString(10, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [Category(nameof(RandomExtensions.GetRandomString))]
        public void GetRandomString_WithEmptyCharset_ShouldThrow()
        {
            Random random = new Random();

            Action act = () => random.GetRandomString(10, null);

            act.Should().Throw<ArgumentException>();
        }

        private enum EnumValues
        {
            Value1 = 1,
            Value2 = 2,
            Value1337 = 1337
        }
    }
}
