using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AlgoTest.LeetCode.UniquePaths
{
    [TestClass]
    public class UniquePathsProblem
    {
        [TestMethod]
        public void Test() {
            //Assert.AreEqual(3, UniquePaths(3, 2));
            Assert.AreEqual(3, UniquePaths(23, 12));
        }

        public int UniquePaths(int m, int n)
        {
            CalculatePath(m, n, 1, 1);
            return ways;
        }

        int ways;
        void CalculatePath(int m, int n, int row, int column) {
            if (column == m && row == n) {
                ways += 1;
                return;
            }

            if (column < m) {
                CalculatePath(m, n, row, column + 1);
            }

            if (row < n)
            {
                CalculatePath(m, n, row+1, column);
            }
        }
    }
}
