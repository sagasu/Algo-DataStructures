using System;

namespace AlgoTest.LeetCode.Prime_Subtraction_Operation;

public class Prime_Subtraction_Operation
{
    public bool PrimeSubOperation(int[] nums) {
        var maxElement = int.MinValue;
        foreach (var num in nums) 
            maxElement = Math.Max(maxElement, num);
        
        var previousPrime = new int[maxElement + 1];
        
        for (int i = 2; i <= maxElement; i++) {
            if (IsPrime(i)) 
                previousPrime[i] = i;
            else 
                previousPrime[i] = previousPrime[i - 1];
        }

        for (int i = 0; i < nums.Length; i++) {
            int bound;
            if (i == 0) 
                bound = nums[0];
            else 
                bound = nums[i] - nums[i - 1];
            
            if (bound <= 0) 
                return false;
            
            var largestPrime = previousPrime[bound - 1];
            nums[i] -= largestPrime;
        }

        return true;
    }
    public bool IsPrime(int n) {
        if (n <= 1) return false;
        for (var i = 2; i * i <= n; i++) 
            if (n % i == 0) 
                return false;
        
        return true;
    }
}