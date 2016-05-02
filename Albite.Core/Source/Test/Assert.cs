using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Albite.Core.Windows")]
[assembly: InternalsVisibleTo("Albite.Core.WindowsPhone")]

#pragma warning disable 1591
namespace Albite.Core.Test
{
    public class Assert
    {
        internal static IAssert Current { get; set; }

        private Assert() { }

        public static void AreEqual(object expected, object actual)
        {
            Current.AreEqual(expected, actual);
        }

        public static void AreEqual<T>(T expected, T actual)
        {
            Current.AreEqual<T>(expected, actual);
        }

        public static void AreEqual(double expected, double actual, double delta)
        {
            Current.AreEqual(expected, actual, delta);
        }

        public static void AreEqual(float expected, float actual, float delta)
        {
            Current.AreEqual(expected, actual, delta);
        }

        public static void AreEqual(object expected, object actual, string message)
        {
            Current.AreEqual(expected, actual, message);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase)
        {
            Current.AreEqual(expected, actual, ignoreCase);
        }

        public static void AreEqual<T>(T expected, T actual, string message)
        {
            Current.AreEqual<T>(expected, actual, message);
        }

        public static void AreEqual(double expected, double actual, double delta, string message)
        {
            Current.AreEqual(expected, actual, delta, message);
        }

        public static void AreEqual(float expected, float actual, float delta, string message)
        {
            Current.AreEqual(expected, actual, delta, message);
        }

        public static void AreEqual(object expected, object actual, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, message, parameters);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Current.AreEqual(expected, actual, ignoreCase, culture);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase, string message)
        {
            Current.AreEqual(expected, actual, ignoreCase, message);
        }

        public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
        {
            Current.AreEqual<T>(expected, actual, message, parameters);
        }

