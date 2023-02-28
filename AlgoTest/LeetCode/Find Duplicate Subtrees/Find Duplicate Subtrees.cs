using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Find_Duplicate_Subtrees
{
    internal class Find_Duplicate_Subtrees
    {
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var dic = new Dictionary<int, List<TreeNode>>();
            int GetHash(TreeNode n)
            {
                if (n == null) return 0;
                
                var hash = HashCode.Combine(n.val, GetHash(n.left), GetHash(n.right));
                if (!dic.TryGetValue(hash, out var list))
                    dic.Add(hash, list = new List<TreeNode>());
                
                list.Add(n);
                return hash;
            }

            GetHash(root);
            var res = new List<TreeNode>();
            foreach (var pair in dic.Where(p => p.Value.Count > 1)) res.Add(pair.Value.First());
            
            return res;
        }
    }
}
