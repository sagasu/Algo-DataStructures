using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Knight_Dialer;

[TestClass]
public class Knight_DialerOutOfTime
{
    [TestMethod]
    public void Test() => Assert.AreEqual(20, KnightDialer(2));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(136006598, KnightDialer(3131));
    
    public int KnightDialer(int n)
    {
        var num = new int[][]
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

        var MOD = 1e9 + 7;
        if (n == 1) return 10;
        int DFS(int nr, int n)
        {
            if (n == 1) return 0;
            var sum = 0;
            foreach (var i in num[nr])
            {
                sum += DFS(i,n-1) + 1;
            }

            return sum;
        }

        var ret = 0;
        for (var i = 0; i < 10; i++)
        {
            ret += DFS(i,n);
        }

        return (int)(ret % MOD);
    }
}