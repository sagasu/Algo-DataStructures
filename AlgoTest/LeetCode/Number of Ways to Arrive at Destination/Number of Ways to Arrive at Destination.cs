using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Ways_to_Arrive_at_Destination;

public class Number_of_Ways_to_Arrive_at_Destination
{
    const int Modulo9m7 = 1_000_000_007;

    public int CountPaths(int n, int[][] roads)
    {
        var count = new int[n];
        var dista = Enumerable.Repeat(long.MaxValue, n).ToArray();

        var directions = new List<(int to, int distance)>[n];

        for (var i = 0; i < n; i++) directions[i] = new();

        foreach (var r in roads)
        {
            directions[r[0]].Add((r[1], r[2]));
            directions[r[1]].Add((r[0], r[2]));
        }

        var pq = new PriorityQueue<int, long>();

        count[0] = 1;
        dista[0] = 0;

        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out var vertex, out var distToVertex);

            foreach (var dir in directions[vertex])
            {
                var distTo = distToVertex + dir.distance;

                if (distTo < dista[dir.to])
                {
                    dista[dir.to] = distTo;
                    count[dir.to] = count[vertex];

                    pq.Enqueue(dir.to, distTo);
                }
                else if(distTo == dista[dir.to])
                {
                    count[dir.to] = (count[dir.to] + count[vertex]) % Modulo9m7;
                }
            }
        }

        return count[n - 1];
    }
}