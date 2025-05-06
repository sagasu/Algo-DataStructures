namespace AlgoTest.LeetCode.Build_Array_from_Permutation;

public class Build_Array_from_Permutation
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (x < 0) continue;
            int curr = i;
            while (nums[curr] != i)
            {
                int next = nums[curr];
                nums[curr] = ~nums[next];
                curr = next;
            }
            nums[curr] = ~x;
        }

        for (int i = 0; i < n; i++)
        {
            nums[i] = ~nums[i];
        }
        return nums;
    }
}