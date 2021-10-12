using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Guess_Number_Higher_or_Lower
{
    class Guess_Number_Higher_or_Lower
    {
        public int GuessNumber(int n)
        {
            var left = 1;
            var right = n;

            while (left <= right)
            {
                var mid = (right - left) / 2 + left;

                var res = guess(mid);
                if (res == 0) return mid;
                else if (res == -1)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        private int guess(int mid)
        {
            return 1;
        }
    }
}
