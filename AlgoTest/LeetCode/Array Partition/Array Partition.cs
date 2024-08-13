using System.Linq;

namespace AlgoTest.LeetCode.Array_Partition;

public class Array_Partition
{
    public int ArrayPairSum(int[] nums)
    {
        var result = 0;
        var sortednums = nums.OrderBy(x => x).ToArray();
        for(var i = 0; i < sortednums.Length; i += 2)
            result += sortednums[i];
        
        return result;
    }
}