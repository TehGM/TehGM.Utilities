namespace TehGM.Utilities.Time.Tests
{
    [TestFixture]
    [TestOf(typeof(UnixTimestamp))]
    public class UnixTimestampTests : TestBase
    {
        [Test, AutoNSubstituteData]
        [Repeat(3)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromValue_KeepsOriginalValue(long value)
        {
            UnixTimestamp timestamp = new UnixTimestamp(value);

            timestamp.Value.Should().Be(value);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616)]
        [TestCase(629474418000000000, 811845000)]
        [TestCase(630593244020000000, 923727602)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromDateTime_ConvertsValue(long ticks, long expectedResult)
        {
            DateTime dt = new DateTime(ticks);

            UnixTimestamp timestamp = new UnixTimestamp(dt);

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616)]
        [TestCase(629474418000000000, 811845000)]
        [TestCase(630593244020000000, 923727602)]
        [Category(TestCategoryName.Conversions)]
        public void ExplicitConversion_FromDateTime_ConvertsValue(long ticks, long expectedResult)
        {
            DateTime dt = new DateTime(ticks);

            UnixTimestamp timestamp = (UnixTimestamp)dt;

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616)]
        [TestCase(629474418000000000, 811845000)]
        [TestCase(630593244020000000, 923727602)]
        [Category(TestCategoryName.Constructor)]
        public void Constructor_FromDateTimeOffset_ConvertsValue(long ticks, long expectedResult)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);

            UnixTimestamp timestamp = new UnixTimestamp(dto);

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 1656002616)]
        [TestCase(629474418000000000, 811845000)]
        [TestCase(630593244020000000, 923727602)]
        [Category(TestCategoryName.Conversions)]
        public void ExplicitConversion_FromDateTimeOffset_ConvertsValue(long ticks, long expectedResult)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);

            UnixTimestamp timestamp = (UnixTimestamp)dto;

            timestamp.Value.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994160000000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244020000000, 630593244020000000)]
        [Category(nameof(UnixTimestamp.ToDateTime))]
        public void ToDateTime_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTime dt = new DateTime(ticks);
            DateTime expectedResult = new DateTime(expectedResultTicks);
            UnixTimestamp timestamp = new UnixTimestamp(dt);

            DateTime result = timestamp.ToDateTime();

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994160000000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244020000000, 630593244020000000)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversion_ToDateTime_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTime dt = new DateTime(ticks);
            DateTime expectedResult = new DateTime(expectedResultTicks);
            UnixTimestamp timestamp = new UnixTimestamp(dt);

            DateTime result = timestamp;

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994160000000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244020000000, 630593244020000000)]
        [Category(nameof(UnixTimestamp.ToDateTimeOffset))]
        public void ToDateTimeOffset_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);
            DateTimeOffset expectedResult = new DateTimeOffset(expectedResultTicks, TimeSpan.Zero);
            UnixTimestamp timestamp = new UnixTimestamp(dto);

            DateTimeOffset result = timestamp.ToDateTimeOffset();

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(637915994167465978, 637915994160000000)]
        [TestCase(629474418000000000, 629474418000000000)]
        [TestCase(630593244020000000, 630593244020000000)]
        [Category(TestCategoryName.Conversions)]
        public void ImplicitConversions_ToDateTimeOffset_ReturnsExpectedValue(long ticks, long expectedResultTicks)
        {
            DateTimeOffset dto = new DateTimeOffset(ticks, TimeSpan.Zero);
            DateTimeOffset expectedResult = new DateTimeOffset(expectedResultTicks, TimeSpan.Zero);
            UnixTimestamp timestamp = new UnixTimestamp(dto);

            DateTimeOffset result = timestamp;

            result.Should().Be(expectedResult);
        }
    }
}