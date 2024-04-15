namespace AlgoTest.LeetCode.Smallest_String_Starting_From_Leaf;

public class Smallest_String_Starting_From_Leaf
{
    private string result = null;
    public string SmallestFromLeaf(TreeNode root) {
        FindResult(root);
        return result;
    }

    private void FindResult(TreeNode root, string temp = ""){
        if(root == null)
            return;

        var newTemp = (char)(root.val + 97) + temp;
        var isLeaf = root.left == null && root.right == null;

        if(isLeaf){
            if(result == null || result.CompareTo(newTemp) > 0)
                result = newTemp;
            return;
        }else {
            FindResult(root.left, newTemp);
            FindResult(root.right, newTemp);
        }
    }
}