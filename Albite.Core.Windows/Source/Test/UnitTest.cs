using Albite.Diagnostics;

namespace Albite.Test
{
    public class UnitTest
    {
        public UnitTest()
        {
            Assert.Current = Windows.Assert.Instance;
            CollectionAssert.Current = Windows.CollectionAssert.Instance;
            Logger.Current = Windows.Logger.Instance;
        }
    }
}
