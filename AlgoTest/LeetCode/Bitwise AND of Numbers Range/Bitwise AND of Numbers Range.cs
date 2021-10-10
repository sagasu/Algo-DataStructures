using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Bitwise_AND_of_Numbers_Range
{
    class Bitwise_AND_of_Numbers_Range
    {
        public int RangeBitwiseAnd(int left, int right)
        {
            var shift = 0;
            while (left < right)
            {
                left >>= 1;
                right >>= 1;
                shift++;
            }
            return left << shift;
        }
    }
}
