using System;

namespace AlgoTest.LeetCode.Find_Polygon_With_the_Largest_Perimeter;

public class Find_Polygon_With_the_Largest_Perimeter
{
    public long LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        long previousElementsSum = 0;
        long ans = -1;
        
        foreach (var num in nums) {
            if (num < previousElementsSum)
                ans = num + previousElementsSum;
            
            previousElementsSum += num;
        }
        
        return ans;
    }
}