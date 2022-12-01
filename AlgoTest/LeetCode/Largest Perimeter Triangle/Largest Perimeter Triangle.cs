using System;

public class LargestPerimeterTriangle {
    public int LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        for (var q=nums.Length-1; q>1; q--) {
            if (nums[q] < nums[q-1] + nums[q-2]) return nums[q] + nums[q-1] + nums[q-2];
        }
        return 0;
    }
}