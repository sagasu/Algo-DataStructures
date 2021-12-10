using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Binary_Tree_Tilt
{
    public class Binary_Tree_Tilt
    {
        public int FindTilt(TreeNode root)
        {
            var tilt = 0;
            Dfs(root, ref tilt);
            return tilt;
        }

        private int Dfs(TreeNode root, ref int tilt)
        {
            if (root == null)  return 0;

            var lt = Dfs(root.left, ref tilt);
            var rt = Dfs(root.right, ref tilt);
            var tt = Math.Abs(lt - rt);

            tilt += tt;

            return root.val + lt + rt;
        }
    }
}
