public class FindEventualSafeStates {
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        Dictionary<int, bool> isLeadingToTerminal = new();
        return Enumerable.Range(0, graph.Length).Where(IsLeadingToTerminal).ToArray();

        bool IsLeadingToTerminal(int node)
        {
            if (isLeadingToTerminal.ContainsKey(node)) return isLeadingToTerminal[node];
            isLeadingToTerminal[node] = false;
            return isLeadingToTerminal[node] = graph[node].All(IsLeadingToTerminal);
        }
    }
}