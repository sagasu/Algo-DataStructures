using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.NullConditionalOperator
{
    [TestFixture]
    public class OperatorTests
    {
        private int _notCalled = 0;

        [SetUp]
        public void Setup()
        {
            _notCalled = 0;
        }

        public static string Truncate(string value, int length)
        {
            return value?.Substring(0, Math.Min(value.Length, length));
        }

        public string TruncateWithInternalMethod(string value, int length)
        {
            return value?.Substring(0, GetLength());
        }

        // This method should not be called
        private  int GetLength()
        {
            _notCalled = 5;
            return 5;
        }

        [Test]
        public void Truncate_WithNull_ReturnsNull()
        {
            Assert.AreEqual(null, Truncate(null, 42));
        }

        [Test]
        public void TruncateWithInternalMethod_WithNull_ReturnsNull()
        {
            Assert.AreEqual(_notCalled, 0);
            Assert.AreEqual(null, TruncateWithInternalMethod(null, 42));
        }
    }
}
