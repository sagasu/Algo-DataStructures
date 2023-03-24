public class Reorder RoutestoMakeAllPathsLeadtotheCityZero {
    public int MinReorder(int n, int[][] connections) {
        
        HashSet<(int from, int to)> edges = new();
        Dictionary<int, List<int>> neighbors = new();
        for (var i = 0; i < connections.Length; i++)
        {
            var from = connections[i][0];
            var to = connections[i][1];
            edges.Add((from, to));
            
            addNeighbor(from, to);
            addNeighbor(to, from);            
        }
        
        HashSet<int> visited = new() { 0 };
               
        return countInversions(0);
        
        int countInversions(int node)
        {
            var inversionCount = 0;
            
            foreach (var neighbor in neighbors[node])
            {
                if (visited.Contains(neighbor)) continue;
                
                if (edges.Contains((neighbor, node)) is false) inversionCount++;
                
                visited.Add(neighbor);
                
                inversionCount += countInversions(neighbor);
            }
            
            return inversionCount;
        }
        
        void addNeighbor(int node, int neighbor)
        {
            if (neighbors.TryGetValue(node, out var neighborList) is false)
            {
                neighborList = new();
                neighbors.Add(node, neighborList);
            }
            
            neighborList.Add(neighbor);
        }
    }
}