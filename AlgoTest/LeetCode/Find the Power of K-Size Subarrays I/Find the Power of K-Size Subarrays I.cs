using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_the_Power_of_K_Size_Subarrays_I;

public class Find_the_Power_of_K_Size_Subarrays_I
{
    public int[] ResultsArray(int[] nums, int k) {
        var n = nums.Length;
        var res = new List<int>();
        int l=0,count=1;
        for(int r=0;r<n;r++){
            if(r-1 >=0 && nums[r-1] +1 == nums[r])
                count++;
            if(r-l+1>k){
                if(nums[l]+1 == nums[l+1])
                    count--;
                l++;
            }
            if(r-l+1==k){
                if(count==k)
                    res.Add(nums[r]);
                else
                    res.Add(-1);
            }
        }
        return res.ToArray();
    }
}