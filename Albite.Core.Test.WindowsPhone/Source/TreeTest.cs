﻿using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.WindowsPhone
{
    [TestClass]
    public class TreeTest : UnitTest
    {
        private readonly Test.TreeTest _test = new Test.TreeTest();

        [TestMethod]
        public void SimpleTreeTest()
        {
            _test.SimpleTreeTest();
        }
    }
}
