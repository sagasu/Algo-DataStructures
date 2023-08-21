using System.Linq;

namespace AlgoTest.LeetCode.Repeated_Substring_Pattern;

public class Repeated_Substring_Pattern
{
    public bool RepeatedSubstringPattern(string s) {
        return Enumerable
            .Range(1, s.Length / 2)
            .Any(l => s.Length % l == 0 &&
                      Enumerable
                          .Range(0, s.Length)
                          .All(i => s[i] == s[i % l])
            );
    }
}