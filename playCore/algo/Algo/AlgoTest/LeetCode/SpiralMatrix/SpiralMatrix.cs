using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SpiralMatrix
{
    [TestClass]
    public class SpiralMatrix
    {
        [TestMethod]
        public void TesT()
        {
            //var t = new int[][]
            //{
            //    new int[]{ 1, 2, 3 },
            //    new int[]{ 4, 5, 6 },
            //    new int[]{ 7, 8, 9 }
            //};
            var t = new int[][]{ new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 } };
            var res = SpiralOrder(t);
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 1)
                return matrix[0];
            if (matrix.Length == 0)
                return new List<int>();

            var ret = new List<int>();
            var up = 0;
            var right= matrix[0].Length-1;
            var down = matrix.Length-1;
            var left = 0;
            var size = matrix.Length * matrix[0].Length;
            while (ret.Count < size) {
                for (var i = left; i <= right && ret.Count < size; i++) {
                    ret.Add(matrix[up][i]);
                }
                up+=1;
                for (var i = up; i <= down && ret.Count < size; i++)
                {
                    ret.Add(matrix[i][right]);
                }
                right -= 1;
                for (var i = right; i >= left && ret.Count < size; i--)
                {
                    ret.Add(matrix[down][i]);
                }
                down -= 1;
                for (var i = down; i >= up && ret.Count < size; i--)
                {
                    ret.Add(matrix[i][left]);
                }
                left += 1;
            }

            return ret;
        }
    }
}
