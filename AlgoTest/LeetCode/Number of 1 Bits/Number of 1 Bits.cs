using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_1_Bits
{
    internal class Number_of_1_Bits
    {
        public int HammingWeight(uint n)
        {
            int result = 0;
            while (n > 0)
            {
                result += (int)n & 1;
                n = n >> 1;
            }

            return result;
        }
    }
}
