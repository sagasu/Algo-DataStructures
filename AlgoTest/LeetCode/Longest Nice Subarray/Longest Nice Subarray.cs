using System;
using System.Linq;

namespace AlgoTest.LeetCode.Longest_Nice_Subarray;

public class Longest_Nice_Subarray
{
    public int LongestNiceSubarray(int[] nums)
    {
        var res = 1;
        var arr = new int[32];
        var left = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            var curr = getBitArrayOfInt(nums[i]);
            for(int j = 0; j <=30; j++)
                arr[j] += curr[j];
            while (arr.Max()>1 && left < i)
            {
                var prev = getBitArrayOfInt(nums[left++]);
                for (int j = 0; j <= 30; j++)
                    arr[j] -= prev[j];
            }
            res = Math.Max(res, i - left + 1);
        }
        return res;
    }

    private int[] getBitArrayOfInt(int x)
    {
        var res = new int[32];
        for(int i = 0; i <= 30; i++)
            if((x & (1 << i)) != 0)
                res[i] = 1;
        
        return res;
    }
}