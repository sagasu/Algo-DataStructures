using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Square_Area_by_Removing_Fences_From_a_Field;

public class Maximum_Square_Area_by_Removing_Fences_From_a_Field
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {

        var hPoints= new List<int>(hFences);
        hPoints.Add(1);
        hPoints.Add(m);
        hPoints.Sort();

        var vPoints= new List<int>(vFences);
        vPoints.Add(1);
        vPoints.Add(n);
        vPoints.Sort();
        HashSet<long> possibleHeights=new HashSet<long>();
        for(int i=0;i<hPoints.Count;i++){
            for(int j=i+1;j<hPoints.Count;j++){
                possibleHeights.Add((long)hPoints[j]-hPoints[i]);
            }
        }

        long maxSide=-1;

        for(int i=0;i<vPoints.Count;i++){
            for(int j=i+1;j<vPoints.Count;j++){
                long currentWidth=(long)vPoints[j]-vPoints[i];

                if(possibleHeights.Contains(currentWidth)){
                    maxSide=Math.Max(maxSide,currentWidth);
                }
            }
        }

        if(maxSide==-1) return -1;

        long MOD =1_000_000_007;
        return (int)((maxSide*maxSide)%MOD);
    }
    
}