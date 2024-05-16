using System;
using System.Linq;

namespace AlgoTest.LeetCode.Score_After_Flipping_Matrix;

public class Score_After_Flipping_Matrix
{
    public int MatrixScore(int[][] g) => Enumerable
        .Range(1, g[0].Length - 1)
        .Select(j => Enumerable
            .Range(0, g.Length)
            .Sum(i => g[i][j] ^ g[i][0]))
        .Aggregate(g.Length, (a, b) => (a << 1) + Math.Max(b, g.Length - b));
}