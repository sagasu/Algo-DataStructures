using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._132Pattern
{
    [TestClass]
    public class _132PatternSimple
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual(false, Find132pattern(t));

            t = new[] { 3,1,4,2};
            Assert.AreEqual(true, Find132pattern(t));

            t = new[] {-1, 3, 2, 0};
            Assert.IsTrue(Find132pattern(t));
        }

        public bool Find132pattern(int[] nums)
        {
            return nums.Select((s, i) => new { s, i }).Select(
                x => nums.Select((s, i) => new { s, i }).Select(
                    y => nums.Select((s, i) => new { s, i }).Count(z => x.i < y.i && y.i < z.i && x.s < z.s && z.s < y.s)
                ).Sum()
            ).Sum() > 0;
        }
    }
}
