using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SumRoottoLeafNumbers
{
    [TestClass]
    public class Sum_Root_to_Leaf_Numbers
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode(4, new TreeNode(9, new TreeNode(5), new TreeNode(1)), new TreeNode(0));
            SumNumbers(t);
            Assert.AreEqual(1026, sum);
        }

        private int sum = 0;
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            SumNumb(root, "");
            return sum;
        }

        private void SumNumb(TreeNode root, string number)
        {
            if (root.left == null && root.right == null)
            {
                sum += int.Parse(number + root.val);
                return;
            }

            if(root.left!=null) SumNumb(root.left, number + root.val);
            if(root.right!=null) SumNumb(root.right, number + root.val);
        }
    }
}
