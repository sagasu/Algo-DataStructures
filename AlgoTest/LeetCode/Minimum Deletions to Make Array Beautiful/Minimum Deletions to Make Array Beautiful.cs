namespace AlgoTest.LeetCode.Minimum_Deletions_to_Make_Array_Beautiful;

public class Minimum_Deletions_to_Make_Array_Beautiful
{
    public int MinDeletion(int[] nums) {
        var count = 0;
        var i = 0;

        while(i<nums.Length-1){
            if(nums[i] == nums[i+1]){
                i++;
                count++;
            }
            else i = i+2;
            
        }

        return (nums.Length-count)%2 == 0 ? count : count+1;
    }
}