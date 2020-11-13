using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MaximumDifferenceBetweenNodeAndAncestor
{
    [TestClass]
    public class MaximumDifferenceBetweenNodeAndAncestor
    {
        [TestMethod]
        public void Test()
        {
            //var t = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(0, new TreeNode(3))));
            //var t = new TreeNode(8, new TreeNode(3, new TreeNode(1), new TreeNode(6, new TreeNode(4), new TreeNode(7))), new TreeNode(10, null, new TreeNode(14, new TreeNode(13))));
            //exp: 5
            var t = new TreeNode(2, null, new TreeNode(3, new TreeNode(0), new TreeNode(5, null, new TreeNode(7))));
            MaxAncestorDiff(t);
        }

        public int MaxAncestorDiff(TreeNode root)
        {
            var (min, max, diff) = MinMaxNodes(root, int.MaxValue, int.MinValue);

            return diff;
        }

        public ValueTuple<int, int, int> MinMaxNodes(TreeNode root, int min, int max)
        {
            if (root == null)
                return (min, max, 0);

            var (lmin, lmax, ldiff) = MinMaxNodes(root.left, min, max);

            var (rmin, rmax, rdiff) = MinMaxNodes(root.right, min, max);


            ldiff = lmax == Int32.MinValue? 0 : Math.Max(ldiff, Math.Abs(lmax - root.val));
            ldiff = lmin== Int32.MaxValue ? 0: Math.Max(ldiff, Math.Abs(lmin - root.val));

            rdiff = rmin == Int32.MaxValue? 0 :Math.Max(rdiff, Math.Abs(rmin - root.val));
            rdiff = rmax == Int32.MinValue ? 0 : Math.Max(rdiff, Math.Abs(rmax - root.val));

            lmin = Math.Min(lmin, root.val);
            rmin = Math.Min(rmin, root.val);

            lmax = Math.Max(lmax, root.val);
            rmax = Math.Max(rmax, root.val);

            return (Math.Min(lmin, rmin), Math.Max(lmax, rmax), Math.Max(ldiff, rdiff));
        }
    }
}
