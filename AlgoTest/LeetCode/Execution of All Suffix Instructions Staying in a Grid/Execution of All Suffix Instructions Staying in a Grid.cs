using System.Linq;

namespace AlgoTest.LeetCode.Execution_of_All_Suffix_Instructions_Staying_in_a_Grid;

public class Execution_of_All_Suffix_Instructions_Staying_in_a_Grid
{
    private static int Solve((int row, int col) at, string command, int size, int index) {
        var result = 0;
        
        for (var i = index; i < command.Length; ++i, ++result) {
            var cmd = command[i];

            at = cmd switch
            {
                'L' => (at.row, at.col - 1),
                'R' => (at.row, at.col + 1),
                'U' => (at.row - 1, at.col),
                'D' => (at.row + 1, at.col),
                _ => at
            };

            if (at.col < 0 || at.col >= size || at.row < 0 || at.row >= size)
                return result;
        }
        
        return result;
    }
   
    public int[] ExecuteInstructions(int n, int[] startPos, string s) => Enumerable
        .Range(0, s.Length)
        .Select(i => Solve((startPos[0], startPos[1]), s, n, i))
        .ToArray();
}