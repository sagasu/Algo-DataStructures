using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Playground.Stack
{
    [TestFixture]
    public class ArrayStackTests
    {
        [Test]
        public void Push_OneElement_ShouldBeReturnedWhenPop()
        {
            var arrayStack = new ArrayStack<bool>();
            arrayStack.Push(true);

            Assert.AreEqual(true, arrayStack.Pop());
        }
        
        [Test]
        public void Push_MoreThanFiveElements_ShouldBeReturnedWhenPop()
        {
            var arrayStack = new ArrayStack<bool>();
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);

            Assert.AreEqual(true, arrayStack.Pop());
            Assert.AreEqual(true, arrayStack.Pop());
            Assert.AreEqual(true, arrayStack.Pop());
            Assert.AreEqual(true, arrayStack.Pop());
            Assert.AreEqual(true, arrayStack.Pop());
        }
        
        [Test]
        public void Push_MoreThanFiveElements_ShouldEnumeratorWork()
        {
            var arrayStack = new ArrayStack<bool>();
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);
            arrayStack.Push(true);

            using (var actualEnumerator = arrayStack.GetEnumerator())
            using (var expectedEnumerator = new List<bool> { true, true, true, true, true }.GetEnumerator())
            {
                while (actualEnumerator.MoveNext() && expectedEnumerator.MoveNext())
                {
                    Assert.AreEqual(actualEnumerator.Current, expectedEnumerator.Current);
                }
            }
        }

        [Test]
        public void Top_EmptyStack_ThrowsException()
        {
            var arrayStack = new ArrayStack<bool>();
            Assert.Throws<IndexOutOfRangeException>(() => arrayStack.Top());
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var arrayStack = new ArrayStack<bool>();
            Assert.Throws<IndexOutOfRangeException>(() => arrayStack.Top());
        }

        [Test]
        public void Enumerator_EmptyStack_ReturnsFalse()
        {
            var arrayStack = new ArrayStack<bool>();
            // Cool behavior
            Assert.IsFalse(arrayStack.GetEnumerator().Current);
        }
    }
}
