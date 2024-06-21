using System;
using System.Linq;

namespace AlgoTest.LeetCode.Grumpy_Bookstore_Owner;

public class Grumpy_Bookstore_Owner
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        var result = customers
            .Zip(grumpy, (c, g) => c * (1 - g))
            .Sum();
        
        if (minutes <= 0)
            return result;
        
        if (minutes >= grumpy.Length)
            return customers.Sum();
        
        result += customers
            .Zip(grumpy, (c, g) => c * g)
            .Take(minutes)
            .Sum();
            
        var current = result;
        
        for (var i = minutes; i < grumpy.Length; ++i) 
            result = Math.Max(result, current += grumpy[i] * customers[i] - grumpy[i - minutes] * customers[i - minutes]);
                
        return result;
    }
}