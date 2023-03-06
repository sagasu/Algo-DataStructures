using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Kth_Missing_Positive_Number
{
    [TestClass]
    public class Kth_Missing_Positive_Number
    {
        [TestMethod]
        [DataRow(new[] { 2, 3, 4, 7, 11 }, 5, 9)]
        [DataRow(new[] { 1, 2, 3, 4 }, 2, 6)]
        [DataRow(new[] { 1 }, 2, 3)]
        public void Test(int[] data, int k, int expected)
        {
            Assert.AreEqual(expected, FindKthPositive(data, k));
        }

        public int FindKthPositive(int[] arr, int k)
        {
            var i = 0;
            var j = 1;
            while (i < arr.Length)
            {
                if (arr[i] != j)
                {
                    k -= 1;
                    if (k == 0) return j;
                }else i += 1;

                j += 1;

            }

            return j+k-1;
        }
    }
}
