using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.Queue
{
    public class SimpleArrayQueue<T> : IEnumerable<T>
    {
        private int _nrOfElements = 0;
        private const int DefaultSize = 4;
        private T[] items;

        public SimpleArrayQueue()
        {
            items = new T[DefaultSize];
        }

        public void Push(T t)
        {
            if (_nrOfElements == items.Length)
            {
                var destinationArray = new T[_nrOfElements * 2];
                Array.Copy(items,destinationArray, _nrOfElements - 1);
                items = destinationArray;
            }
            items[_nrOfElements] = t;
            _nrOfElements += 1;
        }

        /// <remarks>
        /// Most heavy operation, because we copy entire array each time when we pop.
        /// Also we resize array to nrOfElements, so next time when something is pushed we need to resize it again.
        /// </remarks>
        public T Pop()
        {
            var poppedItem = items[0];
            var destinationArray = new T[_nrOfElements];
            Array.Copy(items, 1, destinationArray, 0, _nrOfElements - 1);
            items = destinationArray;
            _nrOfElements -= 1;
            return poppedItem;
        }

        public T Peek()
        {
            return items[0];
        }

        public bool IsEmpty()
        {
            return _nrOfElements == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
