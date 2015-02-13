using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.Queue
{
    /// <summary>
    /// Difference between this and SimpleArrayQueue is this one grows in size and doesn't frees the memory upon Pop
    /// thanks to that Pop is faster.
    /// </summary>
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private int _nrOfElements = 0;
        private int _head = 0;
        private const int DefaultSize = 4;
        private const string NoMoreElementsInQueue = "No more elements in Queue";
        private T[] _items;

        public ArrayQueue()
        {
            _items = new T[DefaultSize];
        }

        public bool IsEmpty()
        {
            return _nrOfElements - _head == 0;
        }

        public T Pop()
        {
            if (_nrOfElements - _head < 1) throw new InvalidOperationException(NoMoreElementsInQueue);
            var poppedItem = _items[_head];
            _head++;
            _nrOfElements--;
            return poppedItem;
        }

        public T Peek()
        {
            if (_nrOfElements - _head < 1) throw new InvalidOperationException(NoMoreElementsInQueue);
            return _items[_head];
        }

        public void Push(T t)
        {
            if (_items.Length == _nrOfElements - _head)
            {
                var destinationArray = new T[2*(_nrOfElements - _head)];
                Array.Copy(_items, _head, destinationArray, 0, _items.Length);
                _items = destinationArray;
            }
            _items[_nrOfElements] = t;
            _nrOfElements++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) _items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
