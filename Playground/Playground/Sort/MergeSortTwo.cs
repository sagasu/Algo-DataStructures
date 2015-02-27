using System.Collections.Generic;
using System.Linq;

namespace Playground.Sort
{
    public class MergeSortTwo<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> elements)
        {
            var items = elements as IList<T> ?? elements.ToList();
            if (items.Count < 2) return items;

            return items;
        }
    }
}
