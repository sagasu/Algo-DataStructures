using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Trapping_Rain_Water_II;

public class Trapping_Rain_Water_II
{
    public int TrapRainWater(int[][] heightMap) {
        int ROWS = heightMap.Length, COLS = heightMap[0].Length;
        var minHeap = new PriorityQueue<(int,int,int),(int,int,int)>();
        for(int r=0;r<ROWS;r++){
            for(int c=0;c<COLS;c++){
                if(r==0 || r==ROWS-1 || c==0 || c==COLS-1){
                    minHeap.Enqueue((heightMap[r][c],r,c),(heightMap[r][c],r,c));
                    heightMap[r][c] = -1;
                }
            }
        }
        int res=0, maxHeight=0;
        while(minHeap.Count>0){
            var (hei,r,c) = minHeap.Dequeue();
            maxHeight = Math.Max(maxHeight,hei);
            res += maxHeight-hei;
            var nei = new int[4][]{new int[2]{r+1,c},new int[2]{r-1,c},new int[2]{r,c+1},new int[2]{r,c-1}};
            foreach(var n in nei){
                int nr = n[0], nc=n[1];
                if(Math.Min(nr,nc)<0 || nr==ROWS || nc==COLS || heightMap[nr][nc]==-1)
                    continue;
                minHeap.Enqueue((heightMap[nr][nc],nr,nc),(heightMap[nr][nc],nr,nc));
                heightMap[nr][nc] = -1;
            }
        }
        return res;
    }
}