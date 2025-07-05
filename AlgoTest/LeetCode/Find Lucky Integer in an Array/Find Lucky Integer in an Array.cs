using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Lucky_Integer_in_an_Array;

public class Find_Lucky_Integer_in_an_Array
{
    public int FindLucky(int[] arr) {
        var freq= new Dictionary<int,int>();
        foreach (var t in arr)
        {
            if(freq.ContainsKey(t))
                freq[t]+=1;
            else
                freq[t]=1;
        }

        return (from item in freq where item.Key == item.Value select item.Key).Prepend(-1).Max();
    }
}