using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Disconnect_Path_in_a_Binary_Matrix_by_at_Most_One_Flip;

public class Disconnect_Path_in_a_Binary_Matrix_by_at_Most_One_Flip
{
    public bool IsPossibleToCutPath(int[][] grid) 
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var visited = new HashSet<(int, int)>();
        var q = new Queue<(int, int)>();
        q.Enqueue((0, 0));
        var reachEnd = false;
        while (q.Count > 0)
        {
            var count = q.Count();
            for (var i = 0; i < count; i++)
            {
                var point = q.Dequeue();
                
                var x = point.Item1;
                var y = point.Item2 + 1;
                if (x == m - 1 && y == n - 1)
                {
                    q.Enqueue(point);
                    reachEnd = true;
                }
                if (x < m && y < n && grid[x][y] == 1 && !visited.Contains((x, y)))
                {
                    visited.Add((x, y));
                    q.Enqueue((x, y));
                }

                x = point.Item1 + 1;
                y = point.Item2;
                if (x == m - 1 && y == n - 1)
                {
                    q.Enqueue(point);
                    reachEnd = true;
                }
                
                if (x < m && y < n && grid[x][y] == 1 && !visited.Contains((x, y)))
                {
                    visited.Add((x, y));
                    q.Enqueue((x, y));
                }
            }
            
            if (q.Count <= 1) return true;

            if (reachEnd) return q.Count <= 1;
            
        }
        return true;
    }
}