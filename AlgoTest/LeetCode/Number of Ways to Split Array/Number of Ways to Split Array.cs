using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Ways_to_Split_Array;

public class Number_of_Ways_to_Split_Array
{
    public int WaysToSplitArray(int[] nums) {
        long leftSum = 0;
        var rightSum = nums.Sum(x => (long)x);
        var count = 0;

        for(int i = 0; i < nums.Length-1; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];
            if(leftSum >= rightSum)
                ++count;
        }

        return count;
    }
}