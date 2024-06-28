using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Total_Importance_of_Roads;

public class Maximum_Total_Importance_of_Roads
{
    public long MaximumImportance(int n, int[][] roads) {
        var cities = new long[n];
        
        foreach (var road in roads) {
            cities[road[0]] += 1;
            cities[road[1]] += 1;
        }
        
        Array.Sort(cities, (a, b) => -a.CompareTo(b));

        return cities.Select((t, i) => (n - i) * t).Sum();
    }
}