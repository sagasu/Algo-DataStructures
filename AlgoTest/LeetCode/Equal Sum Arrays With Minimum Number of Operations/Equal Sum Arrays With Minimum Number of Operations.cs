using System;
using System.Linq;

namespace AlgoTest.LeetCode.Equal_Sum_Arrays_With_Minimum_Number_of_Operations;

public class Equal_Sum_Arrays_With_Minimum_Number_of_Operations
{
    public int MinOperations(int[] nums1, int[] nums2) {
        
        var sum1= nums1.Sum();
        var sum2= nums2.Sum();
        
        var allNums = new int[nums1.Length + nums2.Length];
        
        if(sum1 < sum2)
            allNums = BalanceArray(nums1,nums2);
        else
            allNums =   BalanceArray(nums2, nums1);
        
        
        Array.Sort(allNums);
        Array.Reverse(allNums);
        
        var diff = Math.Abs(sum1-sum2);
        var ans=0;
        foreach (var t in allNums)
        {
            if(diff <= 0)
                break;
            
            diff -= t;
            ans+=1;
        }
        
        return diff <=0 ? ans : -1; 
        
    }
    
    private int[] BalanceArray(int[] nums1, int[] nums2)
    {
        var totalNums = new int[nums1.Length+ nums2.Length];
        
        for(var i=0; i< nums1.Length; i++)
            totalNums[i] = 6 - nums1[i];
        
        for(int i=0 ; i< nums2.Length; i++)
            totalNums[i+ nums1.Length] = nums2[i] -1;
        
        return totalNums;
    }
}