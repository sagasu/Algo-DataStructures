using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.BrokenCalculator
{
    class BrokenCalculator
    {
        public int BrokenCalc(int X, int Y)
        {
            if (X >= Y) return X - Y;

            var steps = 0;
            while (X < Y)
            {
                if (Y % 2 == 1)
                    Y += 1;
                else
                    Y /= 2;

                steps += 1;
            }

            return steps + (X - Y);
        }
    }
}
