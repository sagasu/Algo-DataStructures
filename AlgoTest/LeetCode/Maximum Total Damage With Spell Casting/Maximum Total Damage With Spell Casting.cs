using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Total_Damage_With_Spell_Casting;

public class Maximum_Total_Damage_With_Spell_Casting
{
    public long MaximumTotalDamage(int[] power) {
        var count = new Dictionary<int, int>();
        var processed = new HashSet<int>();

        foreach(var p in power){
            if(!count.ContainsKey(p)) count[p] = 0;
            count[p]++;
        }
        long res = 0;

        foreach((var key, var val) in count){
            int p = key;

            if(processed.Contains(p)) continue;

            if(!(
                   count.ContainsKey(p - 2) || count.ContainsKey(p - 1)
                                            || count.ContainsKey(p + 2) || count.ContainsKey(p + 1)
               )){
                processed.Add(p);
                res += (long)p * val;
                continue;
            }
            while(true){
                if(count.ContainsKey(p - 2)){
                    p -= 2;
                }else if(count.ContainsKey(p - 1)){
                    p -= 1;
                }else
                    break;
            }
            long val1=0,
                val2=0,
                val3=0;
            while(count.ContainsKey(p) || count.ContainsKey(p + 1)){
                long temp;
                if(!count.ContainsKey(p)){
                    temp = val3;
                }else{
                    temp = Math.Max(Math.Max(val2, val3), val1 + (long)count[p] * p);
                }
                val1 = val2; val2 = val3; val3 = temp;
                processed.Add(p);
                p++;
            }
            res += val3;
        }

        return res;
    }
}