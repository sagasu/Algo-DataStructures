using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_Fish_in_a_Grid;

public class Maximum_Number_of_Fish_in_a_Grid
{
    private int[] parents;
    private int[] rank;
    
    public int FindMaxFish(int[][] grid) {
        parents = new int[100];
        rank = new int[100];
        
        for (int i = 0; i < 100; i++)
            parents[i] = i;
        
        int[] dir = { 1, 0, -1, 0, 1 };
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == 0)
                    parents[i * 10 + j] = -1;
                else {
                    var x = i * 10 + j;
                    for (int k = 0; k < 4; k++) {
                        int newX = i + dir[k], nexY = j + dir[k + 1];
                        if (newX < 0 || newX >= grid.Length || nexY < 0 || nexY >= grid[0].Length || grid[newX][nexY] == 0) continue;
                        var y = newX * 10 + nexY;
                        Union(x, y);
                    }
                }
            }
        }
        var groups = new Dictionary<int, int>();
        var res = 0;
        for (int i = 0; i < parents.Length; i++) {
            if (parents[i] == -1) continue;
            var parent = Find(parents[i]);
            if (!groups.ContainsKey(parent))
                groups[parent] = 0;
            int x = i / 10, y = i % 10;
            if (x >= grid.Length || y >= grid[0].Length) continue;
            groups[parent] += grid[x][y];
            res = Math.Max(res, groups[parent]);
        }
        return res;
    }
    
    private int Find(int x) {
        if (parents[x] != x)
            parents[x] = Find(parents[x]);
        return parents[x];
    }

    private void Union(int x, int y) {
        int rootX = Find(x), rootY = Find(y);
        if (rootX == rootY) return;
        if (rank[rootX] < rank[rootY])
            parents[rootX] = rootY;
        else {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
    }
}