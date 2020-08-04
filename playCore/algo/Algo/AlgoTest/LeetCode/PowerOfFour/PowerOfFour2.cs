using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PowerOfFour
{
    class PowerOfFour2
    {
        public bool IsPowerOfFour(int num)
        {
            return num > 0 && (Math.Log10(num) / Math.Log10(4)) % 1 == 0;
        }
    }
}
