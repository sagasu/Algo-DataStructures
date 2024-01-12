using System.Linq;

namespace AlgoTest.LeetCode.Can_Convert_String_in_K_Moves;

public class Can_Convert_String_in_K_Moves
{
    public bool CanConvertString(string s, string t, int k) 
        => s.Length == t.Length && 
           s.Zip(t, (c1, c2) => (26 + c2 - c1) % 26)
               .GroupBy(x => x)
               .All(g => g.Key == 0 || (g.Count() - 1) * 26 + g.Key <= k);
}