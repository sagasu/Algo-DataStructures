using System.Collections.Generic;

namespace AlgoTest.LeetCode.Word_Break_II;

public class Word_Break_II
{
    public IList<string> WordBreak(string s, IList<string> wordDict) => Helper(s, wordDict, 0, new List<string>[s.Length]);

    private List<string> Helper(string s, IList<string> dict, int i, List<string>[] cache)
    {
        if (cache[i] != null)
            return cache[i];
        
        var cur = new List<string>();
        
        for (var j = i; j < s.Length; j++)
            if (dict.Contains(s.Substring(i, j - i + 1)))
            {
                if (j == s.Length - 1)
                    cur.Add(s.Substring(i, j - i + 1));
                else
                    foreach (var str in Helper(s, dict, j + 1, cache))
                        cur.Add(s.Substring(i, j - i + 1) + " " + str);
            }
        
        cache[i] = cur;
        
        return cache[i];
    }
}