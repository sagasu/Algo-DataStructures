namespace AlgoTest.LeetCode.Count_Partitions_with_Even_Sum_Difference;

public class Count_Partitions_with_Even_Sum_Difference
{
    public int CountPartitions(int[] nums)
    {
        int total = 0, length = nums.Length;

        for (int i = 0; i < length; i++)
            total += nums[i];

        return (total & 1) == 0 ? length - 1 : 0; 
    }
}