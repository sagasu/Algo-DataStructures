using System.Collections.Generic;

namespace AlgoTest.LeetCode.Recover_a_Tree_From_Preorder_Traversal;

public class Recover_a_Tree_From_Preorder_Traversal
{
    public TreeNode RecoverFromPreorder(string traversal) {
        int n = traversal.Length, idx = 0, d, no;
        TreeNode root = new();
        Stack<TreeNode> st = new();
        while(idx<n)
        {
            // get Depth
            d = no = 0;
            while(idx < n && traversal[idx]=='-')
            {
                d++;
                idx++;
            }
            // get Number
            while(idx < n && char.IsDigit(traversal[idx]))
                no=(no*10)+traversal[idx++]-'0';
            
            if(d==0)    // Root Node
            {
                root.val = no;
                st.Push(root);
            }
            else
            {
                while(st.Count>d)   // reach the appropriate level as per the depth of next node
                    st.Pop();
                var node = st.Peek();
                if(node.left==null) // create a left child
                {
                    node.left = new(no);
                    st.Push(node.left);
                }
                else                 // create a right child
                {
                    node.right = new(no);
                    st.Push(node.right);
                }
            }
        }
        return root;
    }
}