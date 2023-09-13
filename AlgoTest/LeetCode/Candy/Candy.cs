using System;
using System.Linq;

namespace AlgoTest.LeetCode.Candy;

public class CandySolution
{
    public int Candy(int[] ratings) {
        var n = ratings.Length;
        var candies = Enumerable.Repeat(1, n).ToArray();
        for (var i = 1; i < n; i++) 
            if (ratings[i] > ratings[i - 1]) 
                candies[i] = candies[i - 1] + 1;
        
        for (var i = n - 2; i >= 0; i--) 
            if (ratings[i] > ratings[i + 1]) 
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
        
        return candies.Sum();
    }
}