using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Albite.Core.Windows")]
[assembly: InternalsVisibleTo("Albite.Core.WindowsPhone")]

namespace Albite.Core.Test
{
    internal interface IAssert
    {
        void AreEqual(object expected, object actual);
        void AreEqual<T>(T expected, T actual);
        void AreEqual(double expected, double actual, double delta);
        void AreEqual(float expected, float actual, float delta);
        void AreEqual(object expected, object actual, string message);
        void AreEqual(string expected, string actual, bool ignoreCase);
        void AreEqual<T>(T expected, T actual, string message);
        void AreEqual(double expected, double actual, double delta, string message);
        void AreEqual(float expected, float actual, float delta, string message);
        void AreEqual(object expected, object actual, string message, params object[] parameters);
        void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture);
        void AreEqual(string expected, string actual, bool ignoreCase, string message);
        void AreEqual<T>(T expected, T actual, string message, params object[] parameters);
        void AreEqual(double expected, double actual, double delta, string message, params object[] parameters);
        void AreEqual(float expected, float actual, float delta, string message, params object[] parameters);
        void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message);
        void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters);
        void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters);
        void AreNotEqual(object notExpected, object actual);
        void AreNotEqual<T>(T notExpected, T actual);
        void AreNotEqual(double notExpected, double actual, double delta);
        void AreNotEqual(float notExpected, float actual, float delta);
        void AreNotEqual(object notExpected, object actual, string message);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase);
        void AreNotEqual<T>(T notExpected, T actual, string message);
        void AreNotEqual(double notExpected, double actual, double delta, string message);
        void AreNotEqual(float notExpected, float actual, float delta, string message);
        void AreNotEqual(object notExpected, object actual, string message, params object[] parameters);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message);
        void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters);
        void AreNotEqual(double notExpected, double actual, double delta, string message, params object[] parameters);
        void AreNotEqual(float notExpected, float actual, float delta, string message, params object[] parameters);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters);
        void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters);
        void AreNotSame(object notExpected, object actual);
        void AreNotSame(object notExpected, object actual, string message);
        void AreNotSame(object notExpected, object actual, string message, params object[] parameters);
        void AreSame(object expected, object actual);
        void AreSame(object expected, object actual, string message);
        void AreSame(object expected, object actual, string message, params object[] parameters);
        void Fail();
        void Fail(string message);
        void Fail(string message, params object[] parameters);
        void Inconclusive();
        void Inconclusive(string message);
        void Inconclusive(string message, params object[] parameters);
        void IsFalse(bool condition);
        void IsFalse(bool condition, string message);
        void IsFalse(bool condition, string message, params object[] parameters);
        void IsInstanceOfType(object value, Type expectedType);
        void IsInstanceOfType(object value, Type expectedType, string message);
        void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters);
        void IsNotInstanceOfType(object value, Type wrongType);
        void IsNotInstanceOfType(object value, Type wrongType, string message);
        void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters);
        void IsNotNull(object value);
        void IsNotNull(object value, string message);
        void IsNotNull(object value, string message, params object[] parameters);
        void IsNull(object value);
        void IsNull(object value, string message);
        void IsNull(object value, string message, params object[] parameters);
        void IsTrue(bool condition);
        void IsTrue(bool condition, string message);
        void IsTrue(bool condition, string message, params object[] parameters);
        string ReplaceNullChars(string input);
        T ThrowsException<T>(Action action) where T : Exception;
        T ThrowsException<T>(Func<object> action) where T : Exception;
        T ThrowsException<T>(Action action, string message) where T : Exception;
        T ThrowsException<T>(Func<object> action, string message) where T : Exception;
        T ThrowsException<T>(Action action, string message, params object[] parameters) where T : Exception;
        T ThrowsException<T>(Func<object> action, string message, params object[] parameters) where T : Exception;
    }
}
