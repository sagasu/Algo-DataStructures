using System.Collections.Generic;

namespace AlgoTest.LeetCode.Binary_Prefix_Divisible_By_5;

public class Binary_Prefix_Divisible_By_5
{
    public IList<bool> PrefixesDivBy5(int[] nums) {
        List<bool> res = new List<bool>();
        int mod = 0;

        foreach (int bit in nums) {
            mod = (mod * 2 + bit) % 5;
            res.Add(mod == 0);
        }

        return res;
    }
}