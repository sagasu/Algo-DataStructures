using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Diameter_of_Binary_Tree
{
    [TestClass]
    public class Daily_Temperatures
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {73, 74, 75, 71, 69, 72, 76, 73};
            CollectionAssert.AreEqual(new int[]{ 1, 1, 4, 2, 1, 1, 0, 0 }, DailyTemperatures(t));
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            var ret = new int[temperatures.Length];
            for (var i = 0; i < temperatures.Length; i++)
            {
                for (var j = i + 1; j < temperatures.Length; j++)
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        ret[i] = j - i;
                        break;
                    }
                }
            }

            return ret;
        }
    }
}
