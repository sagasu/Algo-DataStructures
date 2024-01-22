using System;

namespace AlgoTest.LeetCode.Find_Maximum_Number_of_String_Pairs;

public class Find_Maximum_Number_of_String_Pairs
{
    public int MaximumNumberOfStringPairs(string[] words) {
        var res = 0;
        
        for(var i = 0; i < words.Length; i++)
        {
            var w1 = words[i];
            for(var j = i + 1; j < words.Length; j++)
            {
                var helper = words[j].ToCharArray();
                Array.Reverse(helper);
                var w2 = new string(helper);
                if(w1 == w2)
                    res++;
            }
        }
        
        return res;
    }
}