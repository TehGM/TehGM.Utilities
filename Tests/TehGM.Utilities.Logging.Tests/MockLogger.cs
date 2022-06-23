using Microsoft.Extensions.Logging;

namespace TehGM
{
    public abstract class MockLogger : ILogger
    {
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
            Log(logLevel, eventId, (object)state, exception, formatter(state, exception));

        public abstract void Log(LogLevel logLevel, EventId eventId, object state, Exception exception, string message);

        public virtual bool IsEnabled(LogLevel logLevel) => true;

        public abstract IDisposable BeginScope<TState>(TState state);
    }
}
