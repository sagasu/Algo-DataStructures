using System.Collections.Generic;

namespace AlgoTest.LeetCode.Second_Minimum_Time_to_Reach_Destination;

public class Second_Minimum_Time_to_Reach_Destination
{
    public int SecondMinimum(int n, int[][] edges, int time, int change)
        {
            var graph = new List<int>[n+1];
            
            for (var i = 0; i<graph.Length; i++)
                graph[i] = new List<int>();
            
            foreach (var e in edges)
            {
                graph[e[0]].Add(e[1]);
                graph[e[1]].Add(e[0]);
            }
            
            var memo = new int[n+1][];
            for (int i = 0; i<memo.Length; i++)
                memo[i] = new int[] { int.MaxValue, int.MaxValue };
            
            var q = new Queue<int[]>();
            var seed = new int[] { 1, 0 };
            q.Enqueue(seed);
            
            while(q.Count > 0)
            {
                var size = q.Count;
                while (size-->0)
                {
                    var top = q.Dequeue();
                    var offset = top[1]%(change*2);
                    if (offset<change)
                    {
                        foreach (var i in graph[top[0]])
                        {
                            var arriveTime = top[1]+time;
                            if (arriveTime>memo[i][1])
                                continue;//slower than 2nd, discard
                            else if (arriveTime==memo[i][0]|| arriveTime==memo[i][1])
                                continue;//want unique result, discard duplicate
                            else
                            {
                                if (arriveTime<memo[i][0])
                                {
                                    memo[i][1] = memo[i][0];
                                    memo[i][0] = arriveTime;
                                }
                                else
                                {
                                    memo[i][1] = arriveTime;
                                }
                                var nextVisit = new int[] { i, arriveTime };
                                q.Enqueue(nextVisit);
                            }
                        }
                    }
                    else
                    {
                        top[1]+=2*change - offset;
                        q.Enqueue(top);
                    }
                }
            }
            return memo[n][1];
        }
}