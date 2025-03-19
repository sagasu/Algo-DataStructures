namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Binary_Array_Elements_Equal_to_One_I;

public class Minimum_Operations_to_Make_Binary_Array_Elements_Equal_to_One_I
{
    public int minOperations(int[] nums) {
        var n = nums.Length;
        var operations = 0;
        for(var i = 0 ; i < n-2 ; i++) {
            if(nums[i] == 0) {
                nums[i] = 1;
                nums[i+1] = 1 - nums[i+1];
                nums[i+2] = 1 - nums[i+2];
                operations++;
            }
        }
        return nums[n-1] == 1 && nums[n-2] == 1 ? operations : -1;
    }
}