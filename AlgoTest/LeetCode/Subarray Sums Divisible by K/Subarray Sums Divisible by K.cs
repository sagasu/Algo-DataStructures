using System.Linq;

public class SubarraysDivByKSolution
{
    public int SubarraysDivByK(int[] nums, int K) {
        int[] sum = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
            sum[i + 1] = sum[i] + nums[i];
        return sum.GroupBy(p => (p % K + K) % K) 
                .Sum(p => p.Count() * (p.Count() - 1) / 2);
    }
}