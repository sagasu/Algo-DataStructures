using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Covered_Buildings;

public class Count_Covered_Buildings
{
    public int CountCoveredBuildings(int n, int[][] buildings) 
    {
        var rowMin = new Dictionary<int, int>();
        var rowMax = new Dictionary<int, int>();
        
        var colMin = new Dictionary<int, int>();
        var colMax = new Dictionary<int, int>();

        foreach (var b in buildings) 
        {
            int x = b[0], y = b[1];

            if (!rowMin.ContainsKey(x)) 
            {
                rowMin[x] = rowMax[x] = y;
            } 
            else 
            {
                rowMin[x] = Math.Min(rowMin[x], y);
                rowMax[x] = Math.Max(rowMax[x], y);
            }

            if (!colMin.ContainsKey(y)) 
            {
                colMin[y] = colMax[y] = x;
            } 
            else 
            {
                colMin[y] = Math.Min(colMin[y], x);
                colMax[y] = Math.Max(colMax[y], x);
            }
        }

        int covered = 0;
        foreach (var b in buildings) 
        {
            int x = b[0], y = b[1];

            var hasLeft  = rowMin[x] < y;
            var hasRight = rowMax[x] > y;
            bool hasUp    = colMin[y] < x;
            bool hasDown  = colMax[y] > x;

            if (hasLeft && hasRight && hasUp && hasDown)
                covered++;
        }

        return covered;
    }
}