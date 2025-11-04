using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_X_Sum_of_All_K_Long_Subarrays_I;

public class Find_X_Sum_of_All_K_Long_Subarrays_I
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        List<int> result = new List<int>();

        Dictionary<int, int> freq = new Dictionary<int, int>();

        for (int i = 0; i < k; i++)
        {
            if (!freq.ContainsKey(nums[i]))
                freq[nums[i]] = 0;

            freq[nums[i]]++;
        }

        result.Add(ComputeXSum(freq, x));

        for (int i = k; i < nums.Length; i++)
        {
            int outNum = nums[i - k];
            int inNum = nums[i];

            freq[outNum]--;
            if (freq[outNum] == 0)
                freq.Remove(outNum);

            if (!freq.ContainsKey(inNum))
                freq[inNum] = 0;
            freq[inNum]++;

            result.Add(ComputeXSum(freq, x));
        }

        return result.ToArray();
    }

    private int ComputeXSum(Dictionary<int, int> freq, int x)
    {
        List<KeyValuePair<int, int>> items = freq.ToList();

        items.Sort((a, b) =>
        {
            if (b.Value != a.Value)
                return b.Value.CompareTo(a.Value);
            else
                return b.Key.CompareTo(a.Key);
        });

        int sum = 0;
        int count = 0;

        foreach (var pair in items)
        {
            if (count == x) break;
            sum += pair.Key * pair.Value;
            count++;
        }

        return sum;
    }
}