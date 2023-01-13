public class Solution {
    public int LongestPath(int[] parent, string s) {
        int n = parent.Length;
        int[] childrenCount = new int[n];
        
        for (int node = 1; node < n; node++) {
            childrenCount[parent[node]]++;
        }

        var q = new Queue<int>();
        int longestPath = 1;
        int[][] longestChains = new int[n][];
        for (int index = 0; index < longestChains.Length; ++index) {
            longestChains[index] = new int[2];
        }

        for (int node = 1; node < n; node++) {
            if (childrenCount[node] == 0) {
                longestChains[node][0] = 1;
                q.Enqueue(node);
            }
        }

        while (q.Count > 0) {
            int currentNode = q.Dequeue();
            int par = parent[currentNode];
            int longestChainStartingFromCurrNode = longestChains[currentNode][0];
            if (s[currentNode] != s[par]) {
                if (longestChainStartingFromCurrNode > longestChains[par][0]) {
                    longestChains[par][1] = longestChains[par][0];
                    longestChains[par][0] = longestChainStartingFromCurrNode;
                } else if (longestChainStartingFromCurrNode > longestChains[par][1]) {
                    longestChains[par][1] = longestChainStartingFromCurrNode;
                }
            }

            longestPath = Math.Max(longestPath, longestChains[par][0] + longestChains[par][1] + 1);
            childrenCount[par]--;

            if (childrenCount[par] == 0 && par != 0) {
                longestChains[par][0]++;
                q.Enqueue(par);
            }
        }

        return longestPath;        
    }
}