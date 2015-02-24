using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.List
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Reference to first node;
        /// </summary>
        private SimpleLinkedListNode<T> _head;

        /// <summary>
        /// Reference to last node;
        /// </summary>
        private SimpleLinkedListNode<T> _tail;

        /// <summary>
        /// Number of elements in simple linked list;
        /// </summary>
        private int _count = 0;

        public int Count 
        {
            get { return _count; }
        }

        public void Add(T t)
        {
            _count++;
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
            _count++;
            if (index == 0)
            {
                var newHead = new SimpleLinkedListNode<T>(t, _head, null);
                _head = newHead;
                return;
            }

            var modifiedNode = PerformActionOnIndexElement(--index, _head, _ => _.Add(t));
            if (index == _count - 1)
            {
                _tail = modifiedNode;
            }
        }

        public void Remove(int index)
        {
            _count--;
            var modifiedNode = PerformActionOnIndexElement(index, _head, _ => _.Remove());
            if (modifiedNode != null)
            {
                _head = modifiedNode;
            }
            if (_count == 0)
            {
                _head = null;
            }
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
