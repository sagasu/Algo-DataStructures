using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Divide_Two_Integers
{
    internal class Divide_Two_Integers
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return int.MaxValue;
            var sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
            long m = Math.Abs((long)dividend), n = Math.Abs((long)divisor), count = 0;

            for (m -= n; m >= 0; m -= n)
            {
                count++;
                if (m == 0) break;

                for (var subCount = 1; m - (n << subCount) >= 0; subCount++)
                {
                    m -= n << subCount;
                    count += (int)Math.Pow(2, subCount);
                }
            }

            return count * sign > int.MaxValue ? int.MaxValue : (int)count * sign;
        }
    }
}
