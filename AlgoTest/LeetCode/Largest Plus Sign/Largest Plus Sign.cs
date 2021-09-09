using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Largest_Plus_Sign
{
    class Largest_Plus_Sign
    {
        public int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            if (mines.Length == 0) return n / 2;

            var matrix = new bool[n, n];
            foreach (var mine in mines) matrix[mine[0], mine[1]] = true;

            var upDown = new int[n, n];
            var leftRight = new int[n, n];

            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++) {
                if (!matrix[i, j]) {
                    upDown[i, j] = i == 0 ? 1 : upDown[i - 1, j] + 1;
                    leftRight[i, j] = j == 0 ? 1 : leftRight[i, j - 1] + 1;
                }
            }
            

            for (var i = n - 1; i >= 0; i--)
            for (var j = n - 1; j >= 0; j--) {
                if (!matrix[i, j]) {
                        upDown[i, j] = i == n - 1 ? 1 : Math.Min(upDown[i, j], upDown[i + 1, j] + 1);
                        leftRight[i, j] = j == n - 1 ? 1 : Math.Min(leftRight[i, j], leftRight[i, j + 1] + 1);
                }
            }
            

            var result = 0;
            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                result = Math.Max(result, Math.Min(upDown[i, j], leftRight[i, j]));
                
            
            return result;
        }
    }
}
