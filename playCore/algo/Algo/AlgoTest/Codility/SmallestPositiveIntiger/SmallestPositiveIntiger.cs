using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SwapNodesInPairs
{
    [TestClass]
    public class SmallestPositiveIntiger
    {
        [TestMethod]
        public void Test()
        {
            //var t= new int[] {1, 3, 6, 4, 1, 2};
            var t= new int[] {1, 2,3};
            Assert.AreEqual(4, solution(t));
        }

        public int solution(int[] A)
        {
            Array.Sort(A);


            var min = A[A.Length - 1] > 0 ? A[A.Length - 1] + 1 : 1;
            for (var i = 0; i < A.Length-1; i++)
            {
                if (A[i] >= 0)
                {
                    if (A[i] + 1 < A[i+1])
                    {
                        min = A[i] + 1;
                        return min;
                    } 

                }
            }

            return min;
        }

        //public ListNode SwapPairs(ListNode head)
        //{

        //}
    }
}
