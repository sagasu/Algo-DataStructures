using System.Linq;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Spiral_Matrix_IV;

public class Spiral_Matrix_IV
{
    public int[][] SpiralMatrix(int m, int n, ListNode head) 
    {
        var res = Enumerable.Range(0, m).Select(i => Enumerable.Repeat(-1, n).ToArray()).ToArray();
        
        for (int i = 0, j = 0, di = 0, dj = +1; head is not null; (i, j) = (i + di, j + dj)) 
        {
            res[i][j] = head.val;
            head = head.next;
            
            if (!isOK(i + di, j + dj)) (di, dj) = (dj, -di);
                
            bool isOK(int x, int y) => x >= 0 && x < m && y >= 0 && y < n && res[x][y] == -1; 
        }
        return res;
    }
}