using System;
using System.Collections.Generic;


namespace AlgoTest.LeetCode.SymetricTree
{
    class SymetricTree
    {
        public List<int> inOrder = new List<int>();
        public List<int> symetricInOrder = new List<int>();

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            //Traverse(root, inOrder, (treeNode) =>treeNode.left, treeNode => treeNode.right );
            //Traverse(root, symetricInOrder, (treeNode) => treeNode.left, treeNode => treeNode.right);
            TraverseInOrder(root);
            TraverseInSymOrder(root);

            for (var i = 0; i < inOrder.Count; i++)
            {
                if (inOrder[i] != symetricInOrder[i])
                    return false;
            }

            return true;
        }


        private void Traverse(TreeNode root, List<int> order, System.Linq.Expressions.Expression<Func<TreeNode,TreeNode>> firstExpression, System.Linq.Expressions.Expression<Func<TreeNode, TreeNode>> secondExpression)
        {
            order.Add(root.val);

            var firstChild = firstExpression.Compile().Invoke(root);
            if (firstChild != null)
            {
                Traverse(firstChild, order, firstExpression, secondExpression);
            }
            else
            {
                order.Add(-1);
            }

            var secondChild = secondExpression.Compile().Invoke(root);
            if (secondChild != null)
            {
                Traverse(secondChild, order, firstExpression, secondExpression);
            }
            else
            {
                order.Add(-1);
            }
        }

        private void TraverseInOrder(TreeNode root)
        {
            inOrder.Add(root.val);

            if (root.left != null)
            {
                TraverseInOrder(root.left);
            }
            else
            {
                inOrder.Add(-1);
            }

            if (root.right != null)
            {
                TraverseInOrder(root.right);
            }
            else
            {
                inOrder.Add(-1);
            }
        }

        private void TraverseInSymOrder(TreeNode root)
        {
            symetricInOrder.Add(root.val);

            if (root.right != null)
            {
                TraverseInSymOrder(root.right);
            }
            else
            {
                symetricInOrder.Add(-1);
            }

            if (root.left != null)
            {
                TraverseInSymOrder(root.left);
            }
            else
            {
                symetricInOrder.Add(-1);
            }
        }
    }
}
