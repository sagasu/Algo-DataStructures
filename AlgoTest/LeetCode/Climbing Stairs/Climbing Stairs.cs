using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Climbing_Stairs
{
    class Climbing_Stairs
    {
        public int ClimbStairs(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            var prePre = 1;
            var pre = 2;

            for (var i = 2; i < n; i++)
            {
                var cur = prePre + pre;
                prePre = pre;
                pre = cur;
            }

            return pre;
        }
    }
}
