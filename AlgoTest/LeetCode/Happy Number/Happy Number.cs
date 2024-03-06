using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Happy_Number;

public class Happy_Number
{
    public bool IsHappy(int n) {
        var set = new HashSet<int>();
        while (true) {
            if (set.Contains(n)) return false;
            set.Add(n);
            n = SquareSum(Digits(n));
            if (n == 1) return true;
        }
        
        IEnumerable<int> Digits(int i) => i.ToString().ToCharArray().Select(c => c - '0').ToArray();
        int SquareSum(IEnumerable<int> digits) => digits.Select(d => d * d).Sum();
    }
}