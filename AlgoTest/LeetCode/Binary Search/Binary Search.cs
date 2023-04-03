using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Binary_Search
{
    [TestClass]
    public class Binary_Search
    {
        [TestMethod]
        public void AssumeThatItExistsAndFindTheOnlyIndex()
        {
            // This finds the index of any occourance of the number
            Assert.AreEqual(4,Search(new int[]{1,2,3,4,5,6,7,8,9,10}, 5));
            Assert.AreEqual(1,Search(new int[]{1,2,3,4,5,6,7,8,9}, 2));
            Assert.AreEqual(2,Search(new int[]{1,2,3}, 3));
            Assert.AreEqual(0,Search(new int[]{1,2,3}, 1));
        }
        
        [TestMethod]
        public void AssumeThatItMayNotExist_FindWhereToPutIt()
        {
            // The number doesn't exist and whe are searching for a place to put it
            Assert.AreEqual(4,Search(new int[]{1,2,3,4,6,7,8,9,10}, 5));
            Assert.AreEqual(0,Search(new int[]{2,3,4,6,7,8,9}, 1));
            //Assert.AreEqual(8,Search(new int[]{1,2,3,4,6,7,8,9}, 10));// this fails, because the implementation doesn't include ability to add more than N positions, we need to change the implementation
            Assert.AreEqual(8, SearchBeAbleToFindAboveTheSize(new int[]{1,2,3,4,6,7,8,9}, 10));
        }

        [TestMethod]
        public void FindIfExistsAtAll()
        {
            // This finds the index of any occourance of the number
            Assert.AreEqual(4, Search_FindIfExistsAtAll(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5));
            Assert.AreEqual(-1, Search_FindIfExistsAtAll(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0));
            Assert.AreEqual(-1, Search_FindIfExistsAtAll(new int[] { 1, 2, 3 }, 4));
            Assert.AreEqual(0, Search_FindIfExistsAtAll(new int[] { 1, 2, 3 }, 1));
        }

        public int Search(int[] nums, int target)
        {
            Array.Sort(nums);
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid]  >= target) right = mid; //if is a success
                else left = mid + 1;
            }

            if (left != right) throw new Exception($"{left} {right}");//just a check
            return right;
        }
        
        public int Search_FindIfExistsAtAll(int[] nums, int target)
        {
            Array.Sort(nums);
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid]  >= target) right = mid; //if is a success
                else left = mid + 1;
            }

            if (left != right) throw new Exception($"{left} {right}");//just a check
            return nums[right] == target? right : -1;
        }
        
        public int SearchBeAbleToFindAboveTheSize(int[] nums, int target)
        {
            Array.Sort(nums);
            var left = 0;
            var right = nums.Length;

            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid]  >= target) right = mid; //if is a success
                else left = mid + 1;
            }

            if (left != right) throw new Exception($"{left} {right}"); // just a check
            return right;
        }
        
        public int SearchOrig(int[] nums, int target)
        {
            var i = 0;
            var j = nums.Length - 1;
            while (i <= j)
            {
                var mid = i + (j - i) / 2;
                if (nums[mid] < target) i = mid + 1;
                else if (nums[mid] > target) j = mid - 1;
                else return mid;
            }
            return -1;
        }
    }
}
