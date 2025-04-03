namespace TehGM.Utilities.Time.Tests
{
    [TestFixture]
    [TestOf(typeof(UnixTimestampMilliseconds))]
    public class UnixTimestampMillisecondsTests : TestBase
    {
        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromValue_KeepsOriginalValue(long value)
        {
            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(value);

            timestamp.Value.Should().Be(value);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616746)]
        [TestCase(629474418000000000, 811845000000)]
        [TestCase(630593244022000000, 923727602200)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromDateTime_ConvertsValue(long ticks, long expectedResult)
        {
            DateTime dt = new DateTime(ticks);

            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dt);

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616746)]
        [TestCase(629474418000000000, 811845000000)]
        [TestCase(630593244022000000, 923727602200)]
        [Category(TestCategoryName.Conversions)]
        public void ExplicitConversion_FromDateTime_ConvertsValue(long ticks, long expectedResult)
        {
            DateTime dt = new DateTime(ticks);

            UnixTimestampMilliseconds timestamp = (UnixTimestampMilliseconds)dt;

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616746)]
        [TestCase(629474418000000000, 811845000000)]
        [TestCase(630593244022000000, 923727602200)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromDateTimeOffset_ConvertsValue(long ticks, long expectedResult)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);

            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dto);

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616746)]
        [TestCase(629474418000000000, 811845000000)]
        [TestCase(630593244022000000, 923727602200)]
        [Category(TestCategoryName.Conversions)]
        public void ExplicitConversion_FromDateTimeOffset_ConvertsValue(long ticks, long expectedResult)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);

            UnixTimestampMilliseconds timestamp = (UnixTimestampMilliseconds)dto;

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994167460000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244022000000, 630593244022000000)]
        [Category(nameof(UnixTimestampMilliseconds.ToDateTime))]
        public void ToDateTime_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTime dt = new DateTime(ticks);
            DateTime expectedResult = new DateTime(expectedResultTicks);
            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dt);

            DateTime result = timestamp.ToDateTime();

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994167460000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244022000000, 630593244022000000)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_ToDateTime_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTime dt = new DateTime(ticks);
            DateTime expectedResult = new DateTime(expectedResultTicks);
            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dt);

            DateTime result = timestamp;

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994167460000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244022000000, 630593244022000000)]
        [Category(nameof(UnixTimestampMilliseconds.ToDateTimeOffset))]
        public void ToDateTimeOffset_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);
            DateTimeOffset expectedResult = new DateTimeOffset(expectedResultTicks, TimeSpan.Zero);
            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dto);

            DateTimeOffset result = timestamp.ToDateTimeOffset();

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994167460000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244022000000, 630593244022000000)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversions_ToDateTimeOffset_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);
            DateTimeOffset expectedResult = new DateTimeOffset(expectedResultTicks, TimeSpan.Zero);
            UnixTimestampMilliseconds timestamp = new UnixTimestampMilliseconds(dto);

            DateTimeOffset result = timestamp;

            result.Should().Be(expectedResult);
        }
    }
}