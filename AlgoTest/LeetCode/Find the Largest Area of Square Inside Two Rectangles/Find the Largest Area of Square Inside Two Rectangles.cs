using System;

namespace AlgoTest.LeetCode.Find_the_Largest_Area_of_Square_Inside_Two_Rectangles;

public class Find_the_Largest_Area_of_Square_Inside_Two_Rectangles
{
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight) {
        long maxSide=0;
        int n=bottomLeft.Length;
      
        for(int i=0;i<n;i++){
            for(int j=i+1;j<n;j++){
                int minX= Math.Max(bottomLeft[i][0],bottomLeft[j][0]);

                int maxX= Math.Min(topRight[i][0],topRight[j][0]);

                int minY= Math.Max(bottomLeft[i][1],bottomLeft[j][1]);

                int maxY= Math.Min(topRight[i][1],topRight[j][1]);

                if(minX<maxX && minY < maxY){
                    int width= maxX-minX;
                    int height= maxY-minY;

                    int side= Math.Min(width,height);

                    maxSide=Math.Max(maxSide, side);
                }
            }
        }

        return maxSide*maxSide;
    }
}