using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Last_Day_Where_You_Can_Still_Cross
{
    internal class Last_Day_Where_You_Can_Still_Cross
    {
        private static bool HasPath(int[][] cells, int colCount, int rowCount, int day)
        {
            var flooded = cells
                .Take(day)
                .Select(cell => (row: cell[0], col: cell[1]))
                .ToHashSet();

            Stack<(int row, int col)> agenda = new();

            for (int c = 1; c <= colCount; ++c)
                if (!flooded.Contains((1, c)))
                {
                    agenda.Push((1, c));
                    flooded.Add((1, c));
                }

            while (agenda.Count > 0)
            {
                var p = agenda.Pop();

                for (int d = 3; d >= 0; --d)
                {
                    int nr = p.row + (d - 2) % 2;
                    int nc = p.col + (d - 1) % 2;

                    if (nr < 1 || nc < 1 || nr > rowCount || nc > colCount)
                        continue;

                    if (!flooded.Add((nr, nc)))
                        continue;

                    if (nr == rowCount)
                        return true;

                    agenda.Push((nr, nc));
                }
            }

            return false;
        }

        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            if (HasPath(cells, col, row, cells.Length))
                return cells.Length;

            int ever = 0;
            int never = cells.Length;

            while (never - ever > 1)
            {
                int middle = (never + ever) / 2;

                if (HasPath(cells, col, row, middle))
                    ever = middle;
                else
                    never = middle;
            }

            return ever;
        }
    }
}
