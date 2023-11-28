using System.Collections.Generic;

namespace AlgoTest.LeetCode.Number_of_Ways_to_Divide_a_Long_Corridor;

public class Number_of_Ways_to_Divide_a_Long_Corridor
{
    const int MOD = 1_000_000_007;
    
    public int NumberOfWays(string corridor) {
        var cache = new Dictionary<(int,int), int>();

        return Count(0, 0, corridor, cache);
    }
    
    private int Count(int index, int seats, string corridor, IDictionary<(int,int), int> cache) {
        
        if (index == corridor.Length)
            return seats == 2 ? 1 : 0;
        
        if (cache.ContainsKey((index, seats)))
            return cache[(index, seats)];
        

        var result = 0;

        if (seats == 2)
        {
            result = corridor[index] switch
            {
                'S' => Count(index + 1, 1, corridor, cache),
                _ => (Count(index + 1, 0, corridor, cache) + Count(index + 1, 2, corridor, cache)) % MOD
            };
        } else
            result = corridor[index] == 'S' ? Count(index + 1, seats + 1, corridor, cache) : Count(index + 1, seats, corridor, cache);
        

        cache.Add((index, seats), result);
        return result;
    }
}