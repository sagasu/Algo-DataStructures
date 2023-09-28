using System.Linq;

namespace AlgoTest.LeetCode.Sort_Even_and_Odd_Indices_Independently;

public class Sort_Even_and_Odd_Indices_Independently
{
    public int[] SortEvenOdd(int[] nums) {
        
        var evens = nums.Where( (x, i) => 0 == (i & 1)).OrderBy(x => x);
        var odds = nums.Where( (x, i) => 1 == (i & 1)).OrderByDescending(x => x);
                
        var index = 0;
        foreach(var num in evens){
            nums[index] = num;
            index += 2;
        }
        
        index = 1;
        foreach(var num in odds){
            nums[index] = num;
            index += 2;
        }
        
        return nums;
    }
}