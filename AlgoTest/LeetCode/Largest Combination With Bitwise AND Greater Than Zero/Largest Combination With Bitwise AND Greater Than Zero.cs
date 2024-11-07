using System.Linq;

namespace AlgoTest.LeetCode.Largest_Combination_With_Bitwise_AND_Greater_Than_Zero;

public class Largest_Combination_With_Bitwise_AND_Greater_Than_Zero
{
    public int LargestCombination(int[] candidates) => Enumerable.Range(0, 24)
        .Max(b => candidates.Sum(c => c >> b & 1));
}