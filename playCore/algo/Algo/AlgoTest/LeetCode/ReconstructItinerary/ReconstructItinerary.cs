using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ReconstructItinerary
{
    class ReconstructItinerary
    {
        private IDictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            airportsNum = tickets.Count + 1;
            for (var i = 0; i < tickets.Count; i++)
            {
                if(dic.ContainsKey(tickets[i][0]))
                {
                    dic[tickets[i][0]].Add(tickets[i][1]);
                }
                else
                {
                    dic.Add(tickets[i][0], new List<string>{ tickets[i][1] });
                }
            }

            return FindPath("JFK", new List<string>{"JFK"});

        }

        private int airportsNum;
        private IList<string> FindPath(string key, IList<string> path)
        {
            if (!dic.ContainsKey(key))
            {
                return path.Count == airportsNum ? path : null;
            }

            dic[key].Sort();

            for (var i = 0; i < dic[key].Count; i++)
            {
                var airport = dic[key][i];
                path.Add(airport);
                var foundPath = FindPath(airport, path);
                if (foundPath != null)
                    return foundPath;
                path.RemoveAt(path.Count -1);
            }

            return null;
        }
    }
}
