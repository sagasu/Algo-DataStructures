using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_and_Say
{
    internal class Count_and_Say
    {
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";
            
            var prev = CountAndSay(n - 1);
            var sb = new StringBuilder();
            var count = 1;
            for (var i = 0; i < prev.Length; i++)
            {
                if (i + 1 < prev.Length && prev[i] == prev[i + 1]) count++;
                
                else
                {
                    sb.Append(count + "" + prev[i]);
                    count = 1;
                }
            }
            return sb.ToString();
        }
    }
}
