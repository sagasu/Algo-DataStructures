using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Swaps_to_Group_All_1_s_Together_II;

public class Minimum_Swaps_to_Group_All_1_s_Together_II
{
    public int MinSwaps(int[] nums) {
        var count = nums.Count(t => t == 1);

        var numOfZeros = 0;
        for (int i = 0; i < count; i++)
            if (nums[i] == 0) numOfZeros++;
        
        var rs = numOfZeros;
        
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] == 0) numOfZeros--;
            if (nums[(i + count - 1) % nums.Length] == 0) numOfZeros++;
            if (rs > numOfZeros) rs = numOfZeros;
        }
        
        return rs;
    }
}