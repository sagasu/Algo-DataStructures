using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Divide_Nodes_Into_the_Maximum_Number_of_Groups;

public class Divide_Nodes_Into_the_Maximum_Number_of_Groups
{
    public int MagnificentSets(int n, int[][] edges) {

        var adjList=new List<int>[n+1];
        foreach (var e in edges)
        {
            int e0=e[0], e1=e[1];
            (adjList[e0] ??= new()).Add(e1);
            (adjList[e1] ??= new()).Add(e0);
        }
        
        int[] dist=new int[n+1], bestByMinN=new int[n+1];
        var q=new Queue<int>();
        var result=0;
        for(int i=1; i<=n; i++) {
            if(adjList[i]==null) { result++; continue; }
            Array.Clear(dist);
            dist[i]=1;
            q.Enqueue(i);
            int minN=i, maxDist=1;
            while(q.Count>0) {
                int prevN=q.Dequeue(), curDist=dist[prevN]+1, parity=curDist&1;
                var curAdj=adjList[prevN];
                foreach (var t in curAdj)
                {
                    int curN=t, distN=dist[curN];
                    if(distN>0) {
                        if((distN&1)!=parity) return -1;
                    } else {
                        dist[curN]=curDist;
                        q.Enqueue(curN);
                        if(curDist>maxDist) maxDist=curDist;
                        if(curN<minN) minN=curN;
                    }
                }
            }
            var prevBest=bestByMinN[minN];
            if(maxDist>prevBest) {
                result+=maxDist-prevBest;
                bestByMinN[minN]=maxDist;
            }
        }
        return result;
    }
}