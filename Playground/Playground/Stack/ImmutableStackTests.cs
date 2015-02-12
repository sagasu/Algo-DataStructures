using System.Collections.Generic;
using NUnit.Framework;

namespace Playground.Stack
{
    [TestFixture]
    public class ImmutableStackTests
    {
        [Test]
        public void VerbatimStack_PushOneElement_ShouldReturnInOnTop()
        {
            var foo = ImmutableStack<bool>.Empty.Push(true);

            Assert.AreEqual(true, foo.Top);
        }

        [Test]
        public void VerbatimStack_PopAndTop_ShouldReturnFirstPushedElement()
        {
            var foo = ImmutableStack<bool>.Empty.Push(false).Push(true);

            Assert.AreEqual(false, foo.Pop().Top);
        }

        [Test]
        public void VerbatimStack_Iterator_ShouldReturnAllElementsInOrder()
        {
            var foo = ImmutableStack<bool>.Empty.Push(true).Push(false).Push(false);

            using (var e1 = foo.GetEnumerator())
            using (var e2 = new List<bool> { true, false, false }.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    Assert.AreEqual(e1.Current, e2.Current);
                }
            }
        }
    }
}
