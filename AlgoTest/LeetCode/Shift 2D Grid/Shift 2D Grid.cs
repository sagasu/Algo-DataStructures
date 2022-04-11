using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Shift_2D_Grid;

internal class Shift_2D_Grid
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> all = grid.SelectMany(o => o).ToList();
        int tot = all.Count();
        for (int i = 0; i < grid.Length; i++)
        {
            List<int> tmp = new List<int>();
            for (int j = 0; j < grid[0].Length; j++)
            {
                int pt = (i * grid[0].Length + j - k) % tot;
                while (pt < 0)
                {
                    pt += tot;
                }
                tmp.Add(all[pt]);
            }
            res.Add(tmp);
        }
        return res;
    }
}