using System.Linq;

namespace AlgoTest.LeetCode.Intersection_of_Two_Arrays;

public class Intersection_of_Two_Arrays
{
    public int[] Intersection(int[] nums1, int[] nums2) => nums1.Intersect(nums2).Distinct().ToArray();
}