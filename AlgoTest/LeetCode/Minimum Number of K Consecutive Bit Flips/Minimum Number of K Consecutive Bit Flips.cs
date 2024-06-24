namespace AlgoTest.LeetCode.Minimum_Number_of_K_Consecutive_Bit_Flips;

public class Minimum_Number_of_K_Consecutive_Bit_Flips
{
    public int MinKBitFlips(int[] nums, int k) {
        var flipped = new bool[nums.Length];
        var validFlipsFromPastWindow = 0;
        var flipCount = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i >= k)
            {
                if (flipped[i - k])
                    validFlipsFromPastWindow--;
            }

            if (validFlipsFromPastWindow % 2 != nums[i]) continue;
            if (i + k > nums.Length)
                return -1;
                
            validFlipsFromPastWindow++;
            flipped[i] = true;
            flipCount++;
        }
        return flipCount;
    }
}