using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Last_Stone_Weight
{
    internal class Last_Stone_Weight
    {
        public int LastStoneWeight(int[] stones) => SmashStones(stones, stones.Length - 1);
        
        private int SmashStones(int[] stones, int end)
        {
            if (end < 0) return 0;
            if (end == 0) return stones[end];

            Array.Sort(stones);
            if (stones[end] == stones[end - 1]) return SmashStones(stones, end - 2);
            else
            {
                stones[end - 1] = Math.Abs(stones[end] - stones[end - 1]);
                return SmashStones(stones, end - 1);
            }
        }
    }
}
