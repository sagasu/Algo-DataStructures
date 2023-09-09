namespace AlgoTest.LeetCode.Combination_Sum_IV;

public class Combination_Sum_IVSolution
{
    public int CombinationSum4(int[] nums, int target) {
        var comb = new int[target + 1];
        comb[0] = 1;
        
        for(var i = 1; i <= target; i++)
            foreach (var num in nums)
                if(i - num >= 0)
                    comb[i] += comb[i - num];

        return comb[target];
    }
}