using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.NumbersWithSameConsecutiveDifferences
{
    class NumbersWithSameConsecutiveDifferences
    {
        public int[] NumsSameConsecDiff(int N, int K)
        {
            var results = new HashSet<int>();
            for (var i = 1; i < 10; i++)
                Dfs(0, i);
            if (N == 1) results.Add(0);
            return results.ToArray();

            void Dfs(int index, int val)
            {
                if (index == N - 1)
                {
                    results.Add(val);
                    return;
                }
                var digit = val % 10;
                if (digit - K >= 0) Dfs(index + 1, (val * 10) + (digit - K));
                if (digit + K <= 9) Dfs(index + 1, (val * 10) + (digit + K));
            }
        }
    }
}
