using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Make_Array_Continuous;

public class Minimum_Number_of_Operations_to_Make_Array_Continuous
{
    public int MinOperations(int[] nums) {
        var n = nums.Length;
        if (n == 1) return 0;

        var unique = nums.Distinct().OrderBy(x => x).ToArray();

        if (n == unique.Length && unique[n-1] - unique[0] == n - 1) {
            return 0;
        }

        var res = n;
        for (var i = 0; i < unique.Length - 1; i++) {
            var j = i + 1;
            var left = unique[i];
            var right = left + n - 1;
            while (j < unique.Length && unique[j] <= right) {
                j++;
            }
            
            res = Math.Min(n - (j-i), res);
            
        }
        
        return res;
    }
}