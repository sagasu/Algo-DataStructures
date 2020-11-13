using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ArrangingCoins
{
    class ArrangingCoinsProblem
    {
        public int ArrangeCoins(int n)
        {
            if (n == 1 || n == 0)
                return n;

            var count = 1;
            while (n > 0)
            {
                n = n - count;
                if (n < 0)
                    break;
                count += 1;
            }

            return count - 1;
        }
    }
}
