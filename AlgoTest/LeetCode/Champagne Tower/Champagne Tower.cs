using System;

namespace AlgoTest.LeetCode.Champagne_Tower;

public class Champagne_Tower
{
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        var row = new double[1];
        row[0] = poured;

        for(int i =0;i < query_row;i++){
            var next = new double[i+2];

            for(int j =0; j < row.Length;j++){
                var overflow = Math.Max(0,row[j] - 1.0);
                if(overflow > 0){
                    next[j] += overflow/ 2.0;
                    next[j+1] += overflow/2.0;
                }
            }
            row = next;
        }
        return Math.Min(1.0, row[query_glass]);
    }
}