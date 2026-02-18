using System.Collections.Generic;

namespace AlgoTest.LeetCode.Binary_Number_with_Alternating_Bits;

public class Binary_Number_with_Alternating_Bits
{
    public bool HasAlternatingBits(int n) {
        var bits = new List<int>();
        while (n != 0) {
            bits.Add(n & 1);
            n >>= 1;
        }
        for (int i = 0; i < bits.Count - 1; i++) {
            if (bits[i] == bits[i + 1])
                return false;
        }
        return true;
    }
}