using Albite.Diagnostics;

namespace Albite.Test
{
    public class UnitTest
    {
        public UnitTest()
        {
            Assert.Current = WindowsPhone.Assert.Instance;
            CollectionAssert.Current = WindowsPhone.CollectionAssert.Instance;
            Logger.Current = WindowsPhone.Logger.Instance;
        }
    }
}
