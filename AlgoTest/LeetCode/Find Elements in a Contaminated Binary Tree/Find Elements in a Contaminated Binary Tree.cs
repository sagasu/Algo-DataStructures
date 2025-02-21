using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_Elements_in_a_Contaminated_Binary_Tree;

public class FindElements
{
    private readonly HashSet<int> _hashSet = [];

    public FindElements(TreeNode root)
    {
        dfs(root, 0);
    }

    private void dfs(TreeNode? node, int val)
    {
        if (node == null) return;

        _hashSet.Add(val);
        node.val = val;

        dfs(node.left, 2 * val + 1);
        dfs(node.right, 2 * val + 2);
    }

    public bool Find(int target)
    {
        return _hashSet.Contains(target);
    }
}