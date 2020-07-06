using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PrisonCellsAfterNDays
{
    [TestClass]
    public class PrisonCellsAfterNDays
    {
        [TestMethod]
        public void Test()
        {
            //var t = new int[] {0, 1, 0, 1, 1, 0, 0, 1};
            //PrisonAfterNDays(t, 7);
            
            var t = new int[] {1, 0, 0, 1, 0, 0, 1, 0};
            PrisonAfterNDays(t, 1000000000);
        }

        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            var second = new int[cells.Length];
            while (N > 0)
            {
                second[0] = 0;
                for (var i = 1; i < cells.Length - 1; i++)
                {
                    second[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
                }

                second[cells.Length - 1] = 0;
                N -= 1;
                var temp = second;
                second = cells;
                cells = temp;
            }

            return cells;
        }
    }
}
