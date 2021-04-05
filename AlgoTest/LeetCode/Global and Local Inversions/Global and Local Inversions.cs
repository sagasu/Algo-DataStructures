using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Global_and_Local_Inversions
{
    [TestClass]
    public class Global_and_Local_Inversions
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 0, 2};
            Assert.AreEqual(true, IsIdealPermutation(t));
        }

        public bool IsIdealPermutation(int[] A)
        {
            var n = A.Length;
            var mn = Math.Pow(10, 9);
            for (var i = n - 1; i > -1; i -= 1)
            {
                if (i + 2 < n) mn = Math.Min(mn, A[i + 2]);

                if (A[i] > mn) return false;
            }

            return true;
        }
    }
}
