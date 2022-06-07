public class TransposeMatrix
{
    public int[][] Transpose(int[][] A) {
        var n = A.Length;
        var m = A[0].Length;
        var transpose = new int[m][];
        
        for(var i = 0; i < m; i++) //this loop is because i cant just declare int [][] transpose = new int[m][n] ... c# things
        {
            transpose[i] = new int[n];
        }
        
        for(var i = 0; i < n; i++)
        {
            for(var j = 0; j < m; j++)
            {
                transpose[j][i] = A[i][j];
            }
        }
        
        return transpose;
    }
}
