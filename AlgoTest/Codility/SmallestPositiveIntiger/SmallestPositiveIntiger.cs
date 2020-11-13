using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Codility.SmallestPositiveIntiger
{
    [TestClass]
    public class SmallestPositiveIntiger
    {
        [TestMethod]
        public void Test()
        {
            var t= new int[] {1, 2,3};
            Assert.AreEqual(4, solution(t));

            t = new int[] {2};
            Assert.AreEqual(1, solution(t));

            t = new int[] { 2,4,5 };
            Assert.AreEqual(1, solution(t));


            t = new int[] { -2, -4, -5 };
            Assert.AreEqual(1, solution(t));

            t = new int[] { -2, -4, 5 };
            Assert.AreEqual(1, solution(t));
        }

        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 1;

            Array.Sort(A);

            var min = 1;
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    if (A[i] == min)
                        min += 1;
                }
            }

            return min;
        }
    }
}
