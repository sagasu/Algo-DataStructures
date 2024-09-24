using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_the_Length_of_the_Longest_Common_Prefix;

public class Find_the_Length_of_the_Longest_Common_Prefix
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        var st = new HashSet<int>();
        
        foreach (int val in arr1) {
            var currentVal = val;
            while (currentVal > 0) {
                if (!st.Contains(currentVal)) {
                    st.Add(currentVal);
                }
                currentVal /= 10;
            }
        }

        var result = 0;
        foreach (var num in arr2) {
            var currentNum = num;
            while (!st.Contains(currentNum) && currentNum > 0) {
                currentNum /= 10;
            }
            if (currentNum > 0) {
                result = Math.Max(result, (int)Math.Log10(currentNum) + 1);
            }
        }

        return result;
    }
}