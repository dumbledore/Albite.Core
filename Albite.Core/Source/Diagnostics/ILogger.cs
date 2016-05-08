namespace Albite.Diagnostics
{
    /// <summary>
    /// Universal logging interface. May be backed up by various logs,
    /// e.g. Diagnostics.Debug, UnitTestFramework.Logger, etc.
    /// </summary>
    public interface ILogger
    {
        /// <summary>Log a single message.</summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void LogMessage(string format, params object[] args);
    }
}
