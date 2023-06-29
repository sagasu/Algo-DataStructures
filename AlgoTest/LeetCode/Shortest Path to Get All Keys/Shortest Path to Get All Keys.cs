using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Shortest_Path_to_Get_All_Keys
{
    internal class Shortest_Path_to_Get_All_Keys
    {
        private static readonly (int di, int dj)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) };

        public int ShortestPathAllKeys(string[] grid)
        {
  
                var n = grid.Length;
                var m = grid[0].Length;

                IList<char> keys = new List<char>(6);
                var start = -1;

                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < m; j++)
                    {
                        if (grid[i][j] >= 'a' && grid[i][j] <= 'z')
                        {
                            keys.Add(grid[i][j]);
                            continue;
                        }

                        if (grid[i][j] == '@')
                        {
                            start = i * m + j;
                        }
                    }
                }

                var maxKeysMask = (int)Math.Pow(2, keys.Count);
                var visited = new bool[n * m, maxKeysMask];
                var bfs = new Queue<(int pos, int mask)>();
                bfs.Enqueue((start, 0));
                visited[start, 0] = true;
                var res = 0;

                while (bfs.Count != 0)
                {
                    var count = bfs.Count;

                    for (var c = 0; c < count; c++)
                    {
                        var curr = bfs.Dequeue();
                        if (curr.mask == maxKeysMask - 1)
                        {
                            return res;
                        }

                        var i = curr.pos / m;
                        var j = curr.pos % m;

                        foreach (var dir in _directions)
                        {
                            var newI = i + dir.di;
                            var newJ = j + dir.dj;
                            var newLinear = newI * m + newJ;

                            if (newI >= 0 && newJ >= 0 && newI < n && newJ < m && grid[newI][newJ] != '#')
                            {
                                var mask = curr.mask;

                                if (grid[newI][newJ] >= 'a' && grid[newI][newJ] <= 'z')
                                {
                                    var idx = keys.IndexOf(grid[newI][newJ]);
                                    mask |= (1 << idx);
                                }

                                if (visited[newLinear, mask])
                                {
                                    continue;
                                }

                                if (grid[newI][newJ] >= 'A' && grid[newI][newJ] <= 'Z')
                                {
                                    var idx = keys.IndexOf((char)(grid[newI][newJ] - ('A' - 'a')));
                                    if (idx < 0 || (mask & (1 << idx)) == 0)
                                    {
                                        continue;
                                    }
                                }

                                visited[newLinear, mask] = true;
                                bfs.Enqueue((newLinear, mask));
                            }
                        }
                    }

                    res++;
                }


                return -1;
            
        }
    }
}
