using System.Collections;
using System.Collections.Generic;

namespace Playground.Stack
{
    /// <summary>
    /// My favorite stack impl. there is so much OO paradigm patterns and methods applied here, that I always enjoyed writing such code.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ImmutableStack<T> : IEnumerable<T>
    {
        public static readonly ImmutableStack<T> Empty = new EmptyStack();
        public abstract ImmutableStack<T> Pop();
        public abstract T Top { get; }
        public abstract bool IsEmpty { get; }

        public ImmutableStack<T> Push(T t)
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

        private class EmptyStack : ImmutableStack<T>
        {
            public override ImmutableStack<T> Pop()
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

        private class NonEmptyStack : ImmutableStack<T>
        {
            private readonly T _head;
            private readonly ImmutableStack<T> _tail;

            public NonEmptyStack(T t, ImmutableStack<T> immutableStack)
            {
                _head = t;
                _tail = immutableStack;
            }

            public override ImmutableStack<T> Pop()
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
