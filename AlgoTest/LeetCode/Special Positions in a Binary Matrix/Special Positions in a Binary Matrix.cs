using System.Linq;

namespace AlgoTest.LeetCode.Special_Positions_in_a_Binary_Matrix;

public class Special_Positions_in_a_Binary_Matrix
{
    public int NumSpecial(int[][] mat) {
        var rows = Enumerable.Range(0, mat.Length).Where(i => mat[i].Sum() == 1).ToArray();
        var cols = Enumerable.Range(0, mat[0].Length).Where(j => mat.Sum(x => x[j]) == 1).ToArray();
        return rows.SelectMany(r => cols.Select(c => (r, c))).Count(t => mat[t.r][t.c] == 1);
    }
}