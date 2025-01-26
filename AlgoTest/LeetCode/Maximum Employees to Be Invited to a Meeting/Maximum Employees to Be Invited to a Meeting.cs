using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Employees_to_Be_Invited_to_a_Meeting;

public class Maximum_Employees_to_Be_Invited_to_a_Meeting
{
    private (bool, (int, int)) Dfs(int node, int[] favorite, int[] cyc, bool[] cycVis)
    {
        if (cyc[node] != -1)
            return (false, (node, cyc[node]));
        if (cycVis[node])
            return (true, (node, 1));

        cycVis[node] = true;
        var p = Dfs(favorite[node], favorite, cyc, cycVis);
        
        if (!p.Item1)
        {
            cyc[node] = p.Item2.Item2;
            return p;
        }

        cyc[node] = p.Item2.Item2;

        if (p.Item2.Item1 == node)
            return (false, p.Item2);
        return (true, (p.Item2.Item1, p.Item2.Item2 + 1));
    }

    private int FindLargestCycleLength(int[] favorite)
    {
        var cyc = new int[favorite.Length];
        Array.Fill(cyc, -1);
        var cycVis = new bool[favorite.Length];
        var ans = 0;

        for (int i = 0; i < favorite.Length; i++)
        {
            if (cyc[i] != -1)
                continue;

            var p = Dfs(i, favorite, cyc, cycVis);
            ans = Math.Max(ans, p.Item2.Item2);
        }

        return ans;
    }

    private int FindHeight(List<List<int>> adjList, int node)
    {
        var height = adjList[node].Select(neighbor => FindHeight(adjList, neighbor)).Prepend(0).Max();
        return height + 1;
    }

    private int FindSumOfArms(List<List<int>> adjList, int[] favorite)
    {
        var vis = new bool[favorite.Length];
        var ans = 0;

        for (int i = 0; i < favorite.Length; i++)
        {
            if (vis[i])
                continue;

            if (favorite[favorite[i]] == i)
            {
                vis[i] = true;
                vis[favorite[i]] = true;

                adjList[i].Remove(favorite[i]);
                adjList[favorite[i]].Remove(i);

                ans += FindHeight(adjList, i) + FindHeight(adjList, favorite[i]);
            }
        }

        return ans;
    }

    public int MaximumInvitations(int[] favorite)
    {
        var adjList = new List<List<int>>(favorite.Length);
        for (int i = 0; i < favorite.Length; i++)
        {
            adjList.Add(new List<int>()); // Initialize each list
        }

        for (int i = 0; i < favorite.Length; i++)
            adjList[favorite[i]].Add(i);

        var ans1 = FindLargestCycleLength(favorite);
        var ans2 = FindSumOfArms(adjList, favorite);
        return Math.Max(ans1, ans2);
    }
}