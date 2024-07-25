using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Total_Reward_Using_Operations_I;

public class Maximum_Total_Reward_Using_Operations_I
{
    public int MaxTotalReward(int[] rewardValues) {
        
        Array.Sort(rewardValues);
        rewardValues = rewardValues.Distinct().ToArray();
        var memo = new Dictionary<int,int>();
        var N = rewardValues.Length;
        return GetMax(0, 0);
        
        int GetMax(int index, int x)
        {
           
            if(index >= N)
                return x;
            
            var key = GetKey(index,x);
            if(memo.ContainsKey(key))
                return memo[key];
            
            var reward = rewardValues[index];
            var max1 = 0;
            var max2 = 0;
            if(reward > x)
                max1 = GetMax(index+1, x + reward);
            
            max2 = GetMax(index+1, x);
            var max = Math.Max(max1, max2);
            
            memo[key] = max;
            return max;
        }

        int GetKey(int index, int x) => x * 10000 + index;
    } 
}