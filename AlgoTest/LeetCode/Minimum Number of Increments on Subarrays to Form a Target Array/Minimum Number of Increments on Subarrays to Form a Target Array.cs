using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Increments_on_Subarrays_to_Form_a_Target_Array;

public class Minimum_Number_of_Increments_on_Subarrays_to_Form_a_Target_Array
{
    public int MinNumberOperations(int[] target)
    {
        int N = target.Length;
        int Ans = target[0];

        for (int i = 1; i < N; ++i)
            Ans += Math.Max(target[i] - target[i - 1], 0);
        
        return Ans;
    }
}