using System.Collections.Generic;
using System.Linq;
using AlgoTest.LeetCode.N_ary_Tree_Preorder_Traversal;

namespace AlgoTest.LeetCode.N_ary_Tree_Level_Order_Traversal
{
    internal class N_ary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(Node root) {
            if(root == null) return new List<IList<int>>();

            var queue = new Queue<Node>();
            var res = new List<IList<int>>();
            queue.Enqueue(root);

            while(queue.Any()){
                var n = queue.Count;
                var temp = new List<int>();
                for(var i = 0; i< n; i++){
                    var cur = queue.Dequeue();
                    temp.Add(cur.val);
                    foreach(var item in cur.children)
                        if(item != null) queue.Enqueue(item);
                }
                res.Add(temp);
            }

            return res;
        }
    }
}
