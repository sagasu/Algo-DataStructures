using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Number_of_Removals_to_Make_Mountain_Array;

public class Minimum_Number_of_Removals_to_Make_Mountain_Array
{
    public int MinimumMountainRemovals(int[] nums) => nums.Length - MaxBitonicSubseq(nums);
    
    public int MaxBitonicSubseq(int[] a){
        var dpLeft = new int[a.Length];
        var dpRight = new int[a.Length];
        for(var i=0;i<a.Length;i++){
            var max = 0;
            for(var j=0;j<i;j++)
                if(a[j]<a[i] && dpLeft[j]>max)
                    max = dpLeft[j];
            
            dpLeft[i]= max + 1;
        }
        for(var i=a.Length-1;i>=0;i--){
            var max = 0;
            for(var j=a.Length-1;j>i;j--)
                if(a[j]<a[i] && dpRight[j]>max)
                    max = dpRight[j];
            
            dpRight[i]= max + 1;
        }
        var maxseq = 0;
        for(var i=1;i<a.Length-1;i++){
            var seqLen = dpLeft[i] + dpRight[i] - 1;
            if(seqLen > maxseq && dpLeft[i]>1 && dpRight[i]>1)
                maxseq = seqLen;
            
        }
        return maxseq;
    }
}