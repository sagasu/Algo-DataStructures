using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Average_Salary_Excluding_the_Minimum_and_Maximum_Salary
{
    internal class Average_Salary_Excluding_the_Minimum_and_Maximum_Salary
    {
        public double Average(int[] salary)
        {
            var max = int.MinValue;
            var min = int.MaxValue;

            foreach (var s in salary)
            {
                min = Math.Min(min, s);
                max = Math.Max(max, s);
            }

            long sum = 0;

            foreach (var s in salary)
                if (s != min && s != max)
                    sum += s;
            

            return sum / (double)(salary.Length - 2);
        }
    }
}
