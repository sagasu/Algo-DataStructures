using System;
using System.Collections.Generic;
using System.Linq;

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

        private bool HasPathBFS(int source, int destination) {
            var s = GetNode(source);
            var d = GetNode(destination);
            var visitedNodesIds = new HashSet<int>();
            var nodesToVisit = new Queue<Node>();
            nodesToVisit.Enqueue(s);
            return HasPathBFS(s, d, visitedNodesIds, nodesToVisit);
        }

        private bool HasPathBFS(Node s, Node d, HashSet<int> visitedNodesIds, Queue<Node> nodesToVisit) {
            if (nodesToVisit.Count == 0)
                return false;

            if (s == d)
                return true;

            visitedNodesIds.Add(s.id);
            foreach (var nei in s.Neighbours){
                if (visitedNodesIds.Contains(nei.id))
                    continue;

                nodesToVisit.Enqueue(nei);
            }

            return HasPathBFS(nodesToVisit.Dequeue(), d, visitedNodesIds, nodesToVisit);
        }
    }
}
