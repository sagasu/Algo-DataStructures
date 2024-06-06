using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Hand_of_Straights;

public class Hand_of_Straights
{
    public bool IsNStraightHand(int[] hand, int groupSize) {
        var dict = new Dictionary<int, int>();
        foreach(var num in hand){
            if(!dict.ContainsKey(num))
                dict.Add(num, 0);
            dict[num]++;
        }
        
        while(dict.Count >= groupSize){
            var min = dict.Keys.Min();
            for(var i = 0; i < groupSize; i++){
                if(dict.ContainsKey(min)){
                    dict[min]--;
                    if(dict[min] == 0)
                        dict.Remove(min);
                    min++;
                }
                else{
                    return false;
                }
            }
        }
        
        return dict.Count <= 0;
    }
}