using System;

namespace Albite.Core.UnitTest
{
    /// <summary>
    /// Microsoft.VisualStudio.TestPlatform.UnitTestFramework.Assert.ThrowsException
    /// does not seem to work for some reason, so implemented here.
    /// </summary>
    public static class Assert
    {
        public class Exception : System.Exception
        {
            public Exception() { }
            public Exception(string message) : base(message) { }
        }

        public static void ThrowsException<T>(Action action) where T : System.Exception
        {
            ThrowsException<T>(action, null);
        }

        public static void ThrowsException<T>(Action action, string message) where T : System.Exception
        {
            try
            {
                action.Invoke();
            }
            catch (T)
            {
                return;
            }

            doThrow(message);
        }

        private static void doThrow(string message)
        {
            throw (message == null) ? new Exception() : new Exception(message);
        }
    }
}
