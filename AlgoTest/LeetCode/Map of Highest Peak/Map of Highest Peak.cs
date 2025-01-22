using System.Collections.Generic;

namespace AlgoTest.LeetCode.Map_of_Highest_Peak;

public class Map_of_Highest_Peak
{
    public int[][] HighestPeak(int[][] isWater) {
        Queue<(int y, int x)> queue = new ();
        for (int i = 0; i < isWater.Length; i++)
        for (int j = 0; j < isWater[0].Length; j++)
        {
            if (isWater[i][j] == 1) 
            {
                isWater[i][j] = 0;
                queue.Enqueue((i,j));
            }
            else isWater[i][j] = -1;
        }

        while (queue.Count > 0)
        {
            var v = queue.Dequeue();
            var newVal = isWater[v.y][v.x]+1;
            if (v.x > 0 && isWater[v.y][v.x-1] == -1 ) { isWater[v.y][v.x-1] = newVal; queue.Enqueue((v.y,v.x-1));}
            if (v.y > 0 && isWater[v.y-1][v.x] == -1 ) { isWater[v.y-1][v.x] = newVal; queue.Enqueue((v.y-1,v.x));}
            if (v.x < isWater[0].Length-1 && isWater[v.y][v.x+1] == -1 ) { isWater[v.y][v.x+1] = newVal; queue.Enqueue((v.y,v.x+1));}
            if (v.y < (isWater.Length-1) && isWater[v.y+1][v.x] == -1 ) { isWater[v.y+1][v.x] = newVal; queue.Enqueue((v.y+1,v.x)); }
        }

        return isWater;
    }
}