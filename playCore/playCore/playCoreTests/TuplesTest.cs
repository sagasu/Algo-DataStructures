using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class TuplesTest
    {

        [TestMethod]
        public void TestTuples_ReturnedAsTwoVariables_ExpectAutoCastingToWork()
        {
            var (a, b) = returnSample();
            Assert.AreEqual(2, a);
            Assert.AreEqual("foo", b);
        }

        [TestMethod]
        public void TestTuples_ReturnedAsSingleVariable_ExpectedToSplitItNicely()
        {
            var tuple = returnSample();
            Assert.AreEqual(2, tuple.a);
            Assert.AreEqual("foo", tuple.b);
        }

        // need to install System.ValueType to make it work
        (int a, string b) returnSample()
        {
            return (2, "foo");
        }
    }
}
