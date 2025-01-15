using System.Numerics;

namespace AlgoTest.LeetCode.Minimize_XOR;

public class Minimize_XOR
{
    public int MinimizeXor(int num1, int num2)
    {
        var m = BitOperations.PopCount((uint)num1);
        var n = BitOperations.PopCount((uint)num2);
        for (var i = 0; i < n - m; i++)
            num1 |= num1 + 1;
        for (var i = 0; i < m - n; i++)
            num1 &= num1 - 1;
        return num1;
    }
}