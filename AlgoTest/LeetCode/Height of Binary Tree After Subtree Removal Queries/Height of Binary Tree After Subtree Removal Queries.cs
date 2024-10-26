using System;
using System.Linq;

namespace AlgoTest.LeetCode.Height_of_Binary_Tree_After_Subtree_Removal_Queries;

public class Height_of_Binary_Tree_After_Subtree_Removal_Queries
{
    private readonly int[] _seen = new int[100001];
    private int _maxHeight;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        _maxHeight = 0;
        Dfs(root, 0);

        _maxHeight = 0;
        Dfs(root, 0);

        return queries.Select(q => _seen[q]).ToArray();
    }

    private void Dfs(TreeNode root, int h)
    {
        if (root == null)
            return;
        
        _seen[root.val] = Math.Max(_seen[root.val], _maxHeight);
        _maxHeight = Math.Max(_maxHeight, h);
        
        Dfs(root.left, h + 1);
        Dfs(root.right, h + 1);
        
        (root.right, root.left) = (root.left, root.right);
    }
}