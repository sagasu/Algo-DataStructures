using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Flips_to_Make_a_OR_b_Equal_to_c
{
    internal class Minimum_Flips_to_Make_a_OR_b_Equal_to_c
    {
        public int MinFlips(int a, int b, int c)
        {
            var count = 0;

            while (a != 0 || b != 0 || c != 0)
            {
                int bitA = a & 1,
                    bitB = b & 1,
                    bitC = c & 1;

                if ((bitA | bitB) != bitC)
                {
                    if (bitA != bitB || (bitA == 0 && bitB == 0)) count++;
                    else if (bitA == bitB) count += 2;
                }

                a = a >> 1;
                b = b >> 1;
                c = c >> 1;
            }

            return count;
        }
    }
}
