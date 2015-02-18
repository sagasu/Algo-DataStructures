using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.List
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        private SimpleLinkedListNode<T> _head;
        private SimpleLinkedListNode<T> _tail;
            
        public void Add(T t)
        {
            if (_tail == null)
            {
                _tail = new SimpleLinkedListNode<T>(t, null, null);
                _head = _tail;
                return;
            }

            _tail = _tail.Add(t);
        }

        public void Add(T t, int index)
        {
            if (index == 0)
            {
                Add(t);
                return;
            }

            PerformActionOnIndexElement(--index, _head, _ => _.Add(t));
        }

        public void Remove(int index)
        {
            _head = PerformActionOnIndexElement(index, _head, _ => _.Remove());
        }

        private SimpleLinkedListNode<T> PerformActionOnIndexElement(int index, SimpleLinkedListNode<T> current, Func<SimpleLinkedListNode<T>, SimpleLinkedListNode<T>> func)
        {
            if (index == 0)
            {
                return func(current);
            }

            if (current == null || current.Next == null) throw new ArgumentException("List doesn't have so many elements.");

            return PerformActionOnIndexElement(--index, current.Next, func);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Current;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
