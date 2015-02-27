using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Sort
{
    public class MergeSort<T> where T : IComparable<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> elements)
        {
            var enumerable = elements as IList<T> ?? elements.ToList();

            if (!enumerable.Any()) return enumerable;

            var firstElement = enumerable.First();
            return Sort(enumerable.Skip(1), firstElement);
        }

        // It is more QuickSort, because it first sorts than it goes deeper
        private static IList<T> Sort(IEnumerable<T> elements, T mediumElement)
        {
            var sortNode = Split(elements, mediumElement);

            IList<T> sortedSmallerValues;
            IList<T> sortedGreaterValues;
            if (sortNode.SmallerValues.Count > 1)
            {
                var firstSmallerValue = sortNode.SmallerValues.First();
                sortedSmallerValues = Sort(sortNode.SmallerValues.Skip(1), firstSmallerValue);
            }
            else
            {
                sortedSmallerValues = sortNode.SmallerValues;
            }

            if (sortNode.GreaterValues.Count > 1)
            {
                var firstGreaterValue = sortNode.GreaterValues.First();
                sortedGreaterValues = Sort(sortNode.GreaterValues.Skip(1), firstGreaterValue);
            }
            else
            {
                sortedGreaterValues = sortNode.GreaterValues;
            }

            return Merge(mediumElement, sortedSmallerValues, sortedGreaterValues);
        }

        private static List<T> Merge(T mediumElement, IEnumerable<T> sortedSmallerValues, IEnumerable<T> sortedGreaterValues)
        {
            var sorted = new List<T>();
            sorted.AddRange(sortedSmallerValues);
            sorted.Add(mediumElement);
            sorted.AddRange(sortedGreaterValues);
            return sorted;
        }

        private static SortNode Split(IEnumerable<T> elements, T mediumElement)
        {
            var sortNode = new SortNode();
            foreach (var element in elements)
            {
                if (element.CompareTo(mediumElement) < 0)
                {
                    sortNode.SmallerValues.Add(element);
                }
                else
                {
                    sortNode.GreaterValues.Add(element);
                }
            }
            return sortNode;
        }

        private class SortNode
        {
            public IList<T> SmallerValues { get; set; }
            public IList<T> GreaterValues { get; set; }

            public SortNode()
            {
                SmallerValues = new List<T>();
                GreaterValues = new List<T>();
            }
        }
    }
}
