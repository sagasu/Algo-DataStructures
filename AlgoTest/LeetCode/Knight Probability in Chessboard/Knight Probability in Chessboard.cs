public class Solution {
int[] dirR = new int[]{2, 2, 1, 1, -1, -1, -2, -2};
int[] dirC = new int[]{1, -1, 2, -2, 2, -2, 1, -1};
public double KnightProbability(int N, int K, int r, int c) {
    
    double[,,] dp = new double[K+1,N,N];
    dp[0,r,c] = 1;
    for (int step = 1; step <= K; step++) { //for each turn
        for (int i = 0; i < N; i++) { //for each row i
            for (int j = 0; j < N; j++) { //for each col j
                for (int d=0;d<8;d++) {
                    int x = i + dirR[d]; 
                    int y = j + dirC[d];
                    
                    if (x < 0 || x >= N || y < 0 || y >= N) continue;
                    dp[step,i,j] += dp[step - 1,x,y] * 0.125;
                }
            }
        }
    }
    //sum probability of being in each square of the board
    double res = 0;
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            res += dp[K,i,j];
        }
    }
    return res;
}
}
