using System;

namespace AlgoTest.LeetCode.Defuse_the_Bomb;

public class Defuse_the_Bomb
{
    public int[] Decrypt(int[] code, int k) {
        var result = new int[code.Length];

        for (var i = 0; i < code.Length; i++)
        for (var j = k; j != 0; j -= Math.Sign(k))
            result[i] += code[(i + j + code.Length) % code.Length];

        return result;
    }
}