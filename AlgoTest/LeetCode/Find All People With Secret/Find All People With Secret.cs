using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_All_People_With_Secret;

public class Find_All_People_With_Secret
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        var adj = new Dictionary<int,List<KeyValuePair<int,int>>>();
        var ans = new List<int>();
        foreach( var meeting in meetings)
        {
            var u = meeting[0];
            var v = meeting[1];
            var t = meeting[2];
            
            if(!adj.ContainsKey(u))
                adj[u] = new List<KeyValuePair<int,int>>();
            
            adj[u].Add(new KeyValuePair<int,int>(v,t));
            
            if(!adj.ContainsKey(v))
                adj[v] = new List<KeyValuePair<int,int>>();
            
            adj[v].Add(new KeyValuePair<int,int>(u,t));
        }
        
        var pq = new PriorityQueue<int,int>();
        pq.Enqueue(0,0);
        pq.Enqueue(firstPerson,0);
        var visited = new bool[n];
        while(pq.Count >0)
        {
            int elem;
            int time;
            pq.TryDequeue(out elem,out time);
            
            if(visited[elem] == false)
                ans.Add(elem);
            visited[elem] = true;
            if(adj.ContainsKey(elem))       
            {
                var neighbours = adj[elem];
                foreach( var neighbour in neighbours)
                {
                    var elem1 = neighbour.Key;
                    var time1 = neighbour.Value;
                    if(time1 >= time && visited[elem1] == false)
                        pq.Enqueue(elem1, time1);
                } 
            }
        }
        return ans;
    }
}