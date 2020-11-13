using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MinimumDominoRotationsForEqualRow
{
    public class MinimumDominoRotationsForEqualRowSolution
    {

        [TestMethod]
        public void Test()
        {
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
        //if values of one side must be all the same, either the value should be equal to A[0] or B[0]
        //check for both cases if A[i]==A[0] or B[i]==A[0]
        //                        A[i]==B[0] or B[i]==B[0]
        //use A_swap and B_swap to record the number of needed swaps from each side;
        //return the min if i reach n;
        //There is no need to check for B[0] if the i reaches n at A[0];

        public int MinDominoRotations(int[] A, int[] B)
        {
            var n = A.Length;
            var A_swap = 0;
            var B_swap = 0;
            //A[0]; if A[i] != A[0] A_swap++;
            //else if B[i] != A[0]  B_swap++;
            //if both case does not equal to A[0] then both A_swap and B_swap = -1;
            //Check value B[0];
            int i;
            for (i = 0; i < n && (A[i] == A[0] || B[i] == A[0]); i++)
            {
                if (A[i] != A[0])
                    A_swap++;
                if (B[i] != A[0])
                    B_swap++;
            }
            if (i == n)
            {
                return Math.Min(A_swap, B_swap);
            }
            //check for the B[0]
            A_swap = 0;
            B_swap = 0;

            for (i = 0; i < n && (A[i] == B[0] || B[i] == B[0]); i++)
            {
                if (A[i] != B[0])
                    A_swap++;
                if (B[i] != B[0])
                    B_swap++;
            }
            if (i == n)
            {
                return Math.Min(A_swap, B_swap);
            }

            return -1;

        }
    }
}
