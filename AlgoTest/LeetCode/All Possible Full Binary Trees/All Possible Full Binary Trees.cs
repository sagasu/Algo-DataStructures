public class AllPossibleFullBinaryTrees {
    public IList<TreeNode> AllPossibleFBT(int n) {
        if (n % 2 == 0) return new List<TreeNode>();
        var tress = new List<TreeNode>[ n / 2 + 1];
        tress[0] = new List<TreeNode>() { new TreeNode(0) };
        
        for(var i = 3; i <= n; i += 2)
        {
            var list = new List<TreeNode>();
            for (var j = 1; j < i; j += 2)
            {
                foreach(var left in tress[j / 2])
                {
                    foreach(var right in tress[(i - 1 - j) / 2])
                    {
                        var node = new TreeNode(0);
                        node.left = left;
                        node.right = right;
                        list.Add(node);
                    }
                }
            }
            
            tress[i / 2] = list;
        }
        
        return tress[n / 2];
    }
}