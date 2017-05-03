using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class DigitSeparatorTest
    {
        [TestMethod]
        public void DigitSeparator_ExpectItToBeSame()
        {

            Assert.AreEqual(1_000_000, 1000000);

        }
    }
}
