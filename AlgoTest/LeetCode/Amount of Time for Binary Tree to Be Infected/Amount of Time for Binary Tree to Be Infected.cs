using System.Collections.Generic;

namespace AlgoTest.LeetCode.Amount_of_Time_for_Binary_Tree_to_Be_Infected;

public class Amount_of_Time_for_Binary_Tree_to_Be_Infected
{
    public int AmountOfTime(TreeNode root, int start) {
        var g = new Dictionary<int, List<int>>();
        buildGraph(root, g);
        
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);
        var res = 0;
        while(queue.Count > 0){
            var size = queue.Count;
            for(var i = 0; i < size; i++){
                var curr = queue.Dequeue();
                
                foreach(var next in g[curr]){
                    if(!visited.Contains(next)){
                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                }
            }
            
            res++;
        }
        return res-1;
    }
    
    private void buildGraph(TreeNode root, Dictionary<int, List<int>> g){
        if(!g.ContainsKey(root.val))
            g.Add(root.val, new List<int>());
        
        if(root.left != null && !g.ContainsKey(root.left.val)){
            g.Add(root.left.val, new List<int>());
            g[root.val].Add(root.left.val);
            g[root.left.val].Add(root.val);
            buildGraph(root.left, g);
        }
        
        if(root.right != null && !g.ContainsKey(root.right.val)){
            g.Add(root.right.val, new List<int>());
            g[root.val].Add(root.right.val);
            g[root.right.val].Add(root.val);
            buildGraph(root.right, g);
        }
    }
}