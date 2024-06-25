namespace AlgoTest.LeetCode.Binary_Search_Tree_to_Greater_Sum_Tree;

public class Binary_Search_Tree_to_Greater_Sum_Tree
{
    private int _max = 0;

    public TreeNode BstToGst(TreeNode node)
    {
        if (node == null)
            return null;

        TreeNode rNode = BstToGst(node.right),
            gstNode = new TreeNode(node.val + _max);

        if (gstNode.val > _max)
            _max = gstNode.val;

        var lNode = BstToGst(node.left);

        gstNode.left = lNode;
        gstNode.right = rNode;

        return gstNode;
    }
}