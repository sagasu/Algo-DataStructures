using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Average_of_Levels_in_Binary_Tree
{
    public class Average_of_Levels_in_Binary_Tree
    {
        IDictionary<int, IList<int>> average = new Dictionary<int, IList<int>>();

        public IList<double> AverageOfLevels(TreeNode root)
        {
            var ret = new List<double>();
            BuildAverageOfLevels(root, 0);
            foreach (var key in average.Keys)
            {
                ret.Add(average[key].Average());
            }
            ret.Reverse();
            return ret;
        }

        private void BuildAverageOfLevels(TreeNode root, int level)
        {
            if (root == null) return;

            if (!average.ContainsKey(level))
            {
                average.Add(level, new List<int>() { root.val });
            }
            else
            {
                average[level].Add(root.val);
            }
            BuildAverageOfLevels(root.left, level + 1);

            BuildAverageOfLevels(root.right, level + 1);
        }
    }
}
