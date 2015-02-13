using System.Collections.Generic;
using NUnit.Framework;

namespace Playground.Stack
{
    [TestFixture]
    public class ImmutableStackTests
    {
        [Test]
        public void Push_OneElement_ShouldReturnInOnTop()
        {
            var immutableStack = ImmutableStack<bool>.Empty.Push(true);

            Assert.AreEqual(true, immutableStack.Top);
        }

        [Test]
        public void Pop_PopAndTop_ShouldReturnFirstPushedElement()
        {
            var immutableStack = ImmutableStack<bool>.Empty.Push(false).Push(true);

            Assert.AreEqual(false, immutableStack.Pop().Top);
        }

        [Test]
        public void ImmutableStack_Iterator_ShouldReturnAllElementsInOrder()
        {
            var immutableStack = ImmutableStack<bool>.Empty.Push(true).Push(false).Push(false);

            using (var actualEnumerator = immutableStack.GetEnumerator())
            using (var expectedEnumerator = new List<bool> { true, false, false }.GetEnumerator())
            {
                while (actualEnumerator.MoveNext() && expectedEnumerator.MoveNext())
                {
                    Assert.AreEqual(actualEnumerator.Current, expectedEnumerator.Current);
                }
            }
        }
    }
}
