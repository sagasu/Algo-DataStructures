using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_the_Highest_Altitude
{
    [TestClass]
    public class Find_the_Highest_Altitude
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(1, LargestAltitude(new[] { -5, 1, 5, 0, -7 }));
        
        [TestMethod]
        public void Test1() => Assert.AreEqual(0, LargestAltitude(new[] { -4, -3, -2, -1, 4, 3, 2 }));

        public int LargestAltitude(int[] gain)
        {
            var max = 0;
            var curr = 0;
            foreach (var g in gain)
            {
                curr += g;
                max = Math.Max(curr, max);
            }
            return max;
        }
    }
}
