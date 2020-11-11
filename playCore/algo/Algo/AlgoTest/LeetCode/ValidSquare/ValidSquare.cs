using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ValidSquare
{
    [TestClass]
    public class ValidSquareSolution
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(ValidSquare(new int[] {0, 0}, new int[] {0, 1}, new int[] { 1, 1 }, new int[] { 1, 0 }));
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var maxRow = Math.Max(Math.Max(p1[0], p2[0]), Math.Max(p3[0], p4[0]));
            var minRow = Math.Min(Math.Min(p1[0], p2[0]), Math.Min(p3[0], p4[0]));

            var maxCol = Math.Max(Math.Max(p1[0], p2[0]), Math.Max(p3[0], p4[0]));
            var minCol = Math.Min(Math.Min(p1[0], p2[0]), Math.Min(p3[0], p4[0]));

            var countMinCol = 0;
            var countMaxCol = 0;
            var countMinRow = 0;
            var countMaxRow = 0;

            bool Check(int[] node)
            {
                if (node[0] == minRow)
                {
                    countMinRow += 1;
                    return CheckCol(node);
                }
                
                if (node[0] == maxRow)
                {
                    countMaxRow += 1;
                    return CheckCol(node);
                }

                return false;
            }

            bool CheckCol(int[] node)
            {
                if (node[1] == minCol)
                {
                    countMinCol += 1;
                    return true;
                }

                if (node[1] == maxCol)
                {
                    countMaxCol += 1;
                    return true;
                }

                return false;
            }

            if (maxRow == minRow || maxCol == minCol) return false;

            if (!(Check(p1) && Check(p2) && Check(p3) && Check(p4)))
                return false;

            if (countMinCol == 2 && countMaxCol == 2 && countMinRow == 2 && countMaxRow == 2) return true;

            return false;
        }
    }
}
