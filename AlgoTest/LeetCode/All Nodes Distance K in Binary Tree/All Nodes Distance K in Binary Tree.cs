
using System.Collections.Generic;
using AlgoTest.LeetCode;

public class AllNodesDistanceKinBinaryTree {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        List<int> res = new List<int>();
        List<int>[] g = new List<int>[501];
        for(int i = 0; i < 501; i++) g[i] = new List<int>();
        buildGraph(root, g);
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(target.val);
        visited.Add(target.val);
        while(queue.Count > 0 && k >= 0){
            int size = queue.Count;
            for(int i = 0; i < size; i++){
                int curr = queue.Dequeue();
                if(k == 0) res.Add(curr);
                else 
                    foreach(int next in g[curr])
                        if(visited.Add(next))
                            queue.Enqueue(next);
            }
            k--;
        }
        return res;
    }

    private void buildGraph(TreeNode root, List<int>[] g){
        if(root.left != null){
            g[root.val].Add(root.left.val);
            g[root.left.val].Add(root.val);
            buildGraph(root.left, g);
        }
        if(root.right != null){
            g[root.val].Add(root.right.val);
            g[root.right.val].Add(root.val);
            buildGraph(root.right, g);
        }
    }
}