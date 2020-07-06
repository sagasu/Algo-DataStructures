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
            var hashSet = new HashSet<string>();
            var isCycle = false;
            var second = new int[cells.Length];
            var cnt = 0;
            while (N > 0)
            {
                GetSecond(cells, second);
                var key = string.Join("", second);
                if (hashSet.Contains(key))
                {
                    isCycle = true;
                    break;
                }
                else
                {
                    cnt += 1;
                    hashSet.Add(key);
                }

                N -= 1;
                var temp = second;
                second = cells;
                cells = temp;
            }

            if (isCycle)
            {
                N = N % cnt;
                while (N > 0)
                {
                    GetSecond(cells, second);
                    N -= 1;
                    var temp = second;
                    second = cells;
                    cells = temp;
                }
            }

            return cells;
        }

        private static void GetSecond(int[] cells, int[] second)
        {
            second[0] = 0;
            for (var i = 1; i < cells.Length - 1; i++)
            {
                second[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
            }

            second[cells.Length - 1] = 0;
        }
    }
}
