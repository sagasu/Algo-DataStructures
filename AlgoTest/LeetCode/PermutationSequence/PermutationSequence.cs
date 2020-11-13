using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PermutationSequence
{
    class PermutationSequence
    {
        public string GetPermutation(int n, int k)
        {
            var factorial = new int[n + 1];
            var arr = new List<int>();

            factorial[0] = 1;
            for (var i = 1; i <= n; i++)
            {
                factorial[i] = factorial[i - 1] * i;
                arr.Add(i);
            }

            k-=1;
            var sb = new StringBuilder();
            for (var i = 1; i <= n; i++)
            {
                var index = k / factorial[n - i];
                sb.Append(arr[index]);
                arr.RemoveAt(index);
                k -= index * factorial[n - i];
            }

            return sb.ToString();
        }
    }
}
