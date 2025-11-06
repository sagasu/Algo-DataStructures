using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Power_Grid_Maintenance;

public class SolutionDSU {
     public class DSU
 {
     private int[] parent;

     public DSU(int size)
     {
         parent = new int[size];
         for (int i = 0; i < size; i++)
         {
             parent[i] = i;
         }
     }

     public int Find(int x)
     {
         return parent[x] == x ? x : (parent[x] = Find(parent[x]));
     }

     public void Join(int u, int v)
     {
         parent[Find(v)] = Find(u);
     }
 }
 public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
 {
     DSU dsu = new DSU(c + 1);

     foreach (var p in connections)
     {
         dsu.Join(p[0], p[1]);
     }

     bool[] online = new bool[c + 1];
     int[] offlineCounts = new int[c + 1];
     Array.Fill(online, true);

     Dictionary<int, int> minimumOnlineStations = new Dictionary<int, int>();
     foreach (var q in queries)
     {
         int op = q[0], x = q[1];
         if (op == 2)
         {
             online[x] = false;
             offlineCounts[x]++;
         }
     }

     for (int i = 1; i <= c; i++)
     {
         int root = dsu.Find(i);
         if (!minimumOnlineStations.ContainsKey(root))
         {
             minimumOnlineStations[root] = -1;
         }

         int station = minimumOnlineStations[root];
         if (online[i])
         {
             if (station == -1 || station > i)
             {
                 minimumOnlineStations[root] = i;
             }
         }
     }

     List<int> ans = new List<int>();
     for (int i = queries.Length - 1; i >= 0; i--)
     {
         int op = queries[i][0], x = queries[i][1];
         int root = dsu.Find(x);
         int station = minimumOnlineStations[root];

         if (op == 1)
         {
             if (online[x])
             {
                 ans.Add(x);
             }
             else
             {
                 ans.Add(station);
             }
         }

         if (op == 2)
         {
             if (offlineCounts[x] > 1)
             {
                 offlineCounts[x]--;
             }
             else
             {
                 online[x] = true;
                 if (station == -1 || station > x)
                 {
                     minimumOnlineStations[root] = x;
                 }
             }
         }
     }

     ans.Reverse();
     return ans.ToArray();
 }
}