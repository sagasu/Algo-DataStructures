using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SummaryRanges
{
    [TestClass]
    public class SummaryRangesSolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {0, 1, 2, 4, 5, 7};
            CollectionAssert.AreEqual(new string[]{ "0->2", "4->5", "7" }, SummaryRanges(t).ToArray());

            t = new int[] { 0, 2, 3, 4, 6, 8, 9 };
            CollectionAssert.AreEqual(new string[] { "0", "2->4", "6", "8->9" }, SummaryRanges(t).ToArray());

            t = new int[] { 0 };
            CollectionAssert.AreEqual(new string[] { "0" }, SummaryRanges(t).ToArray());

            t = new int[] { -1};
            CollectionAssert.AreEqual(new string[] { "-1" }, SummaryRanges(t).ToArray());

            t = new int[] { };
            CollectionAssert.AreEqual(new string[] { }, SummaryRanges(t).ToArray());
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            var ranges = new List<string>();
            if (nums == null || nums.Length < 1) return ranges;

            if (nums.Length == 1)
                return new List<string> {nums[0].ToString()};

            var previousIndex = 0;
            
            for (var index = 1; index < nums.Length; index++)
            {
                if (nums[index - 1] + 1 != nums[index])
                {
                    var range = index == previousIndex + 1
                        ? nums[index - 1].ToString()
                        : $"{nums[previousIndex]}->{nums[index - 1]}";

                    ranges.Add(range);
                    previousIndex = index;
                }
            }

            var lastRange = nums[nums.Length - 1] - 1 != nums[nums.Length - 2]
                ? nums[nums.Length - 1].ToString()
                : $"{nums[previousIndex]}->{nums[nums.Length - 1]}";
            ranges.Add(lastRange);
            return ranges;
        }
    }
}
