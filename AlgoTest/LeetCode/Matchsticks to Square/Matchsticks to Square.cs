using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Matchsticks_to_Square
{
    internal class Matchsticks_to_Square
    {
        public bool Makesquare(int[] matchsticks)
        {
            var sum = matchsticks.Sum();
            if (sum % 4 != 0) return false;
            var l = sum / 4;
            Array.Sort(matchsticks);
            Array.Reverse(matchsticks);

            bool Travers(int i, int a, int b, int c, int d)
            {
                if (a > l || b > l || c > l || d > l) return false;
                if (i >= matchsticks.Length) return a == b && a == c && a == d;
                return
                    Travers(i + 1, a + matchsticks[i], b, c, d) ||
                    Travers(i + 1, a, b + matchsticks[i], c, d) ||
                    Travers(i + 1, a, b, c + matchsticks[i], d) ||
                    Travers(i + 1, a, b, c, d + matchsticks[i]);
            }

            return Travers(0, 0, 0, 0, 0);
        }
    }
}
