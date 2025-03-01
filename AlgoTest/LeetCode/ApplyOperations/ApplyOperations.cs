namespace AlgoTest.LeetCode.ApplyOperations;

public class ApplyOperationsSolution
{
    public int[] ApplyOperations(int[] nums) {
        uint zero = 0;
        for(int i = 0; i < nums.Length; i++){
            if(i < nums.Length-1 && nums[i] == nums[i+1] && nums[i] != 0){
                nums[i] *= 2;
                nums[i+1] = 0;
            }

            if(nums[i] != 0){
                (nums[i] , nums[zero]) = (nums[zero] , nums[i]);
                zero++;
            }
        }
        return nums;
    }
}