using System;
using System.Collections.Generic;

namespace Algo.Graph
{
    public class Graph
    {
        Dictionary<int,Node> Nodes = new Dictionary<int, Node>();

        class Node {
            public int id;
            public List<Node> Neighbours { get; set; }

            public Node(int id)
            {
                Neighbours = new List<Node>();
                this.id = id;
            }
        }

        Node GetNode(int id) {
            return Nodes[id];
        }

        public void AddEdge(int source, int destination) {
            var s = GetNode(source);
            var d = GetNode(destination);
            s.Neighbours.Add(d);
            d.Neighbours.Add(s);
        }

        public bool HasPathDFS(int source, int destination) {
            var s = GetNode(source);
            var d = GetNode(destination);
            var visitedNodesIds = new HashSet<int>();

            return HasPathDFS(s, d, visitedNodesIds);
        }

        private bool HasPathDFS(Node s, Node d, HashSet<int> visitedNodesIds)
        {
            if (s.id == d.id)
                return true;

            if (visitedNodesIds.Contains(s.id))
                return false;

            visitedNodesIds.Add(s.id);

            foreach (var n in s.Neighbours) {
                var found = HasPathDFS(n, d, visitedNodesIds);
                if (found)
                    return true;
            }
            return false;

        }
    }
}
