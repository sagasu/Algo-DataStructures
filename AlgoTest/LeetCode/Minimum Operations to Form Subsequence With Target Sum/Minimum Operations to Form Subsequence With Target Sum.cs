using System;
using System.Collections.Generic;
using System.Numerics;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Form_Subsequence_With_Target_Sum;

public class Minimum_Operations_to_Form_Subsequence_With_Target_Sum
{
    public int MinOperations(IList<int> nums, int target) {
        int[] count = new int[31];
        
        foreach (var num in nums) {
            int exp = BitOperations.Log2((uint)num);
            count[exp]++;
        }

        long total = 0;
        for (int i = 0; i < 31; i++) {
            total += (long)count[i] * (1L << i);
        }
        if (total < target) {
            return -1;
        }

        int operations = 0;
        for (int k = 0; k < 31; k++) {
            int required = (target & (1 << k)) != 0 ? 1 : 0;
            int currentCount = count[k];
            
            int operationsAdd = 0;

            if (currentCount < required) {
                int deficit = required - currentCount;
                int m = k + 1;
                
                while (deficit > 0 && m < 31) {
                    if (count[m] == 0) {
                        m++;
                        continue;
                    }

                    int contribution = 1 << (m - k);
                    int available = count[m];
                    int maxTake = (deficit + contribution - 1) / contribution;
                    maxTake = Math.Min(available, maxTake);

                    deficit -= maxTake * contribution;
                    operationsAdd += maxTake * (m - k);
                    count[m] -= maxTake;
                    currentCount += maxTake * contribution;
                    m++;
                }

                if (deficit > 0) {
                    return -1;
                }

                count[k] = currentCount;
            }

            int excess = count[k] - required;
            count[k] = excess % 2;
            int carry = excess / 2;
            if (k + 1 < 31) {
                count[k + 1] += carry;
            }

            operations += operationsAdd;
        }

        return operations;
    }
}