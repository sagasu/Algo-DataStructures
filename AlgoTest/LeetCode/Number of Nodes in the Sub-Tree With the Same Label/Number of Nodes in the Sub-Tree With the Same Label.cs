using System.Collections.Generic;

public class CountSubTreesSolution
{
    private List<List<int>> _tree;
    private string _labels;

    private int[] _subTrees;

    public int[] CountSubTrees(int n, int[][] edges, string labels)
    {
        _subTrees = new int[n];
        _labels = labels;
        _tree = new List<List<int>>(n);
        for(var i = 0; i < n; i++)
            _tree.Add(new List<int>());

        foreach(var edge in edges)
        {
            _tree[edge[0]].Add(edge[1]);
            _tree[edge[1]].Add(edge[0]);
        }

        FillCountSubTrees(0, 0);
        return _subTrees;
    }

    public int[] FillCountSubTrees(int index, int parent)
    {
        int[] tree = new int[26];
        tree[_labels[index] % 26] = 1;
        foreach(var edge in _tree[index])
        {
            if (edge == parent) continue;
            var sub = FillCountSubTrees(edge, index);
            for (int i = 0; i < 26; i++)
                tree[i] += sub[i];
        }

        _subTrees[index] = tree[_labels[index] % 26];
        return tree;
    }
}