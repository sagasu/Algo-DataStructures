using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_the_Number_of_Good_Subarrays;

public class Count_the_Number_of_Good_Subarrays
{
    public long CountGood(int[] A, int pairs)
    {
        long res = 0;
        var count = new Dictionary<int, int>();
        for (int i = 0, j = 0; j < A.Length; ++j)
        {
            pairs -= count.GetValueOrDefault(A[j]);
            count[A[j]] = count.GetValueOrDefault(A[j]) + 1;
            
            while (pairs <= 0)
            {
                count[A[i]] = count[A[i]] - 1;
                pairs += count[A[i]];
                i++;
            }

            res += i;
        }
        return res;
    }
}