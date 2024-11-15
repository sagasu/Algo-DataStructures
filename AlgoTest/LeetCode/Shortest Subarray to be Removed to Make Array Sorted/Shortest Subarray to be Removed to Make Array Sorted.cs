using System;

namespace AlgoTest.LeetCode.Shortest_Subarray_to_be_Removed_to_Make_Array_Sorted;

public class Shortest_Subarray_to_be_Removed_to_Make_Array_Sorted
{
    public int FindLengthOfShortestSubarray(int[] arr) {
        var n=arr.Length;
        var r=n-1;
        
        while(r>0&&arr[r-1]<=arr[r])
            r--;
        
        var ans=r;
        var l=0;
        
        while(l<r&&(l==0 || arr[l-1]<=arr[l]))
        {
            while(r<n&&arr[r]<arr[l]) r++;
            ans=Math.Min(ans,r-l-1);
            l++;
        }
        return ans;
    }
}