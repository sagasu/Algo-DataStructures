using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PowerOfTwo
{
    class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n == 1)
                return true;

            var pow = 1;
            while (pow < n)
            {
                pow = pow * 2;
            }
            return n == pow;
        }
    }
}
