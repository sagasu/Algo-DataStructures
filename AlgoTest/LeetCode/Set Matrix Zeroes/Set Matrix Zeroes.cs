using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Set_Matrix_Zeroes
{
    [TestClass]
    public class Set_Matrix_Zeroes
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new int[] {1, 1, 1}, new int[] {1, 0, 1}, new int[] {1, 1, 1},};
            SetZeroes(t);
            Assert.IsTrue(new int[][] {new int[] {1, 0, 1}, new int[] {0, 0, 0}, new int[] {1, 0, 1}}.SequenceEqual(t, new EqualityComparerArray()));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[][] {new int[] { 0, 1, 2, 0 }, new int[] { 3, 4, 5, 2 }, new int[] { 1, 3, 1, 5 },};
            SetZeroes(t);
            Assert.IsTrue(new int[][] {new int[] { 0, 0, 0, 0 }, new int[] { 0, 4, 5, 0 }, new int[] { 0, 3, 1, 0 } }.SequenceEqual(t, new EqualityComparerArray()));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[][] {new int[] {-1 }, new int[] { 2 }, new int[] { 3},};
            SetZeroes(t);
            Assert.IsTrue(new int[][] {  new int[] { -1 }, new int[] { 2 }, new int[] { 3 } }.SequenceEqual(t, new EqualityComparerArray()));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[][] {new int[] { 9, -6, -1, -2, 5 }, new int[] { -1, 3, 2147483647, -4, 0 }, new int[] { -3, -4, 0, 4, -2147483648 },};
            SetZeroes(t);
            Assert.IsTrue(new int[][] {  new int[] { 9, -6, 0, -2, 0 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 } }.SequenceEqual(t, new EqualityComparerArray()));
        }

        public void SetZeroes(int[][] matrix)
        {
            var stack = new Stack<(int,int)>();
            for(var i = 0;i <matrix.Length;i++)
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == -1)
                {
                    stack.Push((i,j));
                    matrix[i][j] = 1;
                }else if (matrix[i][j] == 0) matrix[i][j] = -1;
            }

            for (var i = 0; i < matrix.Length; i++)
                for (var j = 0; j < matrix[i].Length; j++)
                    if(matrix[i][j] == -1) SetZeroesToColumnAndRow(i,j);

            (int, int) ones;
            while (stack.TryPop(out ones))
            {
                if(matrix[ones.Item1][ones.Item2] != 0) matrix[ones.Item1][ones.Item2] = -1;
            }

            void SetZeroesToColumnAndRow(int x, int y)
            {
                matrix[x][y] = 0;
                for (var i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i][y] == -1)
                    {
                        SetZeroesToColumnAndRow(i,y);
                        break;
                    }
                    matrix[i][y] = 0;
                }

                for (var j = 0; j < matrix[x].Length; j++)
                {
                    if (matrix[x][j] == -1)
                    {
                        SetZeroesToColumnAndRow(x, j);
                        break;
                    }
                    matrix[x][j] = 0;
                }
            }
        }
        
    }
    public class EqualityComparerArray : IEqualityComparer<int[]>
    {

        public bool Equals(int[] x, int[] y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(int[] obj)
        {
            return obj.GetHashCode();
        }
    }
}
