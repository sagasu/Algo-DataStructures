using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ReverseInt
{
    class ReverseInt
    {
        public int Reverse(int x)
        {
            var isPositive = true;
            var lastElement = 0;
            if (x < 0)
            {
                isPositive = false;
                lastElement = 1;
            }

            var reversedInt = new StringBuilder();

            var xs = x.ToString();
            for (var i = xs.Length - 1; i >= lastElement; i--)
            {
                reversedInt.Append(xs[i]);
            }

            var revInt = reversedInt.ToString();
            var rev = 0;
            return int.TryParse(revInt, out rev) ? isPositive ? rev : -1 * rev : 0;
        }
    }
}
