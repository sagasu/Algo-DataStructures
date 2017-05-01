using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class DigitSeparator
    {
        [TestMethod]
        public void DigitSeparator_ExpectItToBeSame()
        {

            Assert.AreEqual(1_000_000, 1000000);

        }
    }
}
