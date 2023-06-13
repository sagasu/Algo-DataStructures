using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Equal_Row_and_Column_Pairs
{
    [TestClass]
    public class Equal_Row_and_Column_Pairs
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(1, EqualPairs(new[] {new[]{ 3, 2, 1 }, new[] { 1, 7, 6},new[]{2, 7, 7}}));
        
        [TestMethod]
        public void Test1() => Assert.AreEqual(3, EqualPairs(new[] {new[]{ 3, 1, 2, 2 }, new[] { 1, 4, 4, 5 }, new[]{ 2, 4, 2, 2 }, new[] { 2, 4, 2, 2 } }));

        public int EqualPairs(int[][] grid)
        {
            var count = 0;
            var list = new List<string>();
            for (var i = 0; i < grid.Length; i++)
            {
                var hash = new StringBuilder();
                for (var j = 0; j < grid[i].Length; j++)
                    hash.Append(grid[i][j]+".");
                
                list.Add(hash.ToString());
            }

            for (var i = 0; i < grid[0].Length; i++)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < grid.Length; j++)
                    sb.Append(grid[j][i] + ".");

                var hash = sb.ToString();
                list.ForEach(x =>
                {
                    if (x == hash) count++;
                });
            }

            return count;
        }

    }
}
