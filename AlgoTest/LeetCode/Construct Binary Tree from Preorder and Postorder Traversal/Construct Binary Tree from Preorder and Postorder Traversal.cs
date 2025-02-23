namespace AlgoTest.LeetCode.Construct_Binary_Tree_from_Preorder_and_Postorder_Traversal;

public class Construct_Binary_Tree_from_Preorder_and_Postorder_Traversal
{
    private int _preorderPosition;
    private int _postorderPosition;

    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        var result = new TreeNode();
        StartDFS(result, preorder, postorder);
        return result;
    }

    public void StartDFS(TreeNode node, int[] preorder, int[] postorder) 
    {
        if (_preorderPosition == preorder.Length) 
        {
            return;
        }

        node.val = preorder[_preorderPosition];            
        if (node.val == postorder[_postorderPosition]) 
        {
            _preorderPosition++;
            _postorderPosition++;
            return;
        }

        _preorderPosition++;
        node.left = new TreeNode();
        StartDFS(node.left, preorder, postorder);
        if (node.val == postorder[_postorderPosition])
        {                
            _postorderPosition++;
            return;
        }

        node.right = new TreeNode();
        StartDFS(node.right, preorder, postorder);
        _postorderPosition++;
    }
}