using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_K_Divisible_Components;

public class Maximum_Number_of_K_Divisible_Components
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var e in edges) {
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }
        int ans = 0;
        long K = k;
        long Dfs(int u, int p) {
            long sum = values[u] % K;
            foreach (int v in g[u]) {
                if (v == p) continue;
                sum = (sum + Dfs(v, u)) % K;
            }
            if (sum % K == 0) {
                ans++;
                return 0;
            }
            return sum;
        }
        Dfs(0, -1);
        return ans;
    }
}