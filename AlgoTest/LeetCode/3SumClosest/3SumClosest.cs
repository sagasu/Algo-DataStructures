using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._3SumClosest
{
    [TestClass]
    public class _3SumClosest
    {
        [TestMethod]
        public void Test()
        {
            //var nums = new int[] { -1, 2, 1, -4 };
            //Assert.AreEqual(2, ThreeSumClosest(nums, 1));

            var nums = new int[] { 1, 1, 1, 0 };
            Assert.AreEqual(2, ThreeSumClosest(nums, -100));
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var bestResult = nums[0] + nums[1] + nums[nums.Length - 1];

            for (var i = 0; i < nums.Length - 2; i++)
            {
                var pointerA = i + 1;
                var pointerB = nums.Length - 1;
                

                while (pointerA < pointerB)
                {
                    var currentSum = nums[i] + nums[pointerA] + nums[pointerB];
                    if (currentSum > target)
                    {
                        pointerB -= 1;
                    }
                    else
                    {
                        pointerA += 1;
                        
                    }

                    if (Math.Abs(currentSum - target) < Math.Abs(bestResult-target))
                        bestResult = currentSum;
                }
            }

            return bestResult;
        }
    }
}
