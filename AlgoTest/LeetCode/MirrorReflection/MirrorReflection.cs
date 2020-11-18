using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.MirrorReflection
{
    public class MirrorReflectionSolution
    {
        public int MirrorReflection(int p, int q)
        {
            if (p == 0) return 0;
            if (q == 0) return 0;

            var lcm = FloorDivision(p * q, GCD(p, q));
            if (FloorDivision(lcm, 2) % p == 0) return 0;
            if (FloorDivision(lcm, 2) % q == 0) return 2;
            return 1;
        }

        int FloorDivision(int a, int b)
        {
            return (a / b - Convert.ToInt32(((a < 0) ^ (b < 0)) && (a % b != 0)));
        }

        int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
