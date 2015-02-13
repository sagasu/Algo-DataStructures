using System;
using NUnit.Framework;

namespace Playground.Queue
{
    [TestFixture]
    public class SimpleArrayQueueTests
    {
        [Test]
        public void Push_OneElement_ShouldReturnItWhenPop()
        {
            var saq = new SimpleArrayQueue<bool>();
            saq.Push(true);

            Assert.AreEqual(true, saq.Pop());
            Assert.Throws<ArgumentOutOfRangeException>(() => saq.Pop());
        }

        [Test]
        public void Push_OneElement_ShouldReturnItWhenPeek()
        {
            var saq = new SimpleArrayQueue<bool>();
            saq.Push(true);

            Assert.AreEqual(true, saq.Peek());
        }
    }
}
