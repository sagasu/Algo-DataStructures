using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Limit_of_Balls_in_a_Bag;

public class Minimum_Limit_of_Balls_in_a_Bag
{
    public int MinimumSize(int[] nums, int maxOperations) {
        int l = 1, r = 1000000000;
        while (l < r) {
            int m = l + (r - l) / 2, numOps = 0;
            numOps += nums.Sum(num => (num - 1) / m);
            if (numOps > maxOperations)
                l = m + 1;
            else 
                r = m;
        }
        
        return l;
    }
}