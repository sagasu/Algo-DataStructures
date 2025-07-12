using System;

namespace AlgoTest.LeetCode.The_Earliest_and_Latest_Rounds_Where_Players_Compete;

public class The_Earliest_and_Latest_Rounds_Where_Players_Compete
{
    private int[,,] F = new int[30, 30, 30];
    private int[,,] G = new int[30, 30, 30];

    private int[] Dp(int n, int f, int s)
    {
        if (F[n, f, s] != 0)
            return new int[] { F[n, f, s], G[n, f, s] };
        
        if (f + s == n + 1)
            return new int[] { 1, 1 };

        if (f + s > n + 1)
        {
            int[] res = Dp(n, n + 1 - s, n + 1 - f);
            F[n, f, s] = res[0];
            G[n, f, s] = res[1];
            return new int[] { F[n, f, s], G[n, f, s] };
        }

        int earliest = int.MaxValue, latest = int.MinValue;
        int n_half = (n + 1) / 2;
        if (s <= n_half)
        {
            for (int i = 0; i < f; ++i)
            {
                for (int j = 0; j < s - f; ++j)
                {
                    var res = Dp(n_half, i + 1, i + j + 2);
                    earliest = Math.Min(earliest, res[0]);
                    latest = Math.Max(latest, res[1]);
                }
            }
        }
        else
        {
            var s_prime = n + 1 - s;
            var mid = (n - 2 * s_prime + 1) / 2;
            for (int i = 0; i < f; ++i)
            {
                for (int j = 0; j < s_prime - f; ++j)
                {
                    int[] res = Dp(n_half, i + 1, i + j + mid + 2);
                    earliest = Math.Min(earliest, res[0]);
                    latest = Math.Max(latest, res[1]);
                }
            }
        }

        F[n, f, s] = earliest + 1;
        G[n, f, s] = latest + 1;
        return new int[] { F[n, f, s], G[n, f, s] };
    }

    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        if (firstPlayer > secondPlayer)
            (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);

        var res = Dp(n, firstPlayer, secondPlayer);
        return new int[] { res[0], res[1] };
    }
}