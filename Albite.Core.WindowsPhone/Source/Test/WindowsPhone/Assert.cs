using System;
using System.Globalization;
using VSUnitTest = Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.WindowsPhone
{
    class Assert : IAssert
    {
        public static readonly IAssert Instance = new Assert();

        private Assert() { }

        public void AreEqual(object expected, object actual)
        {
            VSUnitTest.Assert.AreEqual(expected, actual);
        }

        public void AreEqual<T>(T expected, T actual)
        {
            VSUnitTest.Assert.AreEqual<T>(expected, actual);
        }

        public void AreEqual(double expected, double actual, double delta)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta);
        }

        public void AreEqual(float expected, float actual, float delta)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta);
        }

        public void AreEqual(object expected, object actual, string message)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, message);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase);
        }

        public void AreEqual<T>(T expected, T actual, string message)
        {
            VSUnitTest.Assert.AreEqual<T>(expected, actual, message);
        }

        public void AreEqual(double expected, double actual, double delta, string message)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta, message);
        }

        public void AreEqual(float expected, float actual, float delta, string message)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta, message);
        }

        public void AreEqual(object expected, object actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, message, parameters);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase, culture);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase, string message)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase, message);
        }

        public void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual<T>(expected, actual, message, parameters);
        }

        public void AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta, message, parameters);
        }

        public void AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, delta, message, parameters);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase, culture);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase, message, parameters);
        }

        public void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreEqual(expected, actual, ignoreCase, culture, message, parameters);
        }

        public void AreNotEqual(object notExpected, object actual)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual);
        }

        public void AreNotEqual<T>(T notExpected, T actual)
        {
            VSUnitTest.Assert.AreNotEqual<T>(notExpected, actual);
        }

        public void AreNotEqual(double notExpected, double actual, double delta)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, delta);
        }

        public void AreNotEqual(float notExpected, float actual, float delta)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, delta);
        }

        public void AreNotEqual(object notExpected, object actual, string message)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, message);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase);
        }

        public void AreNotEqual<T>(T notExpected, T actual, string message)
        {
            VSUnitTest.Assert.AreNotEqual<T>(notExpected, actual, message);
        }

        public void AreNotEqual(double notExpected, double actual, double delta, string message)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, delta, message);
        }

        public void AreNotEqual(float notExpected, float actual, float delta, string message)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, delta, message);
        }

        public void AreNotEqual(object notExpected, object actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, message, parameters);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase, culture);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase, message);
        }

        public void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual<T>(notExpected, actual, message, parameters);
        }

        public void AreNotEqual(double notExpected, double actual, double delta, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, notExpected, delta, message, parameters);
        }

        public void AreNotEqual(float notExpected, float actual, float delta, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, delta, message, parameters);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, message);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase, message, parameters);
        }

        public void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, message, parameters);
        }

        public void AreNotSame(object notExpected, object actual)
        {
            VSUnitTest.Assert.AreNotSame(notExpected, actual);
        }

        public void AreNotSame(object notExpected, object actual, string message)
        {
            VSUnitTest.Assert.AreNotSame(notExpected, actual, message);
        }

        public void AreNotSame(object notExpected, object actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreNotSame(notExpected, actual, message, parameters);
        }

        public void AreSame(object expected, object actual)
        {
            VSUnitTest.Assert.AreSame(expected, actual);
        }

        public void AreSame(object expected, object actual, string message)
        {
            VSUnitTest.Assert.AreSame(expected, actual, message);
        }

        public void AreSame(object expected, object actual, string message, params object[] parameters)
        {
            VSUnitTest.Assert.AreSame(expected, actual, message, parameters);
        }

        public void Fail()
        {
            VSUnitTest.Assert.Fail();
        }

        public void Fail(string message)
        {
            VSUnitTest.Assert.Fail(message);
        }

        public void Fail(string message, params object[] parameters)
        {
            VSUnitTest.Assert.Fail(message, parameters);
        }

        public void Inconclusive()
        {
            VSUnitTest.Assert.Inconclusive();
        }

        public void Inconclusive(string message)
        {
            VSUnitTest.Assert.Inconclusive(message);
        }

        public void Inconclusive(string message, params object[] parameters)
        {
            VSUnitTest.Assert.Inconclusive(message, parameters);
        }

        public void IsFalse(bool condition)
        {
            VSUnitTest.Assert.IsFalse(condition);
        }

        public void IsFalse(bool condition, string message)
        {
            VSUnitTest.Assert.IsFalse(condition, message);
        }

        public void IsFalse(bool condition, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsFalse(condition, message, parameters);
        }

        public void IsInstanceOfType(object value, Type expectedType)
        {
            VSUnitTest.Assert.IsInstanceOfType(value, expectedType);
        }

        public void IsInstanceOfType(object value, Type expectedType, string message)
        {
            VSUnitTest.Assert.IsInstanceOfType(value, expectedType, message);
        }

        public void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsInstanceOfType(value, expectedType, message, parameters);
        }

        public void IsNotInstanceOfType(object value, Type wrongType)
        {
            VSUnitTest.Assert.IsNotInstanceOfType(value, wrongType);
        }

        public void IsNotInstanceOfType(object value, Type wrongType, string message)
        {
            VSUnitTest.Assert.IsNotInstanceOfType(value, wrongType, message);
        }

        public void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsNotInstanceOfType(value, wrongType, message, parameters);
        }

        public void IsNotNull(object value)
        {
            VSUnitTest.Assert.IsNotNull(value);
        }

        public void IsNotNull(object value, string message)
        {
            VSUnitTest.Assert.IsNotNull(value, message);
        }

        public void IsNotNull(object value, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsNotNull(value, message, parameters);
        }

        public void IsNull(object value)
        {
            VSUnitTest.Assert.IsNull(value);
        }

        public void IsNull(object value, string message)
        {
            VSUnitTest.Assert.IsNull(value, message);
        }

        public void IsNull(object value, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsNull(value, message, parameters);
        }

        public void IsTrue(bool condition)
        {
            VSUnitTest.Assert.IsTrue(condition);
        }

        public void IsTrue(bool condition, string message)
        {
            VSUnitTest.Assert.IsTrue(condition, message);
        }

        public void IsTrue(bool condition, string message, params object[] parameters)
        {
            VSUnitTest.Assert.IsTrue(condition, message, parameters);
        }

        public string ReplaceNullChars(string input)
        {
            return VSUnitTest.Assert.ReplaceNullChars(input);
        }

        public T ThrowsException<T>(Action action) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action);
        }

        public T ThrowsException<T>(Func<object> action) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action);
        }

        public T ThrowsException<T>(Action action, string message) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action, message);
        }

        public T ThrowsException<T>(Func<object> action, string message) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action, message);
        }

        public T ThrowsException<T>(Action action, string message, params object[] parameters) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action, message, parameters);
        }

        public T ThrowsException<T>(Func<object> action, string message, params object[] parameters) where T : Exception
        {
            return VSUnitTest.Assert.ThrowsException<T>(action, message, parameters);
        }
    }
}
