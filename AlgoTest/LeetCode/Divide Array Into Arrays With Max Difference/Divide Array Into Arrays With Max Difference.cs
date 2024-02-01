using System;

namespace AlgoTest.LeetCode.Divide_Array_Into_Arrays_With_Max_Difference;

public class Divide_Array_Into_Arrays_With_Max_Difference
{
    public int[][] DivideArray(int[] nums, int k) {
        Array.Sort(nums);

        var res = new int[nums.Length/3][];

        for(var i=0; i<nums.Length/3; i++) {
            var temp = new int[3];
            temp[0] = nums[i*3];
            temp[1] = nums[i*3+1];
            temp[2] = nums[i*3+2];
            
            if(temp[2] - temp[1] <= k
               && temp[1] - temp[0] <= k
               && temp[2] - temp[0] <= k)
                res[i] = temp;
            else 
                return Array.Empty<int[]>(); 
        }

        return res;
    }
}