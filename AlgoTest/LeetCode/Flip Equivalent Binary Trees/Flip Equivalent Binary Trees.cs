namespace AlgoTest.LeetCode.Flip_Equivalent_Binary_Trees;

public class Flip_Equivalent_Binary_Trees
{
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null && null == root2) 
            return true;
        
        
        if (root1?.val!=root2?.val)
            return false;
        
        return (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left)) ||
               (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) ;
    }
}