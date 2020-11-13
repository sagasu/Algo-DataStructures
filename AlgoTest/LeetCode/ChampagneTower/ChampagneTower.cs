using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ChampagneTower
{
    [TestClass]
    public class ChampagneTowerSolution
    {
        [TestMethod]
        public void TesT()
        {
            //Assert.AreEqual(0,ChampagneTower(1,1,1));
            Assert.AreEqual(0.5,ChampagneTower(2,1,1));
            Assert.AreEqual(1.0,ChampagneTower(100000009, 33,17));
        }

        // Nice way to handle a Pascal triangle, thru building dynamic size array for each row, and really simple array modification.
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            var arr = new double[query_row+2][];
            arr[0] = new double[1];
            arr[0][0] = poured;
            
            for (var i = 0; i <= query_row; i++)
            {
                arr[i + 1] = new double[i + 2];
                for (var j = 0; j <= i; j++)
                {
                    if (arr[i][j] > 1)
                    {
                        arr[i][j] -= 1;
                        double next = arr[i][j] / (double)2;

                        arr[i + 1][j] += next;
                        arr[i + 1][j + 1] += next;
                    }
                }
            }

            return arr[query_row][query_glass] < 1 ? arr[query_row][query_glass] : 1;
        }
    }
}
