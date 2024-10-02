using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Rank_Transform_of_an_Array;

public class Rank_Transform_of_an_Array
{
    public int[] ArrayRankTransform(int[] A) =>
        new Func<Dictionary<int, int>, int[]>(M =>
            A.Select(x => M[x]).ToArray()
        )(A
            .Distinct()
            .Order()
            .Select((x, i) => (x, i))
            .ToDictionary(t => t.x, t => t.i + 1)
        );
}