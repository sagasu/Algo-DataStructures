using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Symmetric_Tree
{
    [TestClass]
    public class Symmetric_Tree
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)),
                new TreeNode(2, new TreeNode(4), new TreeNode(3)));
            Assert.IsTrue(IsSymmetric(t));
        }
        
        [TestMethod]
        public void Test1()
        {
            var t = new TreeNode(1, new TreeNode(2,null, new TreeNode(3)),
                new TreeNode(2, null, new TreeNode(3)));
            Assert.IsFalse(IsSymmetric(t));
        }

        public bool IsSymmetric(TreeNode root)
        {
            IList<int?> inOrder = new List<int?>();
            IList<int?> postOrder = new List<int?>();
            void LeftFirstTraverse(TreeNode node)
            {
                if (node.left == null && node.right == null)
                {
                    inOrder.Add(node.val);
                    return;
                }
                if (node.left != null) LeftFirstTraverse(node.left);
                else inOrder.Add(null);
                if (node.right != null) LeftFirstTraverse(node.right);
                else inOrder.Add(null);
                inOrder.Add(node.val);
            }
            void RightFirstTraverse(TreeNode node)
            {
                if (node.left == null && node.right == null)
                {
                    postOrder.Add(node.val);
                    return;
                }
                if (node.right != null) RightFirstTraverse(node.right);
                else postOrder.Add(null);
                if (node.left != null) RightFirstTraverse(node.left);
                else postOrder.Add(null);
                postOrder.Add(node.val);
            }
            LeftFirstTraverse(root);
            RightFirstTraverse(root);
            for (var i = 0; i < inOrder.Count; i++)
                if (inOrder[i] != postOrder[i]) return false;
            
            return true;
        }
    }
}
