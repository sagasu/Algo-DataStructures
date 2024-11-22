using System.Linq;

namespace AlgoTest.LeetCode.Flip_Columns_For_Maximum_Number_of_Equal_Rows;

public class Flip_Columns_For_Maximum_Number_of_Equal_Rows
{
    public int MaxEqualRowsAfterFlips(int[][] M) => M
        .GroupBy(r => string.Concat(
            r.Select(c => r[0] ^ c)
        ))
        .Max(g => g.Count());
}