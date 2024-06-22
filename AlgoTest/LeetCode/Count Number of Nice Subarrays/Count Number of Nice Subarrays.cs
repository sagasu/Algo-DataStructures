namespace AlgoTest.LeetCode.Count_Number_of_Nice_Subarrays;

public class Count_Number_of_Nice_Subarrays
{
    public int NumberOfSubarrays(int[] nums, int k) => Solve(nums.Length, k, nums) - Solve(nums.Length, k - 1, nums);
 
    private int Solve(int n, int k, int[] nums)
    {
        int l=0,r=0,res=0;

        while (r < n)
        {
            if (nums[r] % 2 != 0)
                k--;

            while (k < 0)
            {
                if (nums[l] % 2 != 0)
                    k++;
                
                l++;
            }
            
            res += (r - l + 1);
            r++;
        }

        return res;
    }
}