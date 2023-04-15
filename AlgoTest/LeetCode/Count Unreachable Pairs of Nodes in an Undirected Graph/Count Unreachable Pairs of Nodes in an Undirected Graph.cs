using System.Collections.Generic;

public class Solution {
    public long CountPairs(int n, int[][] edges) {
        var dsu = new UnionFindSet(n);
        foreach (var edge in edges) dsu.Union(edge[0], edge[1]);
        
        var componentSize = new Dictionary<int, int>();
        for (var i= 0; i<n; i++) {
            var parent = dsu.Find(i);
            componentSize[parent] = componentSize.GetValueOrDefault(parent, 0) + 1;
        }
        
        long numberOfPaths = 0;
        long remainingNodes = n;

        foreach (int size in componentSize.Values) {
            numberOfPaths += size * (remainingNodes - size);
            remainingNodes -= size;
        }

        return numberOfPaths;        
    }

    public class UnionFindSet {
        private int[] parent;

        public UnionFindSet(int size) {
            parent = new int[size];
            for (var i = 0; i < parent.Length; ++i) 
                parent[i] = i;
        }

        public void Union(int x, int y) => parent[Find(x)] = parent[Find(y)];
        
        public int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
    }    
}