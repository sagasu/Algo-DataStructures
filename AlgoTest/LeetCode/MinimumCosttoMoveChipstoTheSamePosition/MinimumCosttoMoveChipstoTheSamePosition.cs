using System;

namespace AlgoTest.LeetCode.MinimumCosttoMoveChipstoTheSamePosition
{
    public class MinimumCosttoMoveChipstoTheSamePosition
    {
        public void Test()
        {

        }

        public int MinCostToMoveChips(int[] position)
        {
            var odd = 0;
            var even = 0;

            foreach (var chipIndex in position)
            {
                if (chipIndex % 2 == 0)
                    even += 1;
                else
                    odd += 1;
            }

            return Math.Min(odd, even);
        }
    }
}
