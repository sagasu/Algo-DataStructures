using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_Arithmetic_Subsequence
{
    internal class Longest_Arithmetic_Subsequence
    {
        public int LongestArithSeqLength(int[] nums)
        {
            var ans = 1;
            var dic = new Dictionary<int, int>[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                dic[i] = new Dictionary<int, int>();

                for (var j = 0; j < i; j++)
                {
                    var diff = nums[i] - nums[j];

                    if (dic[j].ContainsKey(diff))
                        dic[i][diff] = dic[j][diff] + 1;
                    else
                        dic[i][diff] = 1;

                    ans = Math.Max(ans, dic[i][diff]);
                }
            }

            return ans + 1;
        }
    }
}
