using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Frequency_of_an_Element_After_Performing_Operations_I;

public class Maximum_Frequency_of_an_Element_After_Performing_Operations_I
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        const int MAXN = 200005;
        int[] freq = new int[MAXN];
        int[] prefixSum = new int[MAXN];

        int maxValue = nums.Max();
        int limit = maxValue + k + 2;

        Array.Fill(freq, 0, 0, limit);

        foreach (int num in nums)
        {
            freq[num]++;
        }

        if (numOperations == 0)
        {
            int res = 0;
            for (int i = 0; i < limit; i++)
            {
                res = Math.Max(res, freq[i]);
            }
            return res;
        }
        else
        {
            prefixSum[0] = freq[0];
            for (int i = 1; i < limit; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + freq[i];
            }

            int best = 0;

            for (int target = 0; target <= maxValue; target++)
            {
                int left = target > k ? target - k : 0;
                int right = (target + k) < limit ? target + k : (limit - 1);

                int total = prefixSum[right] - ((left > 0) ? prefixSum[left - 1] : 0);
                int changeable = total - freq[target];

                int possible;
                if (numOperations < changeable)
                {
                    possible = freq[target] + numOperations;
                }
                else
                {
                    possible = freq[target] + changeable;
                }

                if (possible > best)
                {
                    best = possible;
                }
            }

            return best;
        }
    }
}