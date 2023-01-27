using System;
using System.Collections.Generic;

public class WordPatternSolution
{
    public bool WordPattern(string pattern, string s) {
        
        string[] arr = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if(pattern.Length != arr.Length)
            return false;
        Dictionary<char,string> dic = new Dictionary<char,string>();
        for(var i = 0; i < pattern.Length; i++)
        {
            if(dic.ContainsKey(pattern[i]))
            {
                if(dic[pattern[i]] != arr[i])
                    return false;
            }
            else
            {
                if(dic.ContainsValue(arr[i]))
                    return false;
                else
                    dic.Add(pattern[i],arr[i]);
            }
        }
        return true;
    }
}