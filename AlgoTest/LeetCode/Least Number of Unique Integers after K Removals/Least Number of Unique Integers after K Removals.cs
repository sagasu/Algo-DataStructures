using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Least_Number_of_Unique_Integers_after_K_Removals;

public class Least_Number_of_Unique_Integers_after_K_Removals
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k) {
        var map = new Dictionary<int, int>();
        foreach (var i in arr)
        {
            map.TryAdd(i, 0);
            map[i] += 1;
        }

        var frequencies = map.Values.ToList();

        frequencies.Sort();

        var elementsRemoved = 0;

        for (var i = 0; i < frequencies.Count; i++) {
            elementsRemoved += frequencies[i];
            
            if (elementsRemoved > k)
                return frequencies.Count - i;
        }
        
        return 0;
    }
}