using System.Collections.Generic;

namespace AlgoTest.LeetCode.Balance_a_Binary_Search_Tree;

public class Balance_a_Binary_Search_Tree
{
    List<TreeNode> nodes = new();
    public TreeNode BalanceBST(TreeNode root) 
    {
        Traverse(root);
        nodes.Sort((x, y) => x.val.CompareTo(y.val));  
        return MakeBBST(nodes, 0, nodes.Count - 1);
    }
    
    private TreeNode MakeBBST(List<TreeNode> nodes, int start, int end)
    {
        if(start > end) return null;
        var mid = (start + end) / 2;
        var root = nodes[mid];
        root.left = MakeBBST(nodes, start, mid - 1);
        root.right = MakeBBST(nodes, mid + 1, end);
        return root;
    }
    
    private void Traverse(TreeNode root)
    {
        if(root == null) return;
        nodes.Add(root);
        Traverse(root.left);
        Traverse(root.right);
        root.left = null;
        root.right = null;
    }
}