using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Distance_in_Arrays;

public class Maximum_Distance_in_Arrays
{
    public int MaxDistance(IList<IList<int>> arrays) 
    {
        var minMaxes = arrays.Select((x, i) => (i, x.Min(), x.Max())).ToArray();

        var min0 = minMaxes.MinBy(x => x.Item2);
        var max0 = minMaxes.Where(x => x.Item1 != min0.Item1).MaxBy(x => x.Item3);
        var d0 = max0.Item3 - min0.Item2;

        var max1 = minMaxes.MaxBy(x => x.Item3);
        var min1 = minMaxes.Where(x => x.Item1 != max1.Item1).MinBy(x => x.Item2);
        var d1 = max1.Item3 - min1.Item2;
        
        return Math.Max(d0, d1);
    }
}