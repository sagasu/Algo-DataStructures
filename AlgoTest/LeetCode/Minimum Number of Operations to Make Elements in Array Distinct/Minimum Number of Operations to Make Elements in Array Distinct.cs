using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct;

public class Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct
{
    public int MinimumOperations(int[] nums) {
        int operation = 0;
        HashSet<int> set = new ();
        for(int j = nums.Length - 1; j >= 0; j--)
        {
            if(!set.Contains(nums[j]))
                set.Add(nums[j]);
            else
                return (j + 3) / 3; 
        }
        
        return 0;
    }
}