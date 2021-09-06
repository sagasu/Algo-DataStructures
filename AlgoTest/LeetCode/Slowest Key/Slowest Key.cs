using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Slowest_Key
{
    class Slowest_Key
    {
        public char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            if (releaseTimes.Length == 0 || string.IsNullOrEmpty(keysPressed)) return '\0';

            var res = keysPressed[0];
            var max = releaseTimes[0];

            for (var i = 1; i < releaseTimes.Length; i++)
                if (releaseTimes[i] - releaseTimes[i - 1] > max || (releaseTimes[i] - releaseTimes[i - 1] == max && keysPressed[i] > res))
                {
                    res = keysPressed[i];
                    max = releaseTimes[i] - releaseTimes[i - 1];
                }

            return res;
        }
    }
}
