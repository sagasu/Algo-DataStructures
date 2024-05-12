using System.Linq;

namespace AlgoTest.LeetCode.Largest_Local_Values_in_a_Matrix;

public class Largest_Local_Values_in_a_Matrix
{
    public int[][] LargestLocal(int[][] grid) => 
        Enumerable
            .Range(0, grid.Length - 2)
            .Select(i =>
                Enumerable
                    .Range(0, grid.Length - 2)
                    .Select(j =>
                        grid[i..(i+3)].Max(row => row[j..(j+3)].Max())
                    )
                    .ToArray()
            )
            .ToArray();
}