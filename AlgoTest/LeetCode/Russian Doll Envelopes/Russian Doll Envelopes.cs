using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Russian_Doll_Envelopes
{
    internal class Russian_Doll_Envelopes
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            var n = envelopes.Length;

            if (n == 0) return 0;

            Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));

            var sortedByHeightList = new List<int>();
            sortedByHeightList.Add(envelopes[0][1]);

            for (var i = 1; i < n; i++)
            {
                (int width, int height) cur = (envelopes[i][0], envelopes[i][1]);

                var left = 0;
                var right = sortedByHeightList.Count;

                while (left < right)
                {
                    var mid = left + (right - left) / 2;

                    if (sortedByHeightList[mid] < cur.height) left = mid + 1;
                    else right = mid;
                }

                if (right >= sortedByHeightList.Count)
                {
                    sortedByHeightList.Add(cur.height);
                }
                else
                {
                    sortedByHeightList[right] = cur.height;
                }
            }

            return sortedByHeightList.Count;
        }
    }
}
