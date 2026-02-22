using System.Collections.Generic;
using System.Numerics;

namespace AlgoTest.LeetCode.Prime_Number_of_Set_Bits_in_Binary_Representation;

public class Prime_Number_of_Set_Bits_in_Binary_Representation
{
    public int CountPrimeSetBits(int left, int right) {
        HashSet<int> primes = new HashSet<int>{2,3,5,7,11,13,17,19};
        int result = 0;

        for (int i = left; i <= right; i++) {
            int bitCount = BitOperations.PopCount((uint)i);
            if (primes.Contains(bitCount))
                result++;
        }

        return result;
    }
}