using System;

namespace AlgoTest.LeetCode.Check_if_Number_is_a_Sum_of_Powers_of_Three;

public class Check_if_Number_is_a_Sum_of_Powers_of_Three
{
    public bool CheckPowersOfThree(int n) {
        while(n>0) {
            n = Math.DivRem(n, 3, out int remainder);
            if(remainder>1) return false;
        }
        return true;
    }
}