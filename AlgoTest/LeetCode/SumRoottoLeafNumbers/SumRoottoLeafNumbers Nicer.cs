using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SumRoottoLeafNumbers
{
    class SumRoottoLeafNumbers_Nicer
    {
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            SumNumb(root, "");
            return sum;
        }

        private int sum = 0;

        private void SumNumb(TreeNode root, string numb)
        {
            numb += root.val;

            if(root.left != null) SumNumb(root.left, numb);

            if(root.right != null) SumNumb(root.right, numb);

            if (root.left == null && root.right == null && !string.IsNullOrEmpty(numb)) sum += int.Parse(numb);
        }
    }
}
