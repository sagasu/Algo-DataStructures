public class Solution {
    public int[][] Transpose(int[][] A) {
        int n = A.Length;
        int m = A[0].Length;
        int [][] transpose = new int[m][];
        
        for(int i = 0; i < m; i++) //this loop is because i cant just declare int [][] transpose = new int[m][n] ... c# things
        {
            transpose[i] = new int[n];
        }
        
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                transpose[j][i] = A[i][j];
            }
        }
        
        return transpose;
    }
}
