using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Shortest_Uncommon_Substring_in_an_Array;

public class Shortest_Uncommon_Substring_in_an_Array
{
    public string[] ShortestSubstrings(string[] arr)
    {
        var result = new string[arr.Length];
        var visited = new HashSet<string>();

        for (var i = 0; i < arr.Length; i++)
        {
            string res = null;
            var minSubstringLength = int.MaxValue;

            foreach (var subs in GetAllSubstrings(arr[i]))
            {
                if (subs.Length > minSubstringLength)
                    break;

                if (visited.Contains(subs)) continue;

                var ok = arr.Where((t, j) => i != j).All(t => !t.Contains(subs));

                if (ok)
                {
                    minSubstringLength = subs.Length;

                    if (res is null || StringComparer.Ordinal.Compare(res, subs) > 0)
                    {
                        res = subs;
                    }
                }

                visited.Add(subs);
            }

            result[i] = res ?? string.Empty;
        }

        return result;
    }

    private static IEnumerable<string> GetAllSubstrings(string s)
    {
        for (var len = 1; len <= s.Length; len++)
        {
            for (var i = 0; i <= s.Length - len; i++)
            {
                var res = new char[len];
                var index = 0;

                for (int k = i; k <= i + len - 1; k++)
                    res[index++] = s[k];
                

                yield return new string(res);
            }
        }
    }
}