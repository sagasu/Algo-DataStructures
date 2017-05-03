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

        [DataTestMethod]
        [DataRow(10, 10, "Foo")]
        public void TestTuples_NestingTuple_ExpectReturningNestedTuple(int a, double b, string c)
        {
            var (returnedInt, (returnedDouble, returnedString)) = GetNestedTuple(a, b, c);
            Assert.AreEqual(a, returnedInt);
            Assert.AreEqual(b, returnedDouble);
            Assert.AreEqual(c, returnedString);
        }

        private (int a, (double b, string c)) GetNestedTuple(int a, double b, string c)
        {
            return (a, (b, c));
        }

        // need to install System.ValueType to make it work
        (int a, string b) returnSample()
        {
            return (2, "foo");
        }
    }
}
