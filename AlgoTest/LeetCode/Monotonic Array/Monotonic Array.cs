using System;
using System.Linq;

namespace AlgoTest.LeetCode.Monotonic_Array;

public class Monotonic_Array
{
    public bool IsMonotonic(int[] A) => new Func<int, bool>[] {
                i => A[i] >= A[i + 1],
                i => A[i] <= A[i + 1]
            }.Any(f => Enumerable
                    .Range(0, A.Length - 1)
                    .All(f));
}