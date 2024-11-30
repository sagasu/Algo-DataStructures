using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Shortest_Distance_After_Road_Addition_Queries_I;

public class Shortest_Distance_After_Road_Addition_Queries_I
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        var paths = new List<int>[n];
        var shortest = new int[n];
        for (int i = 0; i < n; ++i) {
            paths[i] = new List<int>();
            if (i + 1 < n) {
                paths[i].Add(i + 1);
            }
            shortest[i] = i;
        }
        var answer = new int[queries.Length];
        for (int q = 0; q < queries.Length; ++q) {
            paths[queries[q][0]].Add(queries[q][1]);
            for (int j = queries[q][0]; j < n; ++j) {
                foreach (int next in paths[j]) {
                    shortest[next] = Math.Min(shortest[next], shortest[j] + 1);
                }
            }
            answer[q] = shortest[n - 1];
        }
        return answer;
    }
}