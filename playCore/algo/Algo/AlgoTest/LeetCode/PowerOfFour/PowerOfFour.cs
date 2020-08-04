using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PowerOfFour
{
    public class PowerOfFour
    {
        public bool IsPowerOfFour(int num)
        {
            if (num == 0)
                return false;

            if (num % 4 != 0)
                return false;

            if (num < 0)
                return false;

            if (num == 1)
                return true;

            return IsPowerOfFour(num, 4);
        }

        public bool IsPowerOfFour(int num, int acc)
        {
            if (acc > num)
                return false;

            if (acc == num)
                return true;

            return IsPowerOfFour(num, acc * 4);
        }
    }
}
