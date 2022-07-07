using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Interleaving_String
{
    internal class Interleaving_String
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(0, 0));
            var s3Index = 0;
            var visited = new HashSet<Tuple<int, int>>();

            while (queue.Count > 0 && s3Index < s3.Length)
            {

                var n = queue.Count;
                for (var i = 0; i < n; i++)
                {

                    var node = queue.Dequeue();
                    if (visited.Contains(node)) continue;
                    visited.Add(node);
                    if (node.Item1 < s1.Length && s3[s3Index] == s1[node.Item1])
                        queue.Enqueue(Tuple.Create(node.Item1 + 1, node.Item2));
                    
                    if (node.Item2 < s2.Length && s3[s3Index] == s2[node.Item2])
                        queue.Enqueue(Tuple.Create(node.Item1, node.Item2 + 1));
                    
                }
                s3Index++;

            }

            return queue.Count > 0 && s3Index == s3.Length;
        }
    }
}
