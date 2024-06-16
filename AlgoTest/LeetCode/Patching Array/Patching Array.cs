namespace AlgoTest.LeetCode.Patching_Array;

public class Patching_Array
{
    public int MinPatches(int[] nums, int n) 
    {
        var miss = 1l;
        var result = 0;
        var i = 0;

        while(miss <= n)
        {
            if (i < nums.Length && nums[i] <= miss)
            {
                miss += nums[i];
                i++;
            }
            else
            {
                miss += miss;
                result++;
            }
        }

        return result;
    }
}