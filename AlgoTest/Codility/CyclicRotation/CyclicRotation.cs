using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Codility.CyclicRotation
{
    [TestClass]
    public class CyclicRotation
    {

        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 2};
            var k = 3;
            solution(t,k);
        }

        public int[] solution(int[] A, int K)
        {
            if (A == null || A.Length <= 1)
                return A;

            var shifted = new int[A.Length];
            for (var i = 0; i < A.Length; i++)
            {
                var newPosition = (i + K) % (A.Length);
                shifted[newPosition] = A[i];
            }

            return shifted;
        }
    }
}
