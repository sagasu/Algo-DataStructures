namespace AlgoTest.LeetCode.NumSubmat;

public class NumSubmatSolution
{
    public int NumSubmat(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, res = 0;
        int[] h = new int[n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++)
                h[j] = (mat[i][j] == 0) ? 0 : h[j] + 1;

            for (int j = 0; j < n; j++) {
                int minH = int.MaxValue;
                for (int k = j; k >= 0 && h[k] > 0; k--) {
                    if (h[k] < minH) minH = h[k];
                    res += minH;
                }
            }
        }
        return res;
    }
}