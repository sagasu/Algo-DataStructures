using System.Collections.Generic;

namespace AlgoTest.LeetCode._01_Matrix;

public class _01_Matrix {
    public int[][] UpdateMatrix(int[][] mat) 
    {
        var queue = new Queue<(int, int)>();

        for (var i = 0; i < mat.Length; i++)
        for (var j = 0; j < mat[i].Length; j++)
            if (mat[i][j] == 0)
                queue.Enqueue((i, j));
        
        var visited = new HashSet<(int, int)>();
        var directions = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            foreach (var d in directions)
            {
                var p = (curr.Item1 + d.Item1, curr.Item2 + d.Item2);
                if (p.Item1 >= 0 && p.Item1 < mat.Length &&
                    p.Item2 >= 0 && p.Item2 < mat[0].Length) {
                    if (visited.Add(p) && mat[p.Item1][p.Item2] != 0)
                    {
                        mat[p.Item1][p.Item2] = mat[curr.Item1][curr.Item2] + 1;
                        queue.Enqueue(p);
                    }
                }
            }
        }
        
        return mat;
    }
}