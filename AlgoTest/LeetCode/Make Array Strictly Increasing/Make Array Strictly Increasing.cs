using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Make_Array_Strictly_Increasing
{
    internal class Make_Array_Strictly_Increasing
    {
        public int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            var array2 = new HashSet<int>(arr2).ToArray();
            Array.Sort(array2);
            var memo = new Dictionary<int, int>[arr1.Length];
            for (int i = 0; i < arr1.Length; i++) memo[i] = new Dictionary<int, int>();
            int res = dfs(arr1, array2, 0, memo);
            return res == int.MaxValue ? -1 : res;
        }

        private int dfs(int[] arr1, int[] arr2, int i, Dictionary<int, int>[] memo)
        {
            if (i >= arr1.Length) return 0;
            var prev = i == 0 ? -1 : arr1[i - 1];
            if (memo[i].ContainsKey(prev))
                return memo[i][prev];

            int j = Array.BinarySearch(arr2, prev);
            j = j < 0 ? ~j : j + 1;

            int score = int.MaxValue;
            if (j < arr2.Length)
            {
                int temp = arr1[i];
                arr1[i] = arr2[j];
                score = dfs(arr1, arr2, i + 1, memo);
                if (score != int.MaxValue) score++;
                arr1[i] = temp;
            }

            if (prev < arr1[i])
                score = Math.Min(score, dfs(arr1, arr2, i + 1, memo));
            memo[i][prev] = score;
            return memo[i][prev];
        }
    }

}
