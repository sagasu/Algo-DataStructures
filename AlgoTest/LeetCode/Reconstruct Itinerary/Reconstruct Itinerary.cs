using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Reconstruct_Itinerary;

public class Reconstruct_Itinerary
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var map = new Dictionary<string, List<string>>();
            
        foreach (var ticket in tickets) {
            if (!map.TryGetValue(ticket[0], out var adj))  {
                adj = new List<string>();
                map.Add(ticket[0], adj);
            }
            
            adj.Add(ticket[1]);
        }
        
        foreach (var adj in map.Values) 
            adj.Sort(Comparer<string>.Create((a, b) => string.Compare(b, a)));
        
        
        var it = new Stack<string>();
        var ans = new Stack<string>();
        it.Push("JFK");
        
        while (it.Count > 0) {
            var src = it.Peek();
            if (!map.TryGetValue(src, out var adj) || adj.Count == 0)  {
                it.Pop();
                ans.Push(src);
            } else {
                var next = adj.Last();
                adj.RemoveAt(adj.Count - 1);
                it.Push(next);
            }
        }
        
        return ans.ToList();
    }
}