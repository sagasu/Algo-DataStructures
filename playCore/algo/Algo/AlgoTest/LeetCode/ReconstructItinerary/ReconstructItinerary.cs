using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ReconstructItinerary
{
    [TestClass]
    public class ReconstructItinerary
    {
        [TestMethod]
        public void Test()
        {
            //var t = new List<IList<string>>{new List<string> {"JFK", "SFO"}, new List<string> {"JFK", "ATL"},new List<string>
            //    {"SFO", "ATL"},new List<string> {"ATL", "JFK"},new List<string> {"ATL", "SFO"}
            //};
            //var exp = new List<string> {"JFK", "ATL", "JFK", "SFO", "ATL", "SFO"};
            //
            var t = new List<IList<string>>
            {
                new List<string> {"EZE", "AXA"}, new List<string> {"TIA", "ANU"}, new List<string> {"ANU", "JFK"},
                new List<string> {"JFK", "ANU"}, new List<string> {"ANU", "EZE"}, new List<string> {"TIA", "ANU"},
                new List<string> {"AXA", "TIA"}, new List<string> {"TIA", "JFK"}, new List<string> {"ANU", "TIA"},
                new List<string> {"JFK", "TIA"}
            };
            Assert.AreEqual(new List<string>(), FindItinerary(t));
        }

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

            foreach (var key in dic.Keys)
            {
                dic[key].Sort();
            }

            return FindPath("JFK", new List<string>{"JFK"}, new List<string>());

        }

        private int airportsNum;
        private IList<string> FindPath(string key, IList<string> path, IList<string> visited)
        {
            if (path.Count == airportsNum)
            {
                return path;
            }

            if (!dic.ContainsKey(key))
                return null;

            for (var i = 0; i < dic[key].Count; i++)
            {
                var airport = dic[key][i];
                var hash = $"{key},{i}";
                if (visited.Contains(hash))
                    continue;
                visited.Add(hash);
                
                path.Add(airport);
                var foundPath = FindPath(airport, path,visited);
                if (foundPath != null)
                    return foundPath;
                path.RemoveAt(path.Count -1);
                visited.RemoveAt(visited.Count-1);
            }

            return null;
        }
    }
}
