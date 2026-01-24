using System;

namespace AlgoTest.LeetCode.Minimize_Maximum_Pair_Sum_in_Array;

public class Minimize_Maximum_Pair_Sum_in_Array
{
    public int MinPairSum(int[] nums) {
        Array.Sort(nums);
        int maxPairSum=0;
        int i=0,j=nums.Length-1;

        while(i<j){
            int currentSum= nums[i]+nums[j];
        
            if(currentSum>maxPairSum) maxPairSum=currentSum;

            i++;
            j--;
        }
        return maxPairSum;
    }
}