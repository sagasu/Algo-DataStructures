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

            var previousStart = 0;
            var posisonEnd = 0;
            var result = 0;

            foreach (var series in timeSeries)
            {
                if (series >= posisonEnd)
                {
                    result += duration;
                }
                else
                {
                    result += series - previousStart;
                }

                posisonEnd = series + duration;
                previousStart = series;
            }

            return result;
        }
    }
}
