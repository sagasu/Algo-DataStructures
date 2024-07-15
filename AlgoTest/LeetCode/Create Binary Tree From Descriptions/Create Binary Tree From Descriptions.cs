using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Create_Binary_Tree_From_Descriptions;

public class Create_Binary_Tree_From_Descriptions
{
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var dict = new Dictionary<int, TreeNode>();
        var notRoots = new HashSet<int>();

        foreach (var desc in descriptions) {
            var parentValue = desc[0];
            var childValue = desc[1];
            var isLeft = desc[2] == 1;

            if (!dict.TryGetValue(parentValue, out var parent))
                dict[parentValue] = parent = new(parentValue);

            if (!dict.TryGetValue(childValue, out var child))
                dict[childValue] = child = new(childValue);

            if (isLeft) 
                parent.left = child;
            else 
                parent.right = child;

            notRoots.Add(childValue);
        }

        return dict[descriptions.First(d => !notRoots.Contains(d[0]))[0]];
    }
}