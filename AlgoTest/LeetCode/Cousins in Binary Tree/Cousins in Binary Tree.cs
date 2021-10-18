using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Cousins_in_Binary_Tree
{
    class Cousins_in_Binary_Tree
    { 
        public bool IsCousins(TreeNode root, int x, int y)
        {

            if (root == null)
                return false;

            var dic = new Dictionary<int, List<int>>();
            Inorder(root, 0, int.MinValue, dic);

            return dic.ContainsKey(x) && dic.ContainsKey(y) && dic[x][0] == dic[y][0] && dic[x][1] != dic[y][1];
        }

        public void Inorder(TreeNode root, int depth, int parent, Dictionary<int, List<int>> dic)
        {
            if (root == null)
                return;

            Inorder(root.left, depth + 1, root.val, dic);
            dic.Add(root.val, new List<int> { depth, parent });
            Inorder(root.right, depth + 1, root.val, dic);
        }
    }
}
