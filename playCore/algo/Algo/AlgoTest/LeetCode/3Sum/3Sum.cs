using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._3Sum
{
    [TestClass]
    public class _3Sum
    {
        [TestMethod]
        public void Test()
        {
            var nums = new int[] {-1, 0, 1, 2, -1, -4};
            var response1 = new int[] {-1, 0, 1};
            var response2 = new int[] {-1, -1, 2};
            var resp = ThreeSum(nums);
            Assert.AreEqual(response1, resp[0]);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();

            var result = new HashSet<ValueTuple<int, int, int>>();
            Array.Sort(nums);
            for (var i = 0; i < nums.Length-2; i++)
            {
                for (var j = i+1; j < nums.Length-1; j++)
                {
                    if (nums[i] + nums[j] > 0)
                        break;
                    for (var x = nums.Length - 1; x > j; x--)
                    {
                        var sum = nums[i] + nums[j] + nums[x];
                        if (j >= x || sum < 0)
                            break;

                        if (sum == 0)
                        {
                            if (result.Contains((nums[i], nums[j], nums[x])))
                                continue;
                            result.Add((nums[i], nums[j], nums[x]));
                        }
                    }
                }
            }

            return result.Select(valueTuple => new List<int> {valueTuple.Item1, valueTuple.Item2, valueTuple.Item3}).Cast<IList<int>>().ToList();
            
        }
    }
}
