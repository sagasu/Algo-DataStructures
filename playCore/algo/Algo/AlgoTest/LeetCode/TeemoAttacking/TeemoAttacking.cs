using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.TeemoAttacking
{
    [TestClass]
    public class TeemoAttacking
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, FindPoisonedDuration(new int[]{1,2},2 ));
            Assert.AreEqual(4, FindPoisonedDuration(new int[]{1,4},2 ));
        }


        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries.Length == 0)
                return 0;

            var timeline = new int[timeSeries[timeSeries.Length - 1] + duration + 1];
            foreach (var series in timeSeries)
            {
                Array.Fill(timeline, 1, series, duration);
            }

            return timeline.Sum(x => x);

        }
    }
}
