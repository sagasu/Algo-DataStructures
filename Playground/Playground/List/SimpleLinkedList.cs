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

        public void Add(int index)
        {

        }

        public void Remove(int index)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_head.Next != null)
            {
                yield return _head.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
