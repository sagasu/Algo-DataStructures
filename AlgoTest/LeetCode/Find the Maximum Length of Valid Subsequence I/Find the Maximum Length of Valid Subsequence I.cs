using System;

namespace AlgoTest.LeetCode.Find_the_Maximum_Length_of_Valid_Subsequence_I;

public class Find_the_Maximum_Length_of_Valid_Subsequence_I
{
    public int MaximumLength(int[] nums) {
        int countOdd=0;
        int countEven=0;
        int countSub=0;
        int carry=0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i]%2==0)
                countEven++;
            else countOdd++;

            if(i==0){
                carry=nums[i]%2;
                countSub++;
            }
            else{
                if(Math.Abs(carry-1)==nums[i]%2){
                    countSub++;
                    carry=Math.Abs(carry-1);
                }
            }
        }
        return Math.Max(Math.Max(countEven,countOdd),countSub);
    }
}