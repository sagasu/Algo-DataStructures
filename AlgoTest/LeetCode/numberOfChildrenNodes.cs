using System;
using System.Collections.Generic;

public class NumberOfChildrenNodes
{
    private readonly Dictionary<int, List<int>> _graph = new();
    private int _seats;
    private long _result;

    public long MinimumFuelCost(int[][] roads, int seats)
    {
        if (roads.Length == 0)
        {
            return 0;
        }
        
        _seats = seats;
        foreach (var edge in roads)
        {
            _graph[edge[0]] = _graph.GetValueOrDefault(edge[0], new List<int>());
            _graph[edge[0]].Add(edge[1]);
            _graph[edge[1]] = _graph.GetValueOrDefault(edge[1], new List<int>());
            _graph[edge[1]].Add(edge[0]);
        }

        dfs(0, -1);

        return _result;
    }

    private long dfs(int node, int parentNode)
    {
        var numberOfChildrenNodes = 1L;
        
        foreach (var childNode in _graph[node])
        {
            if (childNode != parentNode)
            {
                numberOfChildrenNodes += dfs(childNode, node);
            }
        }

        if (node != 0)
        {
            _result += (long)Math.Ceiling((double)numberOfChildrenNodes / _seats);
        }

        return numberOfChildrenNodes;
    }
}
