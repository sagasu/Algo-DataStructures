using System;

namespace AlgoTest.LeetCode._24_Game;

public class A24_Game {
    const double TARGET = 24.0;
    const double EPS = 1e-4;

    public bool JudgePoint24(int[] cards)
    {
        double[] nums = new double[cards.Length];
        for (int i = 0; i < cards.Length; i++) nums[i] = cards[i];
        return Dfs(nums, nums.Length);
    }

    private bool Dfs(double[] nums, int n)
    {
        if (n == 1) return Math.Abs(nums[0] - TARGET) < EPS;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double a = nums[i], b = nums[j];

                double[] next = new double[n - 1];
                int idx = 0;
                for (int k = 0; k < n; k++) if (k != i && k != j) next[idx++] = nums[k];

                next[idx] = a + b; if (Dfs(next, n - 1)) return true;
                next[idx] = a * b; if (Dfs(next, n - 1)) return true;
                next[idx] = a - b; if (Dfs(next, n - 1)) return true;
                next[idx] = b - a; if (Dfs(next, n - 1)) return true;
                if (Math.Abs(b) > EPS) { next[idx] = a / b; if (Dfs(next, n - 1)) return true; }
                if (Math.Abs(a) > EPS) { next[idx] = b / a; if (Dfs(next, n - 1)) return true; }
            }
        }
        return false;
    }
}