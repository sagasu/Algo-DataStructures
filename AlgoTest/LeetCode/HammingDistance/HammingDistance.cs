using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.HammingDistance
{
    [TestClass]
    public class HammingDistanceProblem
    {
        [TestMethod]
        public void Test()
        {
            var t1 = 4;
            var t2 = 14;
            Assert.AreEqual(2, HammingDistance(4, 14));
        }

        public int HammingDistance(int x, int y)
        {
            var sx = Convert.ToString(x, 2);
            var sy = Convert.ToString(y, 2);

            if (sx.Length < sy.Length)
            {
                sx = GetNormalized(sy, sx);
            }else if (sy.Length < sx.Length)
            {
                sy = GetNormalized(sx, sy);
            }
                

            var count = 0;
            for (var i = sx.Length- 1; i >= 0; i--)
            {
                if (sx[i] != sy[i])
                {
                    count += 1;
                }
            }

            return count;
        }

        private static string GetNormalized(string sy, string sx)
        {
            var diff = sy.Length - sx.Length;
            sx = string.Join("", Enumerable.Repeat(0, diff)) + sx;
            return sx;
        }
    }
}
