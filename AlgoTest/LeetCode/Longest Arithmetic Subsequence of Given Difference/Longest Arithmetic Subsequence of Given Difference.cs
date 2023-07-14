using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_Arithmetic_Subsequence_of_Given_Difference
{
    internal class Longest_Arithmetic_Subsequence_of_Given_Difference
    {
        public int LongestSubsequence(int[] arr, int difference)
        {
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                {
                    var value = dic[arr[i]] + 1;
                    dic.Remove(arr[i]);
                    if (dic.ContainsKey(arr[i] + difference))
                        dic[arr[i] + difference] = Math.Max(value, dic[arr[i] + difference]);
                    else dic.Add(arr[i] + difference, value);
                }
                else if (!dic.ContainsKey(arr[i] + difference))
                    dic.Add(arr[i] + difference, 1);
            }

            return dic.Values.Max();
        }
    }
}
