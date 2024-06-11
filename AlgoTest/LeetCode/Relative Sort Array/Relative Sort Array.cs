using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Relative_Sort_Array;

public class Relative_Sort_Array
{
    public int[] RelativeSortArray(int[] A, int[] B) =>
        new Func<Dictionary<int, int>, int[]>(m => A
            .OrderBy(x => m.GetValueOrDefault(x, A.Length))
            .ThenBy(x => x)
            .ToArray()
        )(B.Select((x, i) => (x, i)).ToDictionary(t => t.x, t => t.i));
}