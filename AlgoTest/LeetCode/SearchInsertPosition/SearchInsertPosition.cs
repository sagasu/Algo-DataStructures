using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SearchInsertPosition
{
    [TestClass]
    public class SearchInsertPosition
    {
        [TestMethod]
        public void Test() {
            var t = new int[] { 1, 3, 5, 6 };
            Assert.AreEqual(2, SearchInsert(t, 5));

            //var t = new int[]{ 1, 3, 5, 6 };
            //Assert.AreEqual(1, SearchInsert(t, 2));
        }
        public int SearchInsert(int[] nums, int target)
        {
            if (nums[nums.Length - 1] < target)
                return nums.Length;
            var low = 0;
            var hight = nums.Length - 1;
            while (low < hight) {
                var mid = (hight + low) / 2;

                if (target > nums[mid])
                {
                    low = mid + 1;
                }
                else {
                    hight = mid;
                }
            }
            return low;
        }
    }
}
