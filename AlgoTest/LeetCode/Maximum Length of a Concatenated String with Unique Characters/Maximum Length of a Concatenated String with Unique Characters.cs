using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Length_of_a_Concatenated_String_with_Unique_Characters;

public class Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
{
    public int MaxLength(IList<string> arr) => MaxUnique(arr, 0, "");
    
    private int MaxUnique(IList<string> arr, int index, string curr)
    {
        if(index == arr.Count)
            return IsUnique(curr);
        
        if(IsUnique(curr)==-1)
            return -1;
        
        var res = MaxUnique(arr, index+1, curr);        
        var res2 = MaxUnique(arr, index+1, curr+arr[index]);
        return Math.Max(res, res2);
        
    }
    
     
    private int IsUnique(string str)
    {
        var set = new HashSet<char>();
        foreach(var c in str)
        {
            if(set.Contains(c))
                return -1;
            
            set.Add(c);
        }
        
        return str.Length;
    }
}