namespace AlgoTest.LeetCode.Diagonal_Traverse;

public class Diagonal_Traverse
{
    public int[] FindDiagonalOrder(int[][] mat) 
    {
        var numElements = mat.Length * mat[0].Length;
        var cntElements = 0;
        var result = new int[numElements];
        var row = 0;
        var col = 0;
        var directionUp = true;
        while (cntElements < numElements)
        {
            if (directionUp)
            {
                if(row >= mat.Length)
                {
                    row = mat.Length - 1;
                    col++;
                }

                while (row >= 0 && col < mat[0].Length && cntElements < numElements)
                {
                    result[cntElements] = mat[row][col];
                    cntElements++;
                    row--;
                    col++;
                }

                row++;

                directionUp = false;
            }
            else
            {
                if(col >= mat[0].Length)
                {
                    col = mat[0].Length - 1;
                    row++;
                }

                while (row < mat.Length && col >= 0 && cntElements < numElements)
                {
                    result[cntElements] = mat[row][col];
                    cntElements++;
                    row++;
                    col--;
                }

                col++;

                directionUp = true;
            }
        }

        return result;
    }
}