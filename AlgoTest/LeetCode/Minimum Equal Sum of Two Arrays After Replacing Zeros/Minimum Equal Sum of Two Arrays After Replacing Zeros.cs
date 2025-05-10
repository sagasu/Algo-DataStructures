using System;

namespace AlgoTest.LeetCode.Minimum_Equal_Sum_of_Two_Arrays_After_Replacing_Zeros;

public class Minimum_Equal_Sum_of_Two_Arrays_After_Replacing_Zeros
{
    public long MinSum(int[] nums1, int[] nums2) {
        long sum1 = 0, z1 = 0;
        long sum2 = 0, z2 = 0;

        foreach(int x in nums1){
            sum1+= x;
            if(x==0)
                z1 ++;
        }

        foreach(int x in nums2){
            sum2+= x;
            if(x==0)
                z2 ++;
        }

        long ans1 = sum1+z1, ans2 = sum2+z2;
        long ans = ans1 > ans2 ? ans1 : ans2;

        if(ans1== ans2)
            return ans;

        if(ans1 == ans && z2 > 0)
            return ans;

        if(ans2 == ans && z1 > 0)
            return ans;

        return -1;
    }
}