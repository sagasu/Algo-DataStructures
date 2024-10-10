using System;

namespace AlgoTest.LeetCode.Maximum_Width_Ramp;

public class Maximum_Width_Ramp
{
    public int MaxWidthRamp(int[] nums) {
        var arr=new int[nums.Length][];
        for(var i=0;i<nums.Length;i++)
            arr[i]=new int[]{nums[i],i};
        
        Array.Sort(arr,(x,y)=> x[0]!=y[0] ? x[0].CompareTo(y[0]) : x[1].CompareTo(y[1]));
        int ret=0,max=0;
        for(var i=arr.Length-1;i>=0;i--)
        {
            max=Math.Max(max,arr[i][1]);
            ret=Math.Max(ret,max-arr[i][1]);
        }
        return ret;
    }
}