using System.Collections.Generic;

namespace AlgoTest.LeetCode.Cousins_in_Binary_Tree_II;

public class Cousins_in_Binary_Tree_II
{
    List<int> levelSum;
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        levelSum = new List<int>();
        DfsSum(root, 0);
        DfsValue(root, 0);
        root.val = 0;
        return root;
    }

    private void DfsSum(TreeNode root, int level)
    {
        if (root == null)
            return;
        if (levelSum.Count <= level)
            levelSum.Add(root.val);
        else
            levelSum[level] += root.val;

        DfsSum(root.left, level + 1);
        DfsSum(root.right, level + 1);
    }
    private void DfsValue(TreeNode root, int level)
    {
        if (root == null)
            return;
        int childSum = 0;
        if (root.left!= null)
            childSum += root.left.val;
        if (root.right != null)
            childSum += root.right.val;

        if (root.left != null)
            root.left.val = levelSum[level + 1] - childSum;
        if (root.right != null)
            root.right.val = levelSum[level + 1] - childSum;

        DfsValue(root.left, level + 1);
        DfsValue(root.right, level + 1);
    }
}