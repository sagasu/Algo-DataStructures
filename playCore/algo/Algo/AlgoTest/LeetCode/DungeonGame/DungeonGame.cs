using System;

namespace AlgoTest.LeetCode.DungeonGame
{
    public class DungeonGame
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            if (dungeon.Length == 0)
                return 0;

            var dp = new int[dungeon.Length, dungeon[0].Length];

            for (var i = dungeon.Length - 1; i >= 0; i--)
            {
                for (var j = dungeon[0].Length - 1; j >= 0; j--)
                {
                    var opt1 = int.MaxValue;
                    var opt2 = int.MaxValue;

                    if (i != dungeon.Length - 1)
                    {
                        opt1 = dp[i + 1, j];
                    }

                    if (j != dungeon[0].Length - 1)
                    {
                        opt2 = dp[i, j + 1];
                    }

                    if (i == dungeon.Length - 1 && j == dungeon[0].Length - 1)
                    {
                        dp[i, j] = Math.Max(0, -dungeon[i][j]);
                    }
                    else
                    {
                        dp[i, j] = Math.Max(0, Math.Min(opt1, opt2) - dungeon[i][j]);
                    }

                }
            }

            return dp[0, 0] + 1;
        }
    }
}
