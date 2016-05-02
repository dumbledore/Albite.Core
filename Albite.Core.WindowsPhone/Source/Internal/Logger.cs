﻿using Albite.Core.Diagnostics;
using VSUnitTest = Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Core.Test.Internal
{
    internal class Logger : ILogger
    {
        public static readonly ILogger Instance = new Logger();

        private Logger() { }

        public void LogMessage(string format, params object[] args)
        {
            VSUnitTest.Logger.LogMessage(format, args);
        }
    }
}
