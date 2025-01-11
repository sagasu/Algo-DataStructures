using System.Linq;
using System.Numerics;

namespace AlgoTest.LeetCode.Construct_K_Palindrome_Strings;

public class Construct_K_Palindrome_Strings
{
    public bool CanConstruct(string s, int k) {
        if (s.Length < k) return false;
        if (s.Length == k) return true;

        int oddCount = s.ToCharArray().Aggregate(0, (current, chr) => current ^ 1 << (chr - 'a'));
        
        uint count = (uint)oddCount;
        return BitOperations.PopCount(count) <= k;
    }
}