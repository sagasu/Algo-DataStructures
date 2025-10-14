using System.Collections.Generic;

namespace AlgoTest.LeetCode.Adjacent_Increasing_Subarrays_Detection_I;

public class Adjacent_Increasing_Subarrays_Detection_I
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        var currentSequenceLength = 1;
        var previousSequenceLength = 0;

        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i - 1] < nums[i])
            {
                currentSequenceLength++;
            }
            else
            {
                previousSequenceLength = currentSequenceLength;
                currentSequenceLength = 1;
            }

            if ((currentSequenceLength >= k * 2) || (currentSequenceLength >= k && previousSequenceLength >= k))
            {
                return true;
            }
        }

        return false;
    }
}