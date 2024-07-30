using System;

namespace AlgoTest.LeetCode.Minimum_Deletions_to_Make_String_Balanced;

public class Minimum_Deletions_to_Make_String_Balanced
{
    public int MinimumDeletions(string s)
    {
        if (s.Length <= 2) { return 0; }

        int[] ar = new int[s.Length];
        for (int i = s.Length - 2; i >= 0; i--)
        {
            int count = ar[i + 1];
            if (s[i + 1] == 'a') { count++; }
            ar[i] = count;
        }

        if (ar[0] == 0) { return 0; }

        int result = Int32.MaxValue;
        int bl = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int a = ar[i];
            int total = a + bl;
            if (total < result) { result = total; }
            if (s[i] == 'b') { bl++; }
        }

        if (bl == 0) { result = 0; }
        return result;
    }
}