namespace AlgoTest.LeetCode.CountGoodArrays;

public class CountGoodArrays2
{
    const int MOD = 1000000007;

    public int CountGoodArrays(int n, int m, int k) {
        long[] fac = new long[n];
        long[] inv = new long[n];
        fac[0] = 1;

        for (int i = 1; i < n; i++)
        {
            fac[i] = fac[i - 1] * i % MOD;
        }

        inv[n - 1] = ModPow(fac[n - 1], MOD - 2);

        for (int i = n - 2; i >= 0; i--)
        {
            inv[i] = inv[i + 1] * (i + 1) % MOD;
        }

        long combs = fac[n - 1] * inv[k] % MOD * inv[n - 1 - k] % MOD;
        
        long powTerm = ModPow(m - 1, n - 1 - k);
        
        long res = combs * m % MOD * powTerm % MOD;

        return (int)res;
    }

    long ModPow(long x, long e)
    {
        long res = 1;
        x %= MOD;

        while (e > 0)
        {
            if ((e & 1) != 0)
                res = (res * x) % MOD;

            x = (x * x) % MOD;
            e >>= 1;
        }

        return res;
    }
}