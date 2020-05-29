using System;
using System.Collections.Generic;
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
            //var nums = new int[] {-1, 2, 1, -4};
            //Assert.AreEqual(2, ThreeSumClosest(nums, 1));

            var nums = new int[] { 1, 1, 1, 0 };
            Assert.AreEqual(2, ThreeSumClosest(nums, -100));
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            this.target = target;
            if (target < 0)
                isNegative = true;
            ThreeSumClosest(nums, new List<int>(), 0);
            return closestSolution;
        }

        private bool isNegative = false;
        private int target;
        private int closestSolution = Int32.MaxValue;

        public void ThreeSumClosest(int[] nums, IList<int> results, int index)
        {
            if (results.Count == 3)
            {
                var sum = results.Sum();
                var distance = isNegative ? target + sum : target - sum;
                if(Math.Abs(distance) < Math.Abs(closestSolution))
                    closestSolution = sum;
                return;
            }
            
            for (var i = index; i < nums.Length; i++)
            {
                if(index == 0)
                    results = new List<int>();

                results.Add(nums[i]);
                ThreeSumClosest(nums, results, index + 1);
            }
        }
    }
}
