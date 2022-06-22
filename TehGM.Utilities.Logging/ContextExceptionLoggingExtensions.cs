using Microsoft.Extensions.Logging;
using System;

namespace TehGM.Utilities
{
    /// <summary>Extension methods for logging exceptions and preserving log context.</summary>
    public static class ContextExceptionLoggingExtensions
    {
        /// <summary>Logs exception with Critical level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsCritical(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogCritical(exception, message, args);
            return true;
        }
        /// <summary>Logs exception with Error level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsError(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogError(exception, message, args);
            return true;
        }
        /// <summary>Logs exception with Warning level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsWarning(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogWarning(exception, message, args);
            return true;
        }
        /// <summary>Logs exception with Information level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsInformation(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogInformation(exception, message, args);
            return true;
        }
        /// <summary>Logs exception with Debug level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsDebug(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogDebug(exception, message, args);
            return true;
        }
        /// <summary>Logs exception with Trace level and returns true. Use with `when` keyword to preserve log context.</summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="log">The Microsoft.Extensions.Logging.ILogger to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Always returns true.</returns>
        public static bool LogAsTrace(this Exception exception, ILogger log, string message, params object[] args)
        {
            log?.LogTrace(exception, message, args);
            return true;
        }
    }
}
