using System;

namespace AlgoTest.LeetCode.Maximal_Network_Rank;

public class Maximal_Network_Rank
{
    public int MaximalNetworkRank(int n, int[][] roads) {
        var connected = new bool[n,n];
        var cnts = new int[n];
        
        foreach(var r in roads)
        {
            cnts[r[0]]++;
            cnts[r[1]]++;
            connected[r[0],r[1]] = true;
            connected[r[1],r[0]] = true;
        }
        
        var res = 0;
        for(var i =0;i<n;i++)
        {
            for(var j =i+1;j<n;j++)
            {
                var tmp = cnts[i] + cnts[j] - (connected[i,j] ? 1: 0);
                res = Math.Max(res,tmp);
            }
        }
        
        return res;
    } 
}