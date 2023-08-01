using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Combinations
{
    internal class Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var list = new List<IList<int>>();

            Backtrack(list, new List<int>(), n, k, 1);

            return list;
        }

        void Backtrack(List<IList<int>> list, List<int> temp, int n, int k, int start)
        {
            if (temp.Count == k) list.Add(new List<int>(temp));

            for (var i = start; i <= n; i++)
            {
                temp.Add(i);

                Backtrack(list, temp, n, k, i + 1);

                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
