using System.Collections.Generic;

namespace AlgoTest.LeetCode.Clone_Graph
{
    public class Clone_Graph
    {
        public Node CloneGraph(Node node)
        {
            if (node == null) return node;

            var queue = new Queue<Node>();
            var visited = new Dictionary<Node, Node>();  

            queue.Enqueue(node);
            visited.Add(node, new Node(node.val));

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach (var neighbor in curr.neighbors)
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        visited.Add(neighbor, new Node(neighbor.val));
                        queue.Enqueue(neighbor);
                    }
                    
                    visited[curr].neighbors.Add(visited[neighbor]);
                }
            }

            return visited[node];
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
