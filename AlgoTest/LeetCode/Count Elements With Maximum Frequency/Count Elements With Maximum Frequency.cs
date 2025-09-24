using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Count_Elements_With_Maximum_Frequency;

public class Count_Elements_With_Maximum_Frequency
{
    public int MaxFrequencyElements(int[] nums) {
        var freq = new Dictionary<int, int>();
        foreach (var n in nums)
            freq[n] = freq.GetValueOrDefault(n, 0) + 1;

        int maxFreq = freq.Values.Max();
        return freq.Values.Where(v => v == maxFreq).Sum();
    }
}