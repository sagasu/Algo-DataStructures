using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.MinimumDominoRotationsForEqualRow
{
    [TestClass]
    public class MinimumDominoRotationsForEqualRow
    {
        [TestMethod]
        public void Test() {
            //var t1 = new int[] { 2, 1, 2, 4, 2, 2 };
            //var t2 = new int[] { 5, 2, 6, 2, 3, 2 };
            //Assert.AreEqual(2, MinDominoRotations(t1, t2));

            //var t3 = new int[] { 3, 5, 1, 2, 3 };
            //var t4 = new int[] { 3, 6, 3, 3, 4 };
            //Assert.AreEqual(-1, MinDominoRotations(t3, t4));

            var t5 = new int[] { 1, 2, 1, 1, 1, 2, 2, 2 };
            var t6 = new int[] { 2, 1, 2, 2, 2, 2, 2, 2 };
            Assert.AreEqual(1, MinDominoRotations(t5, t6));
        }
        [TestMethod]
        public void Test2() {
            var t1 = new int[] { 2, 1, 2, 4, 2, 2 };
            var t2 = new int[] { 5, 2, 6, 2, 3, 2 };
            Assert.AreEqual(2, MinDominoRotations(t1, t2));

        }
        [TestMethod]
        public void Test3() {

            var t3 = new int[] { 3, 5, 1, 2, 3 };
            var t4 = new int[] { 3, 6, 3, 3, 4 };
            Assert.AreEqual(-1, MinDominoRotations(t3, t4));

        }

        public int MinDominoRotations(int[] A, int[] B)
        {
            var minSwapAtoA = 0;
            var minSwapBtoB = 0;
            var minSwapAtoB = 1;
            var minSwapBtoA = 1;

            var a = A[0];
            var b = B[0];

            for (var i = 1; i < A.Length; i++) {

                if (B[i] == a)
                {
                    if (A[i] != a)
                    {
                        minSwapAtoA += 1;
                    }
                }

                if (A[i] == b) {
                    if (B[i] != b) {
                        minSwapBtoB += 1;
                    }
                }

                if (A[i] != b && B[i] != b) {
                    minSwapBtoB = int.MinValue;
                }
                if (A[i] != a && B[i] != a)
                {
                    minSwapAtoA = int.MinValue;
                }
            }

            if (minSwapAtoA < 0 && minSwapBtoB < 0)
                return -1;

            return minSwapAtoA < 0 ? minSwapBtoB : minSwapBtoB < 0 ? minSwapAtoA : Math.Min(minSwapAtoA, minSwapBtoB);

        }
    }
}
