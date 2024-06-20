using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Most_Profit_Assigning_Work;

public class Most_Profit_Assigning_Work
{
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < difficulty.Length; i++)
        {
            if (dict.ContainsKey(difficulty[i]))
                dict[difficulty[i]] = Math.Max(profit[i], dict[difficulty[i]]);
            else dict[difficulty[i]] = profit[i];
        }
        
        dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        var res = 0;
        
        foreach(var work in worker)
            foreach (var item in dict.Where(item => work >= item.Key))
            {
                res += item.Value;
                break;
            }
        
        return res;
    }
}