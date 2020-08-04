using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PowerOfFour
{
    public class PowerOfFour
    {
        public bool IsPowerOfFour(int num)
        {
            if (num == 1)
                return true;

            if (num == 0)
                return false;

            if (num % 4 != 0)
                return false;

            if (num < 0)
                return false;

            return IsPowerOfFour(num / 4);
        }

    }
}
