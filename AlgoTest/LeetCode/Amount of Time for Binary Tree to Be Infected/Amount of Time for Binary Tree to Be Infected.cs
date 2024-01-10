using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Amount_of_Time_for_Binary_Tree_to_Be_Infected;

public class Amount_of_Time_for_Binary_Tree_to_Be_Infected
{
    public int AmountOfTime(TreeNode root, int start)
    {
        var adjDict = GetAdjacencyDictionary(root);
        var infected = new HashSet<int>();
        var toInfect = new Queue<int>();
        var time = -1;

        toInfect.Enqueue(start);

        while (toInfect.Any())
        {
            time += 1;
            var count = toInfect.Count;
            for (var i = 0; i < count; i++)
            {
                var curr = toInfect.Dequeue();
                if (infected.Add(curr))
                    foreach (var next in adjDict[curr])
                        if (!infected.Contains(next))
                            toInfect.Enqueue(next);
            }
        }

        return time;
    }

    private Dictionary<int, List<int>> GetAdjacencyDictionary(TreeNode root)
    {
        var adjDict = new Dictionary<int, List<int>>();
        adjDict[root.val] = new();
        TraverseDfs(root.left, root);
        TraverseDfs(root.right, root);
        return adjDict;

        void TraverseDfs(TreeNode node, TreeNode parent)
        {
            if (node != null)
            {
                adjDict[node.val] = new();
                adjDict[node.val].Add(parent.val);
                adjDict[parent.val].Add(node.val);
                TraverseDfs(node.left, node);
                TraverseDfs(node.right, node);
            }
        }
    }
}