using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box;

public class Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box
{
    public int[] MinOperations(string boxes) {
        var res=new int[boxes.Length];
        var sum=0;
        for(var i=0;i<boxes.Length;i++){
            sum=0;
            for(var j=0;j<boxes.Length;j++)
                if(j!=i && boxes[j]=='1')
                    sum+=(int)Math.Abs(i-j);
            
            res[i]=sum;
        }
        return res;
    }
}