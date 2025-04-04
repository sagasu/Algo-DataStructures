namespace AlgoTest.LeetCode.Lowest_Common_Ancestor_of_Deepest_Leaves;

public class Lowest_Common_Ancestor_of_Deepest_Leaves
{
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return FindLCA(root).Item1; // Return the LCA from the tuple
    }

    private (TreeNode, int) FindLCA(TreeNode node) {
        if (node == null) {
            return (null, 0); // Return null and depth 0 for null nodes
        }

        // Recursively find the LCA and depth for left and right subtrees
        var left = FindLCA(node.left);
        var right = FindLCA(node.right);

        // If both left and right are at the same depth, current node is LCA
        if (left.Item2 == right.Item2) {
            return (node, left.Item2 + 1); // Return current node and depth
        }

        // If left is deeper, return left LCA and its depth
        if (left.Item2 > right.Item2) {
            return (left.Item1, left.Item2 + 1);
        }

        // If right is deeper, return right LCA and its depth
        return (right.Item1, right.Item2 + 1);
    }
}