using System;
using System.Collections.Generic;

public class MaxPointsSolution
{
    public int MaxPoints(int[][] points)
    {
        if (points.Length < 3)
            return points.Length;
        
        var max = 0;
        var map = new Dictionary<long, int>();        
        for (int i = 0; i < points.Length; i++)
        {
            map.Clear();
            var dup = 1;
            for (int j = i + 1; j < points.Length; j++)
            {
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];
                if (dx == 0 && dy == 0)
                    dup++;                    
                else
                {
                    int gcd = getGcd(dx, dy);                    
                    long slope = ((long)(dy / gcd) << 32) + (dx / gcd);
                    if (!map.ContainsKey(slope))
                        map.Add(slope, 0);                    
                    map[slope]++;
                }               
            }
            
            max = Math.Max(max, dup);
            foreach (var val in map.Values)
                max = Math.Max(max, val + dup);
        }
        
        return max;
    }
    
    int getGcd(int a, int b)
    {
        return b == 0 ? a : getGcd(b, a % b);
    }
}