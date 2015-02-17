using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.List
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        private readonly SimpleLinkedListNode<T> _head;
        private SimpleLinkedListNode<T> _tail;

        public SimpleLinkedList()
        {
            _head = new SimpleLinkedListNode<T>();
            _tail = _head;
        }
            
        public void Add(T t)
        {
            _tail = _tail.Add(t);
        }

        public void Add(T t, int index)
        {
            PerformActionOnIndexElement(index, _head, _ => _.Add(t));
        }

        public void Remove(int index)
        {
            PerformActionOnIndexElement(index, _head, _ => _.Remove());
        }

        private void PerformActionOnIndexElement(int index, SimpleLinkedListNode<T> current, Action<SimpleLinkedListNode<T>> action)
        {
            if (index == 0)
            {
                action(current);
                return;
            }

            if (current.Next == null) throw new ArgumentException("List doesn't have so many elements.");

            PerformActionOnIndexElement(--index, current.Next, action);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current.Next != null)
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
