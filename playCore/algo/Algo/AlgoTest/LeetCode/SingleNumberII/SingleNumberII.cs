using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.SingleNumberII
{
    public class SingleNumberII
    {
        public int SingleNumber(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num] += 1;
                    if (dic[num] == 3)
                        dic.Remove(num);
                }
                else
                {
                    dic.Add(num,1);
                }
            }

            return dic.First().Value;
        }
    }
}
