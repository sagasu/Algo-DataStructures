using System.Collections.Generic;

namespace AlgoTest.LeetCode.Spiral_Matrix_III;

public class Spiral_Matrix_III
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        List<int[]> result = new();
        var directions = new int[,]{{0,1} ,{1,0},{0,-1},{-1,0}};
        var len =0;
        var d =0;
        
        result.Add(new int[]{rStart, cStart});

        while(result.Count < rows * cols)
        {
            if(d==0 || d==2)
                len++;
            
            for(var k=0; k<len; k++)
            {
                rStart += directions[d,0];
                cStart += directions[d,1];
                if(rStart < rows && rStart >=0 && cStart < cols && cStart >=0)
                    result.Add(new int[]{rStart, cStart});
            }
            
            d= (d+1) % 4;
        }
        
        return result.ToArray();
    }
}