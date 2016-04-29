using System;

namespace Albite.Core.UnitTest
{
    /// <summary>
    /// <c>Microsoft.VisualStudio.TestPlatform.UnitTestFramework.Assert.ThrowsException</c>
    /// does not seem to work for some reason, so implemented here.
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// Exception thrown when an assert fails.
        /// </summary>
        public class Exception : System.Exception
        {
            /// <summary>
            /// Initializes a new instance of the <c>Albite.Core.UnitTest.Exception</c> class.
            /// </summary>
            public Exception() { }

            /// <summary>
            /// Initializes a new instance of the <c>Albite.Core.UnitTest.Exception</c> class
            /// with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public Exception(string message) : base(message) { }
        }

        /// <summary>
        /// Assert that a piece of code throws an exception of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the the expected exception which. Must inherit from <c>System.Exception</c>.
        /// </typeparam>
        /// <param name="action">
        /// The action which must throw the exception when invoked.
        /// </param>
        /// <exception cref="Albite.Core.UnitTest.Assert.Exception">
        /// Exception of type <typeparamref name="T" /> was not thrown.
        /// </exception>
        public static void ThrowsException<T>(Action action) where T : System.Exception
        {
            ThrowsException<T>(action, null);
        }

        /// <summary>
        /// Assert that a piece of code throws an exception of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the the expected exception which. Must inherit from <c>System.Exception</c>.
        /// </typeparam>
        /// <param name="action">
        /// The action which must throw the exception when invoked.
        /// </param>
        /// <param name="message">A message describing the assert.</param>
        /// <exception cref="Albite.Core.UnitTest.Assert.Exception">
        /// Exception of type <typeparamref name="T" /> was not thrown.
        /// </exception>
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
