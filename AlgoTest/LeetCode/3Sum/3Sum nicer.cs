using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._3Sum
{
    [TestClass]
    public class _3Sum_nicer
    {
        [TestMethod]
        public void Test()
        {
            //var nums = new int[] {-1, 0, 1, 2, -1, -4};
            //var response1 = new int[] {-1, 0, 1};
            //var response2 = new int[] {-1, -1, 2};

            var nums = new[] {0, 0, 0, 0};
            var resp = ThreeSum(nums);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            var lastAdded = (int.MaxValue, int.MaxValue);
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var pointerA = i + 1;
                var pointerB = nums.Length - 1;
                var searchedSum = nums[i] * -1;

                while (pointerA < pointerB)
                {
                    var sum = nums[pointerA] + nums[pointerB];
                    if (sum == searchedSum)
                    {
                        if (!(lastAdded.Item1 == nums[pointerA] && lastAdded.Item2 == nums[pointerB]))
                        {
                            lastAdded = (nums[pointerA], nums[pointerB]);
                            result.Add(new List<int> { nums[i], nums[pointerA], nums[pointerB] });
                        }
                    }

                    if (sum < searchedSum) pointerA += 1;
                    else pointerB -= 1;
                    
                }
            }

            return result;

        }
    }
}
