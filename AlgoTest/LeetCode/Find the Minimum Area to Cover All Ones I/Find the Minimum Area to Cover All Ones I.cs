namespace AlgoTest.LeetCode.Find_the_Minimum_Area_to_Cover_All_Ones_I;

public class Find_the_Minimum_Area_to_Cover_All_Ones_I
{
    public int MinimumArea(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        int minRow = rows, minCol = cols, maxRow = -1, maxCol = -1;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 1) {
                    if (i < minRow) minRow = i;
                    if (i > maxRow) maxRow = i;
                    if (j < minCol) minCol = j;
                    if (j > maxCol) maxCol = j;
                }
            }
        }
        return (maxRow == -1) ? 0 : (maxRow - minRow + 1) * (maxCol - minCol + 1);
    }
}