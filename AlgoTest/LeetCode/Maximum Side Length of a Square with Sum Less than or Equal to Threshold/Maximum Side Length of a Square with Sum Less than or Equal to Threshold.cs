using System;

namespace AlgoTest.LeetCode.Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold;

public class Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold
{
    public int MaxSideLength(int[][] mat, int t) {
        int m = mat.Length, n = mat[0].Length;
        long[,] pre = new long[m+1,n+1];

        for(int i=1;i<=m;i++){
            long row=0;
            for(int j=1;j<=n;j++){
                row+=mat[i-1][j-1];
                pre[i,j]=pre[i-1,j]+row;
            }
        }

        bool Can(int len){
            for(int i=len;i<=m;i++){
                for(int j=len;j<=n;j++){
                    long s = pre[i,j]-pre[i-len,j]-pre[i,j-len]+pre[i-len,j-len];
                    if(s<=t) return true;
                }
            }
            return false;
        }

        int lo=0, hi=Math.Min(m,n);
        while(lo<hi){
            int mid=(lo+hi+1)>>1;
            if(Can(mid)) lo=mid;
            else hi=mid-1;
        }
        return lo;
    }
}