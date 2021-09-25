using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Shortest_Path_in_a_Grid_with_Obstacles_Elimination
{
    class Shortest_Path_in_a_Grid_with_Obstacles_Elimination
    {
        public int ShortestPath(int[][] grid, int k)
        {
            var rows = grid.Length;
            var columns = grid[0].Length;

            // it is tough for me to figure out using three dimension - third dimension -
            // k obstacles to remove
            var visited = new bool[rows, columns, k + 1];

            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0, k });

            visited[0, 0, k] = true;

            var directions = new int[4][];
            directions[0] = new int[] { -1, 0 };  // top
            directions[1] = new int[] { 0, 1 }; // right
            directions[2] = new int[] { 1, 0 }; // down
            directions[3] = new int[] { 0, -1 }; // left

            var minimum = 0;
            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (var i = 0; i < count; i++)
                {
                    var current = queue.Dequeue();
                    var row = current[0];
                    var col = current[1];
                    var left = current[2];

                    if (row == rows - 1 && col == columns - 1) return minimum;
                    

                    foreach (var dir in directions)
                    {
                        var newRow = row + dir[0];
                        var newCol = col + dir[1];

                        if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= columns)
                        {
                            continue;
                        }

                        if (grid[newRow][newCol] == 0 && !visited[newRow, newCol, left])
                        {
                            // keep the same obstacles - but mark visit for left number
                            visited[newRow, newCol, left] = true;
                            queue.Enqueue(new int[] { newRow, newCol, left });
                            continue;
                        }

                        if (grid[newRow][newCol] == 1 && left != 0 && !visited[newRow, newCol, left - 1])
                        {
                            // replace current obstacle with 0, decrement variable left
                            visited[newRow, newCol, left - 1] = true;
                            queue.Enqueue(new int[] { newRow, newCol, left - 1 });
                        }
                    }
                }

                minimum++;
            }

            return -1;
        }
    }
}
