using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Unique_Paths_II
{
    [TestClass]
    public class Unique_Paths_II_TimeOut2
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new int[] {0, 0, 0}, new int[] {0, 1, 0}, new int[] {0, 0, 0}};
            Assert.AreEqual(2,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[][] {new int[] { 0, 1 }, new int[] { 0, 0 }};
            Assert.AreEqual(1,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[][] {new int[] { 1 }};
            Assert.AreEqual(0,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[][] {new int[] { 1,0 }};
            Assert.AreEqual(0,UniquePathsWithObstacles(t));
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[obstacleGrid.Length - 1].Length - 1] == 1) return 0;
            var stack = new Stack<ValueTuple<int,int>>();
            stack.Push((obstacleGrid.Length - 1, obstacleGrid[obstacleGrid.Length-1].Length-1));

            var paths = 0;
            var pair = new ValueTuple<int, int>();
            while(stack.TryPop(out pair))
            {
                var row = pair.Item1;
                var column = pair.Item2;
                if (row == 0 && column == 0)
                {
                    paths += 1;
                    continue;
                }

                if(row - 1 >= 0 && obstacleGrid[row - 1][column] == 0) stack.Push((row - 1, column));
                if(column - 1 >= 0 && obstacleGrid[row][column - 1] == 0) stack.Push((row, column-1));
            }

            return paths;
        }
    }
}
