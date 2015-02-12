using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.Stack
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] _items;
        private const int DefaultSize = 4;
        private int _nrOfElements = 0;
        
        public ArrayStack()
        {
            _items = new T[DefaultSize];
        }

        public bool IsEmpty()
        {
            return _nrOfElements == 0;
        }

        public T Top()
        {
            return _items[_nrOfElements - 1];
        }

        public T Pop()
        {
            _nrOfElements -= 1;
            return _items[_nrOfElements];
        }

        public void Push(T item)
        {
            if (_items.Length == _nrOfElements)
            {
                var destinationArray = new T[_items.Length*2];
                Array.Copy(_items, destinationArray, _items.Length);
                _items = destinationArray;
            }
            _items[_nrOfElements] = item;
            _nrOfElements += 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (!this.IsEmpty())
            {
                yield return this.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
