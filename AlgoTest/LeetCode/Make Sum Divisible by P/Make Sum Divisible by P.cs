using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Make_Sum_Divisible_by_P;

public class Make_Sum_Divisible_by_P
{
    public int MinSubarray(int[] nums, int p) {
        var sum = nums.Aggregate(0, (current, t) => (current + t) % p);

        if(sum % p == 0)
            return 0;

        var remaindersIndex = new Dictionary<int, int> { [0] = -1 };

        var result = nums.Length;
        var currentSum = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            currentSum = (currentSum + nums[i]) % p;
            var required = (currentSum - sum + p) % p;

            if(remaindersIndex.ContainsKey(required))
            {
                var length = i - remaindersIndex[required];
                result = Math.Min(result, length);
            }

            remaindersIndex[currentSum] = i;
        }

        return result < nums.Length ? result : -1;
    }
}