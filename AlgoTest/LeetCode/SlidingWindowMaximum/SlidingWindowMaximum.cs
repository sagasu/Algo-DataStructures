using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SlidingWindowMaximum
{
    [TestClass]
    public class SlidingWindowMaximum
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 3, -1, -3, 5, 3, 6, 7};
            CollectionAssert.AreEqual(new int[] {3, 3, 5, 5, 6, 7}, MaxSlidingWindow(t, 3));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] {9,11};
            CollectionAssert.AreEqual(new int[] {11}, MaxSlidingWindow(t, 2));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] {9, 10, 9, -7, -4, -8, 2, -6};
            CollectionAssert.AreEqual(new int[] {10, 10, 9, 2}, MaxSlidingWindow(t, 5));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {1,-1};
            CollectionAssert.AreEqual(new int[] {1, -1}, MaxSlidingWindow(t, 1));
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var ret = new int[Math.Max(nums.Length-k+1, 1)];
            var max = int.MinValue;

            for (var i = 0; i < Math.Min(k, nums.Length); i++)
            {
                max = Math.Max(max, nums[i]);
            }

            var index = 0;
            ret[index] = max;
            for (var i = k; i < nums.Length; i++)
            {
                index += 1;
                if (nums[i] > max)
                {
                    max = nums[i];
                    ret[index] = max;
                    continue;
                }


                    if (max == nums[i - k])
                    {
                        var localMax = nums[i];
                        for (var j = i - k+1; j < Math.Min(i, nums.Length); j++)
                        {
                            localMax = Math.Max(localMax, nums[j]);
                        }

                        max = localMax;
                    }
                

                ret[index] = max;
            }

            return ret;
        }

    }
}
