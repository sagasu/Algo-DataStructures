using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Count_Mentions_Per_User;

public class Count_Mentions_Per_User
{
    public int[] CountMentions(int n, IList<IList<string>> events) {
        var len = events.Count;
        for(int i = 0; i < len; i++) 
        {
            var e = events[i];
            if(e[0] == "OFFLINE")
            {
                events.Add(new List<string>() {"ONLINE", (int.Parse(e[1]) + 60).ToString(), e[2]} );
            }
        }
        
        var sorted  = events
            .OrderBy(e => int.Parse(e[1]))
            .ThenByDescending(e => e[0])
            .ToList();

        var response = new int[n];
        var isOffline = new bool[n];
        foreach(var e in sorted)
        {
            if(e[0] == "OFFLINE")
                isOffline[int.Parse(e[2])] = true;
            else if(e[0] == "ONLINE")
                isOffline[int.Parse(e[2])] = false;
            else 
            {
                if(e[2][0] == 'i')
                {
                    var ids = e[2].Split(' ');
                    foreach(var id in ids)
                    {
                        response[int.Parse(id.Replace("id", ""))]++;
                    }
                }
                else if(e[2][0] == 'A')
                {
                    for(int i = 0; i < response.Length; i++)
                        response[i]++;
                }
                else
                {
                    for(int i = 0; i < response.Length; i++)
                        if(!isOffline[i])
                            response[i]++;
                }
            }
        }

        return response;
    }
}