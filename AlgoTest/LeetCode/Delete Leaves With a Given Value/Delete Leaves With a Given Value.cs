using System;

namespace AlgoTest.LeetCode.Delete_Leaves_With_a_Given_Value;

public class Delete_Leaves_With_a_Given_Value
{
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        var dummy = new TreeNode(Int32.MaxValue);
        dummy.left = root;

        DFS(dummy, target);

        return dummy.left;
    }

    private void DFS(TreeNode node, int target)
    {
        if (node == null)
            return;

        DFS(node.left, target);
        DFS(node.right, target);

        if (node.left != null && node.left.left == null && node.left.right == null && node.left.val == target)
            node.left = null;

        if (node.right != null && node.right.left == null && node.right.right == null && node.right.val == target)
            node.right = null;
    }
}