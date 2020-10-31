using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.RecoverBinarySearchTree
{
    [TestClass]
    public class RecoverBinarySearchTree
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode(1, new TreeNode(3, null, new TreeNode(2)));
            RecoverTree(t);
        }
        //There are exactly two nodes that were swapped
        public void RecoverTree(TreeNode root)
        {
            InOrderTraverse(root);
            var temp = first.val;
            first.val = second.val;
            second.val = temp;
        }

        private bool isFirstFound = false;
        private TreeNode first;
        private TreeNode second;
        
        private void InOrderTraverse(TreeNode root)
        {
            if (root.left != null)
            {
                if (root.left.val > root.val)
                {
                    StoreRoot(root.left);
                }

                InOrderTraverse(root.left);
            }

            if (root.right != null)
            {
                if (root.right.val < root.val)
                {
                    StoreRoot(root.right);
                }

                InOrderTraverse(root.right);
            }
        }

        private void StoreRoot(TreeNode node)
        {
            if (!isFirstFound)
            {
                first = node;
                isFirstFound = true;
            }
            else if(node.val != first.val)
            {
                second = node;
            }
            
        }
    }
}
