using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Count_Unguarded_Cells_in_the_Grid;

public class Count_Unguarded_Cells_in_the_Grid
{
    private Dictionary<(int, int), List<char>> _map;
    private int _maxM;
    private int _maxN;

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        _map = new Dictionary<(int, int), List<char>>();
        _maxM = m;
        _maxN = n;
        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                _map.Add((i, j), new List<char>() {'o'});
            }
        }

        foreach(var wall in walls)
        {
            _map[(wall[0], wall[1])].Add('x');
        }

        foreach(var g in guards)
        {
            GuardTraverse(g[0], g[1], 'a');
        }

        return _map.Count(x => x.Value.Count == 1);
    }

    private void GuardTraverse(int m, int n, char dir)
    {
        if(m < 0 || m >= _maxM || n < 0 || n >= _maxN || _map[(m, n)].Contains('x') || _map[(m, n)].Contains(dir))
        {
            return;
        }

        _map[(m, n)].Add(dir);
        if(dir == 'a' || dir == 's') GuardTraverse(m - 1, n, 's');
        if(dir == 'a' || dir == 'w') GuardTraverse(m, n - 1, 'w');
        if(dir == 'a' || dir == 'n') GuardTraverse(m + 1, n, 'n');
        if(dir == 'a' || dir == 'e') GuardTraverse(m, n + 1, 'e');
    }
}