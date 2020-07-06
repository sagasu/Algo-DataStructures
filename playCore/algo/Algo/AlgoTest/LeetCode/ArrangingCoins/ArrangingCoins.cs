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

            var current = 1;
            var taken = 1;
            var count = 1;
            while (true)
            {
                var newLimit = current + 1;
                taken += newLimit;
                if (taken <= n)
                {
                    count += 1;
                    current = newLimit;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
