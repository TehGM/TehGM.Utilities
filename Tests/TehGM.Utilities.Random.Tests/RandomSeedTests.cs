namespace TehGM.Utilities.Random.Tests
{
    [TestFixture]
    [TestOf(typeof(RandomSeed))]
    public class RandomSeedTests : TestBase
    {
        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_PreservesIntegerValue(int value)
        {
            RandomSeed result = new RandomSeed(value);

            result.Value.Should().Be(value);
        }

        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_FromInt32_PreservesIntegerValue(int value)
        {
            RandomSeed result = value;

            result.Value.Should().Be(value);
        }

        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_ToInt32_RetrievesOriginalValue(int value)
        {
            RandomSeed seed = new RandomSeed(value);

            int result = seed;

            result.Should().Be(value);
        }

        [Test]
        [TestCase("abcdef", 982435995)]
        [TestCase("GHASGF", -270424388)]
        [TestCase("fhGdkJ", 1205187230)]
        [Category(TestCategoryName.Conversions)]
        public void ExplicitConversion_FromString_GeneratesExpectedValue(string input, int expectedResult)
        {
            RandomSeed result = (RandomSeed)input;

            result.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("abcdef", 982435995)]
        [TestCase("GHASGF", -270424388)]
        [TestCase("fhGdkJ", 1205187230)]
        [Category(nameof(RandomSeed.FromString))]
        public void FromString_CaseSensitive_GeneratesExpectedValue(string input, int expectedResult)
        {
            RandomSeed result = RandomSeed.FromString(input, false);

            result.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("abcdef", 982435995)]
        [TestCase("GHASGF", -145570500)]
        [TestCase("fhGdkJ", -1664859618)]
        [Category(nameof(RandomSeed.FromString))]
        public void FromString_CaseInsensitive_GeneratesExpectedValue(string input, int expectedResult)
        {
            RandomSeed result = RandomSeed.FromString(input, true);

            result.Value.Should().Be(expectedResult);
        }

        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(nameof(RandomSeed.GetHashCode))]
        public void GetHashCode_ReturnsValueHashCode(int value)
        {
            RandomSeed seed = new RandomSeed(value);

            int result = seed.GetHashCode();

            result.Should().Be(value.GetHashCode());
        }

        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(nameof(RandomSeed.ToString))]
        public void ToString_ReturnsValue(int value)
        {
            RandomSeed seed = new RandomSeed(value);

            string result = seed.ToString();

            result.Should().Be(value.ToString());
        }
    }
}