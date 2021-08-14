using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Remove_Boxes
{
    public class Remove_Boxes
    {
        public int RemoveBoxes(int[] boxes)
        {
            var n = boxes.Length;
            var dp = new int[n + 1, n + 1, n + 1];

            if (n == 0) return 0;

            for (var i = 0; i < n; i++)
                for (var k = 0; k <= i; k++)
                    dp[i,i,k] = (k + 1) * (k + 1); 
                
            
            for (var l = 2; l <= n; l++)
                for (var j = l - 1; j < n; j++) {
                    var i = j - l + 1;
                    for (var k = 0; k <= i; k++) {
                        var res = (k + 1) * (k + 1) + dp[i + 1,j,0];
                        for (var m = i + 1; m <= j; m++)
                            if (boxes[m] == boxes[i]) res = Math.Max(res, dp[i + 1,m - 1,0] + dp[m,j,k + 1]);
                        
                        dp[i,j,k] = res;
                    }
                }
            

            return dp[0,n - 1,0];
        }
    }
}
