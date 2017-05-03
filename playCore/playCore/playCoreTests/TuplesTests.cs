using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class Tuples
    {

        [TestMethod]
        public void TestTuples()
        {
            var (a, b) = returnSample();
            Assert.AreEqual(2, a);
            Assert.AreEqual("foo", b);
        }

        // need to install System.ValueType to make it work
        (int a, string b) returnSample()
        {
            return (2, "foo");
        }
    }
}
