namespace Albite.Core.Diagnostics
{
    /// <summary>
    /// Used to hold the currently used logger.
    /// </summary>
    public class Logger
    {
        private static object _lock = new object();
        private static ILogger _logger = null;

        private Logger() { }

        /// <summary>
        /// The current logger used by the framework.
        /// Defaults to no logger (i.e. null).
        /// </summary>
        public static ILogger Current
        {
            get
            {
                lock (_lock) { return _logger; }
            }
            set
            {
                lock (_lock) { _logger = value; }
            }
        }

        /// <summary>Log a single message to the current logger.</summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogMessage(string format, params object[] args)
        {
            ILogger logger = Current;

            if (logger != null)
            {
                Current.LogMessage(format, args);
            }
        }
    }
}
