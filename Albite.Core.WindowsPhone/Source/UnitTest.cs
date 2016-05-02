using Albite.Core.Diagnostics;

namespace Albite.Core.Test
{
    public class UnitTest
    {
        public UnitTest()
        {
            Assert.Current = Internal.Assert.Instance;
            CollectionAssert.Current = Internal.CollectionAssert.Instance;
            Logger.Current = Internal.Logger.Instance;
        }
    }
}