        public static void AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, delta, message, parameters);
        }

        public static void AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, delta, message, parameters);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Current.AreEqual(expected, actual, ignoreCase, culture);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, ignoreCase, message, parameters);
        }

        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, ignoreCase, culture, message, parameters);
        }

        public static void AreNotEqual(object notExpected, object actual)
        {
            Current.AreNotEqual(notExpected, actual);
        }

        public static void AreNotEqual<T>(T notExpected, T actual)
        {
            Current.AreNotEqual<T>(notExpected, actual);
        }

        public static void AreNotEqual(double notExpected, double actual, double delta)
        {
            Current.AreNotEqual(notExpected, actual, delta);
        }

        public static void AreNotEqual(float notExpected, float actual, float delta)
        {
            Current.AreNotEqual(notExpected, actual, delta);
        }

        public static void AreNotEqual(object notExpected, object actual, string message)
        {
            Current.AreNotEqual(notExpected, actual, message);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase);
        }

        public static void AreNotEqual<T>(T notExpected, T actual, string message)
        {
            Current.AreNotEqual<T>(notExpected, actual, message);
        }

        public static void AreNotEqual(double notExpected, double actual, double delta, string message)
        {
            Current.AreNotEqual(notExpected, actual, delta, message);
        }

        public static void AreNotEqual(float notExpected, float actual, float delta, string message)
        {
            Current.AreNotEqual(notExpected, actual, delta, message);
        }

        public static void AreNotEqual(object notExpected, object actual, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, message, parameters);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase, culture);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase, message);
        }

        public static void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
        {
            Current.AreNotEqual<T>(notExpected, actual, message, parameters);
        }

        public static void AreNotEqual(double notExpected, double actual, double delta, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, notExpected, delta, message, parameters);
        }

        public static void AreNotEqual(float notExpected, float actual, float delta, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, delta, message, parameters);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase, culture, message);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase, message, parameters);
        }

        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, ignoreCase, culture, message, parameters);
        }

        public static void AreNotSame(object notExpected, object actual)
        {
            Current.AreNotSame(notExpected, actual);
        }

        public static void AreNotSame(object notExpected, object actual, string message)
        {
            Current.AreNotSame(notExpected, actual, message);
        }

        public static void AreNotSame(object notExpected, object actual, string message, params object[] parameters)
        {
            Current.AreNotSame(notExpected, actual, message, parameters);
        }

        public static void AreSame(object expected, object actual)
        {
            Current.AreSame(expected, actual);
        }

        public static void AreSame(object expected, object actual, string message)
        {
            Current.AreSame(expected, actual, message);
        }

        public static void AreSame(object expected, object actual, string message, params object[] parameters)
        {
            Current.AreSame(expected, actual, message, parameters);
        }

        public static void Fail()
        {
            Current.Fail();
        }

        public static void Fail(string message)
        {
            Current.Fail(message);
        }

        public static void Fail(string message, params object[] parameters)
        {
            Current.Fail(message, parameters);
        }

        public static void Inconclusive()
        {
            Current.Inconclusive();
        }

        public static void Inconclusive(string message)
        {
            Current.Inconclusive(message);
        }

        public static void Inconclusive(string message, params object[] parameters)
        {
            Current.Inconclusive(message, parameters);
        }

        public static void IsFalse(bool condition)
        {
            Current.IsFalse(condition);
        }

        public static void IsFalse(bool condition, string message)
        {
            Current.IsFalse(condition, message);
        }

        public static void IsFalse(bool condition, string message, params object[] parameters)
        {
            Current.IsFalse(condition, message, parameters);
        }

        public static void IsInstanceOfType(object value, Type expectedType)
        {
            Current.IsInstanceOfType(value, expectedType);
        }

        public static void IsInstanceOfType(object value, Type expectedType, string message)
        {
            Current.IsInstanceOfType(value, expectedType, message);
        }

        public static void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters)
        {
            Current.IsInstanceOfType(value, expectedType, message, parameters);
        }

        public static void IsNotInstanceOfType(object value, Type wrongType)
        {
            Current.IsNotInstanceOfType(value, wrongType);
        }

        public static void IsNotInstanceOfType(object value, Type wrongType, string message)
        {
            Current.IsNotInstanceOfType(value, wrongType, message);
        }

        public static void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters)
        {
            Current.IsNotInstanceOfType(value, wrongType, message, parameters);
        }

        public static void IsNotNull(object value)
        {
            Current.IsNotNull(value);
        }

        public static void IsNotNull(object value, string message)
        {
            Current.IsNotNull(value, message);
        }

        public static void IsNotNull(object value, string message, params object[] parameters)
        {
            Current.IsNotNull(value, message, parameters);
        }

        public static void IsNull(object value)
        {
            Current.IsNull(value);
        }

        public static void IsNull(object value, string message)
        {
            Current.IsNull(value, message);
        }

        public static void IsNull(object value, string message, params object[] parameters)
        {
            Current.IsNull(value, message, parameters);
        }

        public static void IsTrue(bool condition)
        {
            Current.IsTrue(condition);
        }

        public static void IsTrue(bool condition, string message)
        {
            Current.IsTrue(condition, message);
        }

        public static void IsTrue(bool condition, string message, params object[] parameters)
        {
            Current.IsTrue(condition, message, parameters);
        }

        public static string ReplaceNullChars(string input)
        {
            return Current.ReplaceNullChars(input);
        }

        public static T ThrowsException<T>(Action action) where T : Exception
        {
            return Current.ThrowsException<T>(action);
        }

        public static T ThrowsException<T>(Func<object> action) where T : Exception
        {
            return Current.ThrowsException<T>(action);
        }

        public static T ThrowsException<T>(Action action, string message) where T : Exception
        {
            return Current.ThrowsException<T>(action, message);
        }

        public static T ThrowsException<T>(Func<object> action, string message) where T : Exception
        {
            return Current.ThrowsException<T>(action, message);
        }

        public static T ThrowsException<T>(Action action, string message, params object[] parameters) where T : Exception
        {
            return Current.ThrowsException<T>(action, message, parameters);
        }

        public static T ThrowsException<T>(Func<object> action, string message, params object[] parameters) where T : Exception
        {
            return Current.ThrowsException<T>(action, message, parameters);
        }
    }
}
#pragma warning restore 1591
