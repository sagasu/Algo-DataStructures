using System;
using System.Collections.Generic;

public class SmallestSufficientTeams {
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
        var dict = new Dictionary<string, int>();
        int n = req_skills.Length, max = (int) Math.Pow(2, n);
        for(int i = 0; i < n; i++) dict.Add(req_skills[i], i);
        var p = new List<int>();
        for(int i = 0; i < people.Count; i++)
        {
            int num = 0;
            foreach(var str in people[i])
                if(dict.ContainsKey(str))
                    num |= 1 << dict[str];
            p.Add(num);
        }

        var dp = new List<int>[max];
        dp[0] = new List<int>();
        for(int i = 0; i < max; i++)
        {
            for(int j = 0; j < p.Count; j++)
            {
                int newIndex = i | p[j];
                if(dp[i] != null && (dp[newIndex] == null || dp[newIndex].Count > dp[i].Count + 1))
                {
                    var l = new List<int>(dp[i]);
                    l.Add(j);
                    dp[newIndex] = l;
                }
            }
        }
        
        return dp[max-1].ToArray();
    }
}