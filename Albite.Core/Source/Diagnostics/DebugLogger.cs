using System.Diagnostics;

namespace Albite.Diagnostics
{
    /// <summary>
    /// Logger based on <c>System.Diagnostics.Debug</c>.
    /// </summary>
    public sealed class DebugLogger : ILogger
    {
        private DebugLogger() { }

        /// <summary>
        /// Instace of <c>DebugLogger</c>.
        /// </summary>
        public static ILogger Instance = new DebugLogger();

        /// <summary>Log a single message to <c>System.Diagnostics.Debug</c>.</summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void LogMessage(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
    }
}
