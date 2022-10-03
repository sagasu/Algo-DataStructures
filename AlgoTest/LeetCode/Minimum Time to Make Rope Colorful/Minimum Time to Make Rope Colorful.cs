using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Time_to_Make_Rope_Colorful
{
    internal class Minimum_Time_to_Make_Rope_Colorful
    {
        public int MinCost(string colors, int[] neededTime)
        {

            var sum = neededTime[0];
            var max = neededTime[0];
            var result = 0;

            for (var i = 1; i < colors.Length; i++)
            {
                if (colors[i - 1] == colors[i])
                {
                    sum += neededTime[i];
                    max = Math.Max(max, neededTime[i]);
                }
                else
                {
                    result += sum - max;
                    sum = max = neededTime[i];
                }
            }

            result += sum - max;
            return result;
        }
    }
}
