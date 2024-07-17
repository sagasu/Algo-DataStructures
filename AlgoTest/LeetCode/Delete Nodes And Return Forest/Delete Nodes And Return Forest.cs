using System.Collections.Generic;

namespace AlgoTest.LeetCode.Delete_Nodes_And_Return_Forest;

public class Delete_Nodes_And_Return_Forest
{
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var h = new HashSet<int>(to_delete);        
        var ret = new List<TreeNode>();
        root = Del(root, h, ret);
        if(root!=null)
            ret.Add(root);
        return ret;
    }
    
    TreeNode Del(TreeNode root, HashSet<int> h, List<TreeNode> ret){
        if(root==null) return null;
            
        root.left = Del(root.left, h, ret);
        root.right = Del(root.right, h, ret);
        
        if(h.Contains(root.val)){
            if(root.left!=null) ret.Add(root.left);
            if(root.right!=null) ret.Add(root.right);
            return null;
        }
        
        return root;
    }
}