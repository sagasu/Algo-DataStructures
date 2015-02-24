using System;
using System.Collections;
using System.Collections.Generic;

namespace Playground.List
{
    /// <summary>
    /// User can insert elements anywhere, leaving unallocated spaces - filled with default values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayListInsertAnywhere<T> : IEnumerable<T>
    {
        private int _maxNrOfElements = 4;
        private T[] _elements;
        private int _elementMaxIndex = 0;

        public ArrayListInsertAnywhere()
        {
            _elements = new T[_maxNrOfElements];
        }

        /// <summary>
        /// It is more Set than Add.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="index"></param>
        public void Add(T t, int index)
        {
            if (index > _elementMaxIndex)
                _elementMaxIndex = index;

            if (index >= _maxNrOfElements)
            {
                var multiplyer = Math.Abs(index/_maxNrOfElements) + 1;
                int newNumberOfElements = _maxNrOfElements*multiplyer;
                var newList = new T[newNumberOfElements];
                Array.Copy(_elements, newList, _maxNrOfElements);
                _maxNrOfElements = newNumberOfElements;
                _elements = newList;
            }

            _elements[index] = t;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i <= _elementMaxIndex; i++)
            {
                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
