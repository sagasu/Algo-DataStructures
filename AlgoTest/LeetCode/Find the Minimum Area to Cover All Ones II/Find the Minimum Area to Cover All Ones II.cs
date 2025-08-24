using System;

namespace AlgoTest.LeetCode.Find_the_Minimum_Area_to_Cover_All_Ones_II;

public class Find_the_Minimum_Area_to_Cover_All_Ones_II
{
    const int INF = 1 << 29;

    public int MinimumSum(int[][] grid) {
        int H = grid.Length, W = grid[0].Length;

        int[,] nextRightRow = new int[H, W];
        int[,] prevLeftRow  = new int[H, W];
        for (int r = 0; r < H; ++r) {
            int nxt = W;
            for (int c = W - 1; c >= 0; --c) {
                if (grid[r][c] == 1) nxt = c;
                nextRightRow[r, c] = nxt; 
            }
            int prv = -1;
            for (int c = 0; c < W; ++c) {
                if (grid[r][c] == 1) prv = c;
                prevLeftRow[r, c] = prv; 
            }
        }
        int[,] nextDownCol = new int[W, H];
        int[,] prevUpCol   = new int[W, H];
        for (int c = 0; c < W; ++c) {
            int nxt = H;
            for (int r = H - 1; r >= 0; --r) {
                if (grid[r][c] == 1) nxt = r;
                nextDownCol[c, r] = nxt; 
            }
            int prv = -1;
            for (int r = 0; r < H; ++r) {
                if (grid[r][c] == 1) prv = r;
                prevUpCol[c, r] = prv; 
            }
        }

        int[,] costCol = new int[W, W];
        {
            bool[] colHas = new bool[W];
            int[] colMinR = new int[W];
            int[] colMaxR = new int[W];
            for (int c = 0; c < W; ++c) {
                int mn = H, mx = -1;
                for (int r = 0; r < H; ++r) if (grid[r][c] == 1) { mn = Math.Min(mn, r); mx = Math.Max(mx, r); }
                if (mn <= mx) { colHas[c] = true; colMinR[c] = mn; colMaxR[c] = mx; }
            }
            for (int L = 0; L < W; ++L) {
                int top = H, bot = -1, left = -1, right = -1;
                bool any = false;
                for (int R = L; R < W; ++R) {
                    if (colHas[R]) {
                        if (!any) left = R;
                        right = R; any = true;
                        top = Math.Min(top, colMinR[R]);
                        bot = Math.Max(bot, colMaxR[R]);
                    }
                    costCol[L, R] = any ? (right - left + 1) * (bot - top + 1) : 1;
                }
            }
        }

        int[,] costRow = new int[H, H];
        {
            bool[] rowHas = new bool[H];
            int[] rowMinC = new int[H];
            int[] rowMaxC = new int[H];
            for (int r = 0; r < H; ++r) {
                int mn = W, mx = -1;
                for (int c = 0; c < W; ++c) if (grid[r][c] == 1) { mn = Math.Min(mn, c); mx = Math.Max(mx, c); }
                if (mn <= mx) { rowHas[r] = true; rowMinC[r] = mn; rowMaxC[r] = mx; }
            }
            for (int T = 0; T < H; ++T) {
                int left = W, right = -1, top = -1, bot = -1;
                bool any = false;
                for (int B = T; B < H; ++B) {
                    if (rowHas[B]) {
                        if (!any) top = B;
                        bot = B; any = true;
                        left  = Math.Min(left,  rowMinC[B]);
                        right = Math.Max(right, rowMaxC[B]);
                    }
                    costRow[T, B] = any ? (right - left + 1) * (bot - top + 1) : 1;
                }
            }
        }

        int[,] best2H_Cols = new int[W, W];
        for (int L = 0; L < W; ++L) {
            for (int R = L; R < W; ++R) {
                int[] pref = new int[H];
                int[] suf  = new int[H];

                bool any = false;
                int top = H, bot = -1, left = W, right = -1;

                for (int r = 0; r < H; ++r) {
                    int leftPos = nextRightRow[r, L];
                    if (leftPos <= R) {
                        any = true;
                        if (top == H) top = r;
                        bot = r;
                        left  = Math.Min(left, leftPos);
                        right = Math.Max(right, prevLeftRow[r, R]);
                    }
                    pref[r] = any ? (bot - top + 1) * (right - left + 1) : 1;
                }

                any = false; top = H; bot = -1; left = W; right = -1;
                for (int r = H - 1; r >= 0; --r) {
                    int leftPos = nextRightRow[r, L];
                    if (leftPos <= R) {
                        any = true;
                        if (bot == -1) bot = r;
                        top = r;
                        left  = Math.Min(left, leftPos);
                        right = Math.Max(right, prevLeftRow[r, R]);
                    }
                    suf[r] = any ? (bot - top + 1) * (right - left + 1) : 1;
                }
                int best = INF;
                if (H == 1) best = 2;
                else {
                    for (int r = 0; r + 1 < H; ++r) best = Math.Min(best, pref[r] + suf[r + 1]);
                }
                best2H_Cols[L, R] = best;
            }
        }

        int[,] best2V_Rows = new int[H, H];
        for (int T = 0; T < H; ++T) {
            for (int B = T; B < H; ++B) {
                int[] pref = new int[W];
                int[] suf  = new int[W];

                bool any = false;
                int leftMost = -1, rightMost = -1, top = H, bot = -1;

                for (int c = 0; c < W; ++c) {
                    int first = nextDownCol[c, T];
                    if (first <= B) {
                        any = true;
                        if (leftMost == -1) leftMost = c;
                        rightMost = c;
                        top = Math.Min(top, first);
                        bot = Math.Max(bot, prevUpCol[c, B]);
                    }
                    pref[c] = any ? (rightMost - leftMost + 1) * (bot - top + 1) : 1;
                }

                any = false; leftMost = -1; rightMost = -1; top = H; bot = -1;
                for (int c = W - 1; c >= 0; --c) {
                    int first = nextDownCol[c, T];
                    if (first <= B) {
                        any = true;
                        if (rightMost == -1) rightMost = c;
                        leftMost = c;
                        top = Math.Min(top, first);
                        bot = Math.Max(bot, prevUpCol[c, B]);
                    }
                    suf[c] = any ? (rightMost - leftMost + 1) * (bot - top + 1) : 1;
                }

                int best = INF;
                if (W == 1) best = 2;
                else {
                    for (int c = 0; c + 1 < W; ++c) best = Math.Min(best, pref[c] + suf[c + 1]);
                }
                best2V_Rows[T, B] = best;
            }
        }

        int threeVertical = ThreeStripes(costCol, W);
        int threeHorizontal = ThreeStripes(costRow, H);

        int ans = Math.Min(threeVertical, threeHorizontal);

        for (int c = 0; c + 1 < W; ++c) {
            ans = Math.Min(ans, costCol[0, c] + best2H_Cols[c + 1, W - 1]);
            ans = Math.Min(ans, best2H_Cols[0, c] + costCol[c + 1, W - 1]);
        }
        for (int r = 0; r + 1 < H; ++r) {
            ans = Math.Min(ans, costRow[0, r] + best2V_Rows[r + 1, H - 1]);
            ans = Math.Min(ans, best2V_Rows[0, r] + costRow[r + 1, H - 1]);
        }

        return ans;
    }

    private int ThreeStripes(int[,] cost, int N) {
        int[] dp1 = new int[N];
        for (int i = 0; i < N; ++i) dp1[i] = cost[0, i];

        int[] dp2 = new int[N];
        Array.Fill(dp2, INF);
        for (int i = 0; i < N; ++i)
            for (int j = 0; j < i; ++j)
                dp2[i] = Math.Min(dp2[i], dp1[j] + cost[j + 1, i]);

        int[] dp3 = new int[N];
        Array.Fill(dp3, INF);
        for (int i = 0; i < N; ++i)
            for (int j = 0; j < i; ++j)
                if (dp2[j] < INF) dp3[i] = Math.Min(dp3[i], dp2[j] + cost[j + 1, i]);

        return dp3[N - 1];
    }
}