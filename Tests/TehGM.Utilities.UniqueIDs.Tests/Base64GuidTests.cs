namespace TehGM.Utilities.UniqueIDs.Tests
{
    [TestFixture]
    [TestOf(typeof(Base64Guid))]
    public class Base64GuidTests : TestBase
    {
        [Test]
        [Category(nameof(Base64Guid.GenerateNew))]
        public void GenerateNew_GeneratesNonDefaultValue()
        {
            Base64Guid result = Base64Guid.GenerateNew();

            result.Should().NotBe(default(Base64Guid));
            result.Value.Should().NotBe(default(Guid));
        }

        [Test]
        [Repeat(3)]
        [Category(nameof(Base64Guid.GenerateNew))]
        public void GenerateNew_GeneratesUniqueValues()
        {
            Base64Guid result1 = Base64Guid.GenerateNew();
            Base64Guid result2 = Base64Guid.GenerateNew();

            result1.Should().NotBe(result2);
        }

        [Test]
        [Repeat(3)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromGuid_ReturnsSameGuid()
        {
            Guid guid = Guid.NewGuid();

            Base64Guid result = new Base64Guid(guid);

            result.Value.Should().Be(guid);
        }

        [Test]
        [TestCase("fWdQp6v36EOjBsT1a18b2Q", "a750677d-f7ab-43e8-a306-c4f56b5f1bd9")]
        [TestCase("8KVZQg08_0CJjrEnGNEixw", "4259a5f0-3c0d-40ff-898e-b12718d122c7")]
        [TestCase("2T-cNnAURUOUmp0yCznKLg", "369c3fd9-1470-4345-949a-9d320b39ca2e")]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_ReturnsCorrectGuid(string stringRepresentation, string expectedResultString)
        {
            Guid expectedResult = Guid.Parse(expectedResultString);

            Base64Guid result = new Base64Guid(stringRepresentation);

            result.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("fWdQp6v36EOjBsT1a18b2Q==", "a750677d-f7ab-43e8-a306-c4f56b5f1bd9")]
        [TestCase("8KVZQg08/0CJjrEnGNEixw==", "4259a5f0-3c0d-40ff-898e-b12718d122c7")]
        [TestCase("2T+cNnAURUOUmp0yCznKLg==", "369c3fd9-1470-4345-949a-9d320b39ca2e")]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_ShouldHandleRawBase64(string stringRepresentation, string expectedResultString)
        {
            Guid expectedResult = Guid.Parse(expectedResultString);

            Base64Guid result = new Base64Guid(stringRepresentation);

            result.Value.Should().Be(expectedResult);
        }

        [Test]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_Null_ShouldThrow()
        {
            string value = null;

            Action act = () => new Base64Guid(value);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_Empty_ShouldThrow()
        {
            string value = string.Empty;

            Action act = () => new Base64Guid(value);

            act.Should().Throw<FormatException>();
        }

        [Test]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_Whitespace_ShouldThrow()
        {
            string value = string.Concat(Enumerable.Repeat(' ', 22));

            Action act = () => new Base64Guid(value);

            act.Should().Throw<FormatException>();
        }

        [Test]
        [TestCase("2T'cNnAURUOUmp0yCznKLg")]
        [TestCase("2T;cNnAURUOUmp0yCznKLg")]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_InvalidCharacters_ShouldThrow(string input)
        {
            Action act = () => new Base64Guid(input);

            act.Should().Throw<FormatException>();
        }

        [Test]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_TooLong_ShouldThrow()
        {
            string value = new Faker().Random.String2(30);

            Action act = () => new Base64Guid(value);

            act.Should().Throw<FormatException>();
        }

        [Test]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromString_TooShort_ShouldThrow()
        {
            string value = new Faker().Random.String2(15);

            Action act = () => new Base64Guid(value);

            act.Should().Throw<FormatException>();
        }

        [Test]
        [Repeat(3)]
        [Category(nameof(Base64Guid.ToString))]
        public void ToString_Returns22CharLongString()
        {
            Guid guid = Guid.NewGuid();
            Base64Guid id = new Base64Guid(guid);

            string result = id.ToString();

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().HaveLength(22);
        }

        [Test]
        [TestCase("a750677d-f7ab-43e8-a306-c4f56b5f1bd9", "fWdQp6v36EOjBsT1a18b2Q")]
        [TestCase("4259a5f0-3c0d-40ff-898e-b12718d122c7", "8KVZQg08_0CJjrEnGNEixw")]
        [TestCase("369c3fd9-1470-4345-949a-9d320b39ca2e", "2T-cNnAURUOUmp0yCznKLg")]
        [Category(nameof(Base64Guid.ToString))]
        public void ToString_ReturnsCorrectRepresentation(string guidString, string expectedResult)
        {
            Guid guid = Guid.Parse(guidString);
            Base64Guid id = new Base64Guid(guid);

            string result = id.ToString();

            result.Should().Be(expectedResult);
        }

        [Test]
        [Repeat(3)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_FromGuid_ReturnsSameGuid()
        {
            Guid guid = Guid.NewGuid();

            Base64Guid result = guid;

            result.Value.Should().Be(guid);
        }

        [Test]
        [TestCase("fWdQp6v36EOjBsT1a18b2Q", "a750677d-f7ab-43e8-a306-c4f56b5f1bd9")]
        [TestCase("8KVZQg08_0CJjrEnGNEixw", "4259a5f0-3c0d-40ff-898e-b12718d122c7")]
        [TestCase("2T-cNnAURUOUmp0yCznKLg", "369c3fd9-1470-4345-949a-9d320b39ca2e")]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_FromString_ReturnsCorrectGuid(string stringRepresentation, string expectedResultString)
        {
            Guid expectedResult = Guid.Parse(expectedResultString);

            Base64Guid result = stringRepresentation;

            result.Value.Should().Be(expectedResult);
        }

        [Test]
        [Repeat(3)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_ToGuid_ReturnsCorrectGuid()
        {
            Guid guid = Guid.NewGuid();
            Base64Guid id = new Base64Guid(guid);

            Guid result = id;

            result.Should().Be(guid);
            result.Should().Be(id.Value);
        }

        [Test]
        [TestCase("a750677d-f7ab-43e8-a306-c4f56b5f1bd9", "fWdQp6v36EOjBsT1a18b2Q")]
        [TestCase("4259a5f0-3c0d-40ff-898e-b12718d122c7", "8KVZQg08_0CJjrEnGNEixw")]
        [TestCase("369c3fd9-1470-4345-949a-9d320b39ca2e", "2T-cNnAURUOUmp0yCznKLg")]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_ToString_ReturnsCorrectRepresentation(string guidString, string expectedResult)
        {
            Guid guid = Guid.Parse(guidString);
            Base64Guid id = new Base64Guid(guid);

            string result = id;

            result.Should().Be(expectedResult);
        }

        [Test]
        [Repeat(3)]
        [Category(TestCategoryName.Extensions)]
        public void ExtensionConversion_ToBase64Guid_ReturnsSameGuid()
        {
            Guid guid = Guid.NewGuid();

            Base64Guid result = guid.ToBase64Guid();

            result.Value.Should().Be(guid);
        }

        [Test]
        [TestCase("a750677d-f7ab-43e8-a306-c4f56b5f1bd9", "fWdQp6v36EOjBsT1a18b2Q")]
        [TestCase("4259a5f0-3c0d-40ff-898e-b12718d122c7", "8KVZQg08_0CJjrEnGNEixw")]
        [TestCase("369c3fd9-1470-4345-949a-9d320b39ca2e", "2T-cNnAURUOUmp0yCznKLg")]
        [Category(TestCategoryName.Extensions)]
        public void ExtensionConversion_ToBase64GuidString_ReturnsCorrectRepresentation(string guidString, string expectedResult)
        {
            Guid guid = Guid.Parse(guidString);

            string result = guid.ToBase64GuidString();

            result.Should().Be(expectedResult);
        }
    }
}