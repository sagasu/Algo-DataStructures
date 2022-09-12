using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Bag_of_Tokens
{
    internal class Bag_of_Tokens
    {
        public int BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);
            if (tokens.Length == 0 || power < tokens[0]) return 0;
            var points = 0;
            var ans = 0;
            int left = 0, right = tokens.Length - 1;
            while (left <= right)
            {
                if (power >= tokens[left])
                {
                    points++;
                    power -= tokens[left];
                    left++;
                }
                else if (right - left > 1)
                {
                    power += tokens[right];
                    right--;
                    points--;
                }
                else break;
            }
            return points;
        }
    }
}
