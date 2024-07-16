using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another;

public class Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another
{
    public string GetDirections(TreeNode root, int startValue, int destValue) 
    {
        var path = new List<char>();
        var start = "";
        var target = "";
        void Traverse(TreeNode node)
        {
            if (node == null) { return; }
            if (node.val == startValue) 
                start = new string(path.ToArray());
            else if (node.val == destValue) 
                target = new string(path.ToArray());

            path.Add('L');
            Traverse(node.left);
            path.RemoveAt(path.Count - 1);
            
            path.Add('R');
            Traverse(node.right);
            path.RemoveAt(path.Count - 1);
        }

        Traverse(root);

        var sameIndex = -1;
        for (var i = 0; i < start.Length; i++)
        {
            var s = start[i];
            if (target.Length > i) 
            {
                var t = target[i];
                if (s == t) { sameIndex = i; continue; }
            }

            break;
        }

        var result = new StringBuilder();
        for (var i = sameIndex + 1; i < start.Length; i++)
            result.Append('U');
        

        for (int i = sameIndex + 1; i < target.Length; i++)
            result.Append(target[i]);
        

        return result.ToString();
    }
}