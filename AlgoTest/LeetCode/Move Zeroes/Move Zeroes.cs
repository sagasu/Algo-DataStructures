namespace AlgoTest.LeetCode.Move_Zeroes;

public class Move_Zeroes
{
    public void MoveZeroes(int[] nums) {
        var count = 0;
        for(var i = nums.Length-1;i>=0;i--){
            if(nums[i]==0)
            {
                for(var j = i;j<nums.Length-1-count;j++)
                {
                    nums[j] = nums[j+1];
                    nums[j+1] = 0;
                }  
                count ++;
            }
        }
    }
}