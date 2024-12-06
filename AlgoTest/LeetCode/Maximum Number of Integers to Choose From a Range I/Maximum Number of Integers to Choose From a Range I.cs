using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Number_of_Integers_to_Choose_From_a_Range_I;

public class Maximum_Number_of_Integers_to_Choose_From_a_Range_I
{
    public int MaxCount(int[] banned, int n, int maxSum) =>
        new Func<ISet<int>, int>(bannedSet =>
            Enumerable
                .Range(1, n)
                .Where(x => !bannedSet.Contains(x))
                .TakeWhile(x => (maxSum -= x) >= 0)
                .Count()
        )(banned.ToHashSet());
}