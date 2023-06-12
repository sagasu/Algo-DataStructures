using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Summary_Ranges
{
    [TestClass]
    public class Summary_Ranges
    {
        [TestMethod]
        public void Test() => Assert.IsTrue(SummaryRanges(new[] { 1 }) is ["1"]);
        
        [TestMethod]
        public void Test4() => Assert.IsTrue(SummaryRanges(Array.Empty<int>() ) is []);

        [TestMethod]
        public void Test1() => Assert.IsTrue(SummaryRanges(new[] { 0, 1, 2, 4, 5, 7 }) is ["0->2", "4->5", "7"]);
        
        [TestMethod]
        public void Test2() => Assert.IsTrue(SummaryRanges(new[] { 0, 1, 2, 4, 5, 6, 7 }) is ["0->2", "4->7"]);
        
        [TestMethod]
        public void Test3() => Assert.IsTrue(SummaryRanges(new[] { -2, 0, 1, 2, 4, 5, 6, 7, 9, 11 }) is ["-2", "0->2", "4->7", "9", "11"]);

        public IList<string> SummaryRanges(int[] nums)
        {
            if(nums == null || nums.Length == 0) return new List<string>();

            var ranges = new List<string>();
            var low = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    if(i == nums.Length-1) ranges.Add($"{low}->{nums[i]}");
                    continue;
                }
                ranges.Add(low == nums[i-1] ? $"{low}" : $"{low}->{nums[i-1]}");
                low = nums[i];
            }
            if (low == nums[^1]) ranges.Add($"{low}");
            return ranges;
        }
    }
}
