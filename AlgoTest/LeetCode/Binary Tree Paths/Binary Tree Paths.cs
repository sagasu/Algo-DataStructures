using System.Collections.Generic;

namespace AlgoTest.LeetCode.Binary_Tree_Paths;

public class Binary_Tree_Paths
{
    public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();
        DFS(root, new List<string>(), result);
        return result;
    }

    private void DFS(TreeNode root, IList<string> oneResult, IList<string> result) {
        if (root == null) return;
        oneResult.Add($"{root.val}");
        if (root.left == null && root.right == null) {
            result.Add(string.Join("->", oneResult));
        } else {
            DFS(root.left, oneResult, result);
            DFS(root.right, oneResult, result);
        }
        oneResult.RemoveAt(oneResult.Count - 1);
    }
}