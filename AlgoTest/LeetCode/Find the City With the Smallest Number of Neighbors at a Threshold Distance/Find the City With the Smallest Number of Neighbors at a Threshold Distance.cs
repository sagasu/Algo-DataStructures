using System;

namespace AlgoTest.LeetCode.Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance;

public class Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        var d = new int[n, n];
        for (var i = 0; i < n; i++) 
        for (var j = 0; j < n; j++) 
            d[i, j] = 10001;
        
        foreach(var e in edges) (d[e[0], e[1]], d[e[1], e[0]]) = (e[2], e[2]);
        
        for (var k = 0; k < n; k++) 
        for (var i = 0; i < n; i++) 
        for (var j = 0; j < n; j++) 
            if (i != j) d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
        
        var (min, r) = (n, 0);
        for (int i = 0, count = 0; i < n; i++, count = 0) {
            for (int j = 0; j < n; j++) if (d[i, j] <= distanceThreshold) count++;
            if (count <= min) (min, r) = (count, i) ;
        }
        
        return r;
    }
}