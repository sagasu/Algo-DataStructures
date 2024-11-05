using System.Linq;

namespace AlgoTest.LeetCode.inimum_Number_of_Changes_to_Make_Binary_String_Beautiful;

public class inimum_Number_of_Changes_to_Make_Binary_String_Beautiful
{
    public int MinChanges(string s) => s.Chunk(2).Sum(x => x[0] ^ x[1]);
}