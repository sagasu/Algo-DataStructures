using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Knight_Dialer;

[TestClass]
public class Knight_Dialer
{
    [TestMethod]
    public void Test() => Assert.AreEqual(20, KnightDialer(2));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(136006598, KnightDialer(3131));
    
    int MOD = (int)(1e9 + 7);
    int[][] memo;
    int n;
    
    int[][] jumps = new int[][]
    {
        new int[]{4,6},
        new int[]{6,8},
        new int[]{4,6},
        new int[]{7,9},
        new int[]{4,8},
        new int[]{0,3,9},
        new int[]{},//5
        new int[]{0,1,7},
        new int[]{2,6},
        new int[]{1,3},
        new int[]{2,4},
    };
    
    public int KnightDialer(int n)
    {
        this.n = n;
        memo = new int[n + 1][];
        for (var i=0;i< memo.Length;i++)
            memo[i] = new int[10];
        
        var ans = 0;
        for (var square = 0; square < 10; square++)
            ans = (ans + dp(n - 1, square)) % MOD;
        
        return ans;
    }

    private int dp(int remain, int square) {
        if (remain == 0) return 1;
        
        if (memo[remain][square] != 0)
            return memo[remain][square];
        
        var ans = jumps[square].Aggregate(0, (current, nextSquare) => (current + dp(remain - 1, nextSquare)) % MOD);

        memo[remain][square] = ans;
        return ans;
    }
}