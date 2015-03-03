using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Sort
{
    public class QuickSortArray<T> where T : IComparable<T>
    {
        public IEnumerable<T> Sort(List<T> elements)
        {
            return !elements.Any() ? elements : Sort(elements, elements.Count - 1, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="hi">Index of highest element in array</param>
        /// <param name="lo">Index of lowest element in array</param>
        /// <returns></returns>
        public IEnumerable<T> Sort(List<T> elements, int lo, int hi)
        {
            var pivotIndex = Partition(elements, hi, lo);
            if (pivotIndex > 0 && lo < hi)
            {
                Sort(elements, lo, pivotIndex - 1);
            }
            if (pivotIndex < hi && lo < hi)
            {
                Sort(elements, pivotIndex + 1, hi);
            }
            return elements;
        }

        private static int Partition(List<T> elements, int hi, int lo)
        {
            var pivotIndex = hi;
            while (hi > lo)
            {
                if (Comparer<T>.Default.Compare(elements[lo],elements[pivotIndex]) > 0)
                {
                    Swap(elements, lo, pivotIndex);
                    var tempIndex = lo;
                    lo = pivotIndex;
                    pivotIndex = tempIndex;
                }

                if (Comparer<T>.Default.Compare(elements[hi], elements[pivotIndex]) < 0)
                {
                    Swap(elements, hi, pivotIndex);
                    var tempIndex = hi;
                    hi = pivotIndex;
                    pivotIndex = tempIndex;
                }

                --hi;
                ++lo;
            }
            return pivotIndex;
        }

        private static void Swap(IList<T> elements, int a, int b)
        {
            var temp = elements[a];
            elements[a] = elements[b];
            elements[b] = temp;
        }
    }
}
