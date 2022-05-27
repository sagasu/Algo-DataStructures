using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Steps_to_Reduce_a_Number_to_Zero
{
    internal class Number_of_Steps_to_Reduce_a_Number_to_Zero
    {
        public int NumberOfSteps(int num)
        {
            var count = 0;

            while (num > 0)
            {
                if (num % 2 == 0) num /= 2;
                else num--;

                count++;
            }

            return count;
        }
    }
}
