using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid;

public class Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid
{
    public int MinCost(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            bool[][] visited = new bool[rows][];
            for (int row = 0; row < rows; row++)
            {
                visited[row] = new bool[cols];
            }

            Queue<(int row, int col, int cost)> q = new Queue<(int row, int col, int cost)>();
            Queue<(int row, int col, int cost)> stack = new Queue<(int row, int col, int cost)>();
            q.Enqueue((0, 0, 0));

            while (q.Count > 0)
            {
                while (q.Count > 0)
                {
                    var dq = q.Dequeue();
                    if (dq.row < 0 || dq.col < 0 || dq.row >= rows || dq.col >= cols) continue;
                    if (dq.row == rows - 1 && dq.col == cols - 1) { return dq.cost; }
                    visited[dq.row][dq.col] = true;
                    int dir = grid[dq.row][dq.col] - 1;

                    for (int i = 0; i < directions.Length; i++)
                    {
                        if (i == dir)
                        {
                            addInQ(q, visited, dq.row + directions[dir][0], dq.col + directions[dir][1], dq.cost);
                        }
                        else
                        {
                            addInQ(stack, visited, dq.row + directions[i][0], dq.col + directions[i][1], dq.cost + 1);
                        }
                    }
                }

                while (stack.Count>0)
                {
                    var dq = stack.Dequeue();

                    if (visited[dq.row][dq.col]) continue;

                    q.Enqueue(dq);
                    break;
                }
            }



            return rows+cols-2;
        }
        
        private void addInQ(Queue<(int row, int col, int cost)> q, bool[][] visited, int row, int col, int cost)
        {
            if (row < 0 || col < 0 || row >= visited.Length || col >= visited[row].Length || visited[row][col]) return;

            q.Enqueue((row, col, cost));
        }
}