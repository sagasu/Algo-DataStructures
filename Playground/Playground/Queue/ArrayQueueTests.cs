using System;
using NUnit.Framework;

namespace Playground.Queue
{
    [TestFixture]
    public class ArrayQueueTests
    {
        [Test]
        public void Push_OneElement_ShouldReturnInWhenPop()
        {
            var aq = new ArrayQueue<bool>();
            aq.Push(true);

            Assert.AreEqual(true, aq.Pop());
            Assert.Throws<InvalidOperationException>(() => aq.Pop());
        }

        [Test]
        public void Push_OneElement_ShouldReturnItWhenPeek()
        {
            var aq = new ArrayQueue<bool>();
            aq.Push(true);

            Assert.AreEqual(true, aq.Peek());
        }
    }
}
