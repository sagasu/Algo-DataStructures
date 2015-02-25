using System.Collections.Generic;
using System.Linq;

namespace Playground.Sort
{
    public class QuickSort<T>
    {
        public IEnumerable<T> Sort(List<T> v, IComparer<T> comparer)
        {
            if (v.Count < 2)
                return v;

            var pivot = v[v.Count / 2];

            return Sort(v.Where(x => comparer.Compare(x, pivot) < 0).ToList(), comparer)
                .Concat(new T[] { pivot })
                .Concat(Sort(v.Where(x => comparer.Compare(x, pivot) > 0).ToList(), comparer));
        }
    }
}
