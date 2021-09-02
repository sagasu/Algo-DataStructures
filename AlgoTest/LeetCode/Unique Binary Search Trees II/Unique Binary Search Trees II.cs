using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Unique_Binary_Search_Trees_II
{
    class Unique_Binary_Search_Trees_II
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            return n == 0 ? new List<TreeNode>() : DFS(1, n);

            IList<TreeNode> DFS(int start, int end)
            {
                if (start > end) return new List<TreeNode>() { null };
                
                var result = new List<TreeNode>();
                for (var i = start; i <= end; i++)
                {
                    var leftList = DFS(start, i - 1);
                    var rightList = DFS(i + 1, end);

                    foreach (var left in leftList)
                        foreach (var right in rightList) {
                            var root = new TreeNode(i) {left = left, right = right};
                            result.Add(root);
                        }
                    
                }

                return result;
            }
        }
    }
}
