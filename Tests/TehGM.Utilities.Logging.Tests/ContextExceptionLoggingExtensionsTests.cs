using Microsoft.Extensions.Logging;

namespace TehGM.Utilities.Logging.Tests
{
    [TestFixture]
    [TestOf(nameof(ContextExceptionLoggingExtensions))]
    public class ContextExceptionLoggingExtensionsTests : TestBase
    {
        private MockLogger _logger;
        private Exception _exception;

        //[SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this._logger = Substitute.For<MockLogger>();
            this._exception = Substitute.For<Exception>();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsCritical))]
        public void LogAsCritical_CallsLogger()
        {
            this._exception.LogAsCritical(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Critical, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsCritical))]
        public void LogAsCritical_ReturnsTrue()
        {
            bool result = this._exception.LogAsCritical(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsError))]
        public void LogAsError_CallsLogger()
        {
            this._exception.LogAsError(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Error, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsError))]
        public void LogAsError_ReturnsTrue()
        {
            bool result = this._exception.LogAsError(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsWarning))]
        public void LogAsWarning_CallsLogger()
        {
            this._exception.LogAsWarning(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Warning, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsWarning))]
        public void LogAsWarning_ReturnsTrue()
        {
            bool result = this._exception.LogAsWarning(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsInformation))]
        public void LogAsInformation_CallsLogger()
        {
            this._exception.LogAsInformation(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Information, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsInformation))]
        public void LogAsInformation_ReturnsTrue()
        {
            bool result = this._exception.LogAsInformation(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsDebug))]
        public void LogAsDebug_CallsLogger()
        {
            this._exception.LogAsDebug(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Debug, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsDebug))]
        public void LogAsDebug_ReturnsTrue()
        {
            bool result = this._exception.LogAsDebug(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsTrace))]
        public void LogAsTrace_CallsLogger()
        {
            this._exception.LogAsTrace(this._logger, base.Fixture.Create<string>());

            this._logger.Received().Log(LogLevel.Trace, Arg.Any<EventId>(), Arg.Any<object>(), this._exception, Arg.Any<string>());
        }

        [Test]
        [Category(nameof(ContextExceptionLoggingExtensions.LogAsTrace))]
        public void LogAsTrace_ReturnsTrue()
        {
            bool result = this._exception.LogAsTrace(this._logger, base.Fixture.Create<string>());

            result.Should().BeTrue();
        }
    }
}