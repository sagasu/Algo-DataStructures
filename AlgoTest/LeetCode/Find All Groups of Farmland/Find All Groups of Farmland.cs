using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_All_Groups_of_Farmland;

public class Find_All_Groups_of_Farmland
{
    public int[][] FindFarmland(int[][] land) 
    {
        var m = land.Length;
        var n = land[0].Length;
        List<int[]> ans = new();
        
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(land[i][j]==1)
                {
                    int[] farmLand = {i,j,-1,-1};
                    Dfs(land,i,j,farmLand);
                    ans.Add(farmLand);
                }
        return ans.ToArray();
    }
    
    private static void Dfs(int[][] land, int x, int y, int[] farmLand)
    {
        if(x<0 || x>=land.Length || y<0 || y>=land[0].Length || land[x][y]==0 || land[x][y]==-1)
            return;
        
        land[x][y] = -1; 
        
        farmLand[2] = Math.Max(farmLand[2],x);
        farmLand[3] = Math.Max(farmLand[3],y);
        
        Dfs(land,x-1,y,farmLand);
        Dfs(land,x+1,y,farmLand);
        Dfs(land,x,y-1,farmLand);
        Dfs(land,x,y+1,farmLand);
    }
}