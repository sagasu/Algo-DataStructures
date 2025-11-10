using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Convert_All_Elements_to_Zero;

public class Minimum_Operations_to_Convert_All_Elements_to_Zero
{
    public int MinOperations(int[] nums) {
        var s = new List<int>();
        int res = 0;
        foreach (int a in nums) {
            while (s.Count > 0 && s[s.Count - 1] > a) s.RemoveAt(s.Count - 1);
            if (a == 0)
                continue;
            if (s.Count == 0 || s[s.Count - 1] < a) {
                res++;
                s.Add(a);
            }
        }
        return res;
    }
}