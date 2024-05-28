using System;

namespace AlgoTest.LeetCode.Get_Equal_Substrings_Within_Budget;

public class Get_Equal_Substrings_Within_Budget
{
    public int EqualSubstring(string s, string t, int maxCost) 
    {
        var st=0;
        var end=0;
        var maxLength = 0;
        var cost = 0;
        
        while(end<s.Length)
        {
            var diff = Math.Abs(s[end]-t[end]);
            cost+=diff;
            
            while(cost>maxCost)
            {
                cost-=Math.Abs(s[st]-t[st]);
                st++;
            }
            
            maxLength = Math.Max(maxLength,end-st+1);
            end++;
        }
        
        return maxLength;
    }
}