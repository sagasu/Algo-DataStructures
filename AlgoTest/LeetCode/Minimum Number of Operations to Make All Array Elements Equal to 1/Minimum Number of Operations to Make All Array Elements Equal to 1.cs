using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1;

public class Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1
{
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        int num1 = 0;
        int g = 0;
        foreach (int x in nums) {
            if (x == 1) {
                num1++;
            }
            g = GCD(g, x);
        }
        if (num1 > 0) {
            return n - num1;
        }
        if (g > 1) {
            return -1;
        }

        int minLen = n;
        for (int i = 0; i < n; i++) {
            int currentGcd = 0;
            for (int j = i; j < n; j++) {
                currentGcd = GCD(currentGcd, nums[j]);
                if (currentGcd == 1) {
                    minLen = Math.Min(minLen, j - i + 1);
                    break;
                }
            }
        }
        return minLen + n - 2;
    }

    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}