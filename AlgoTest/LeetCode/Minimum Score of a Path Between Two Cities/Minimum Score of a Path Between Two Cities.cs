public class Minimum ScoreofaPathBetweenTwoCities {
    public int MinScore(int n, int[][] roads) {
        List<List<(int x, int d)>> graph = new List<List<(int x, int d)>>();
        InitializeGraph(n, roads, graph);

        int minDistance = int.MaxValue;
        bool[] v = new bool[n + 1];
        DFS(graph, ref minDistance, v, 1);

        return minDistance;
    }

    private void DFS(List<List<(int x, int d)>> graph, ref int minDistance, bool[] v, int cur)
    {
        if (v[cur])
            return;

        v[cur] = true;
        foreach (var c in graph[cur])
        {
            if (c.d < minDistance)
                minDistance = c.d;

            DFS(graph, ref minDistance, v, c.x);
        }
    }

    private void InitializeGraph(int n, int[][] roads, List<List<(int x, int d)>> graph)
    {
        for (int i = 0; i <= n; i++)
        {
            graph.Add(new List<(int x, int d)>());
        }

        for (int i = 0; i < roads.Length; i++)
        {
            int a = roads[i][0];
            int b = roads[i][1];
            int d = roads[i][2];
            graph[a].Add((b, d));
            graph[b].Add((a, d));
        }
    }
}