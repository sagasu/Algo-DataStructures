using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Delete_Duplicate_Folders_in_System;

public class Delete_Duplicate_Folders_in_System
{

    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths){
        var root = BuildTree(paths);

        var serialMap = new Dictionary<string, List<TreeNode>>();
        Serialize(root, serialMap);

        foreach (var pair in serialMap)
        {
            if (pair.Value.Count > 1)
            {
                foreach (var node in pair.Value)
                {
                    node.ToDelete = true;
                }
            }
        }

        var result = new List<IList<string>>();
        CollectPaths(root, result);
        return result;
    }

    private TreeNode BuildTree(IList<IList<string>> paths)
    {
        var root = new TreeNode();
        foreach (var path in paths)
        {
            var node = root;
            foreach (var folder in path)
            {
                if (!node.Children.ContainsKey(folder))
                    node.Children[folder] = new TreeNode();
                node = node.Children[folder];
            }
            node.Path = new List<string>(path);
        }
        return root;
    }

    private string Serialize(TreeNode node, Dictionary<string, List<TreeNode>> serialMap)
    {
        if (node.Children.Count == 0)
        {
            node.Serial = "()";
            return node.Serial;
        }

        var parts = new List<string>();
        foreach (var kvp in node.Children.OrderBy(k => k.Key))
        {
            string childSerial = Serialize(kvp.Value, serialMap);
            parts.Add(kvp.Key + childSerial);
        }

        node.Serial = "(" + string.Join("", parts) + ")";
        if (!serialMap.ContainsKey(node.Serial))
            serialMap[node.Serial] = new();
        serialMap[node.Serial].Add(node);
        return node.Serial;
    }

    private void CollectPaths(TreeNode node, List<IList<string>> result)
    {
        if (node.ToDelete)
            return;

        if (node.Path.Count > 0)
            result.Add(node.Path);

        foreach (var child in node.Children.Values)
        {
            CollectPaths(child, result);
        }
    }
}

public class TreeNode
{
    public Dictionary<string, TreeNode> Children = new();
    public List<string> Path = new();
    public string Serial = "";
    public bool ToDelete = false;
}
