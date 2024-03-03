using System;

namespace AlgoTest.LeetCode.H_Index;

public class H_Index
{
    public int HIndex(int[] citations) {
        Array.Sort(citations);

        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] < citations.Length - i)
                continue;

            for (var hIndex = citations[i]; hIndex >= 0; hIndex--)
                if (hIndex <= citations.Length - i)
                    return hIndex;
        }

        return 0;
    }
}