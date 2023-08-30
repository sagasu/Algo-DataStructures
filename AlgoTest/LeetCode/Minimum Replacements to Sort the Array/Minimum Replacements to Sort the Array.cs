namespace AlgoTest.LeetCode.Minimum_Replacements_to_Sort_the_Array;

public class Minimum_Replacements_to_Sort_the_Array
{
    public long MinimumReplacement(int[] nums) {
        long result = 0;
        
        for (var i = nums.Length - 2; i >= 0; ) 
            if (nums[i] <= nums[i + 1]) 
                i -= 1;
            else {
                var breakCount = ((nums[i] - 1) / nums[i + 1]) + 1;
            
                nums[i] /= breakCount;
            
                result += breakCount - 1;
            }
           
        return result;
    }
}