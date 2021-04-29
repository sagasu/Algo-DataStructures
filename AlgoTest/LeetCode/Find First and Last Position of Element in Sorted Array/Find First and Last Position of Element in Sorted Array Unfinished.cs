using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    [TestClass]
    public class Find_First_and_Last_Position_of_Element_in_Sorted_Array_Unfinished
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {5, 7, 7, 8, 8, 10};
            CollectionAssert.AreEqual(new int[]{3,4}, SearchRange(t, 8));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 5, 7, 7, 8, 8, 10 };
            CollectionAssert.AreEqual(new int[]{-1,-1}, SearchRange(t, 6));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] {};
            CollectionAssert.AreEqual(new int[]{-1,-1}, SearchRange(t, 0));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {2, 2};
            CollectionAssert.AreEqual(new int[]{ 0, 1}, SearchRange(t, 2));
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0) return new[] {-1, -1};

            int BST(int start, int end, bool isLeft)
            {
                if (isLeft && nums[start] == target && (start == 0 || nums[start - 1] != target)) return start;
                if (!isLeft && nums[start] == target && (start == nums.Length-1 || nums[start + 1] != target)) return start;

                var mid = start+ (end - start) / 2;
                if (mid == start || mid == end) return -1;
                bool IsLeft()
                {
                    return target < nums[mid];
                }

                
                if (IsLeft())
                    end = mid-1;
                else
                    start = mid;
                

                return BST(start, end, isLeft);
            }

            var left = BST(0, nums.Length-1, true);
            var right = BST(0, nums.Length-1, false);
            return new[] {left, right};
        }
    }
}
