using System;
using System.Collections.Generic;

public class ClosestMeetingNodeSolution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        var dict1 = new Dictionary<int, int>();
        var dict2 = new Dictionary<int, int>();
        int cur = node1, counter = 0, min = int.MaxValue, result = int.MaxValue;

        while (cur != -1) {
            if (dict1.ContainsKey(cur)) break;
            
            dict1.Add(cur, counter++);
            cur = edges[cur];
        }

        cur = node2;
        counter = 0;

        while (cur != -1) {
            if (dict2.ContainsKey(cur)) break;

            dict2.Add(cur, counter++);
            cur = edges[cur];
        }

        foreach (var key in dict1.Keys) {
            if (dict2.ContainsKey(key)) {
                var tempMin = Math.Max(dict1[key], dict2[key]);
                
                if (tempMin <= min) {
                    result = (tempMin < min) ? key : Math.Min(result, key);
                    min = tempMin;
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}