namespace AlgoTest.LeetCode.Evaluate_Boolean_Binary_Tree;

public class Evaluate_Boolean_Binary_Tree
{
    public bool EvaluateTree(TreeNode node) => node.val switch
    {
        0 => false,
        1 => true,
        2 => EvaluateTree(node.left) || EvaluateTree(node.right),
        3 => EvaluateTree(node.left) && EvaluateTree(node.right),
    };
}