using System;

namespace AlgoTest.LeetCode.House_Robber_II;

public class House_Robber_II
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        
        int RobHouses(int from, int to)
        {
            var rob1 = 0;
            var rob2 = 0;
            for (var i = from; i < to; i++)
            {
                var temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }

        return Math.Max(RobHouses(0, nums.Length - 1), RobHouses(1, nums.Length));
    }
}