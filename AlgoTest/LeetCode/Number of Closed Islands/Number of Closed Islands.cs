using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Number_of_Closed_Islands
{
    [TestClass]
    public class Number_of_Closed_Islands
    {
        [TestMethod]
        public void FirstTest()
        {

            int[][] A =
            {
                new[] { 0, 0, 0, 0 },
                new[] { 1, 0, 1, 0 },
                new[] { 0, 1, 1, 0 },
                new[] { 0, 0, 0, 0 }
            };
            var expected = 3;
            Assert.AreEqual(expected, NumEnclaves(A));

        }

        [TestMethod]
        public void FailedTest()
        {

            int[][] A =
            {
                new[] { 0, 1, 1, 0 },
                new[] { 0, 0, 1, 0 },
                new[] { 0, 0, 1, 0 },
                new[] { 0, 0, 0, 0 }
            };
            var expected = 0;
            Assert.AreEqual(expected, NumEnclaves(A));

        }

        public int NumEnclaves(int[][] A)
        {
            var count = 0;

            for (var i = 0; i < A[0].Length; i++)
            {
                Dfs(A, 0, i); //first line
                Dfs(A, A.Length - 1, i); //last line
            }

            for (var i = 0; i < A.Length; i++)
            {
                Dfs(A, i, 0); //first col
                Dfs(A, i, A[0].Length - 1); //last col
            }

            for (var i = 0; i < A.Length; i++)
            for (var j = 0; j < A[i].Length; j++)
                if (A[i][j] == 1) count++;

            return count;
        }

        public void Dfs(int[][] arr, int i, int j)
        {
            if (i < 0 || i >= arr.Length || j < 0 || j >= arr[i].Length || arr[i][j] == 0) return;

            arr[i][j] = 0;

            Dfs(arr, i, j + 1);//find right
            Dfs(arr, i, j - 1);//find left
            Dfs(arr, i + 1, j);//find top
            Dfs(arr, i - 1, j);//find bottom
        }
    }
}
