using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Playground.Stack
{
    [TestFixture]
    public class VerbatimStackTests
    {
        [Test]
        public void VerbatimStack_PushOneElement_ShouldReturnInOnTop()
        {
            var foo = VerbatimStack<bool>.Empty.Push(true);

            Assert.AreEqual(true, foo.Top);
        }

        [Test]
        public void VerbatimStack_PopAndTop_ShouldReturnFirstPushedElement()
        {
            var foo = VerbatimStack<bool>.Empty.Push(false).Push(true);

            Assert.AreEqual(false, foo.Pop().Top);
        }
        
        [Test]
        public void VerbatimStack_Iterator_ShouldReturnAllElementsInOrder()
        {
            var foo = VerbatimStack<bool>.Empty.Push(true).Push(false).Push(false);

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

    public abstract class VerbatimStack<T> : IEnumerable<T>
    {
        public static readonly VerbatimStack<T> Empty = new EmptyStack();
        public abstract VerbatimStack<T> Pop();
        public abstract T Top { get; }
        public abstract bool IsEmpty { get; }

        public VerbatimStack<T> Push(T t)
        {
            return new NonEmptyStack(t, this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.IsEmpty)
            {
                yield return this.Top;
                this.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class EmptyStack : VerbatimStack<T>
        {
            public override VerbatimStack<T> Pop()
            {
                throw new System.NotImplementedException();
            }

            public override T Top
            {
                get { throw new System.NotImplementedException(); }
            }

            public override bool IsEmpty
            {
                get { return true; }
            }
        }

        private class NonEmptyStack : VerbatimStack<T>
        {
            private readonly T _head;
            private readonly VerbatimStack<T> _tail;

            public NonEmptyStack(T t, VerbatimStack<T> verbatimStack)
            {
                _head = t;
                _tail = verbatimStack;
            }

            public override VerbatimStack<T> Pop()
            {
                return _tail;
            }

            public override T Top
            {
                get { return _head; }
            }

            public override bool IsEmpty
            {
                get { return false; }
            }
        }
    }
}
