using AlgoTest.LeetCode;

public class Binary_Tree_Pruning
{
    public TreeNode PruneTree(TreeNode root) {
        if (root == null) return null;
        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);
        if(root.left == null && root.right == null && root.val == 0) return null;
        return root;
    }
}
