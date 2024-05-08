using System.Linq;

namespace AlgoTest.LeetCode.Relative_Ranks;

public class Relative_Ranks
{
    public string[] FindRelativeRanks(int[] score)
        => score
            .Select((n, i) => new{n, i})
            .OrderBy(x => -x.n)
            .Select((x, i) => 
                new
                {
                    i = x.i, 
                    p = i <= 2 ? (i == 0 ? "Gold" : i == 1 ? "Silver" : "Bronze") + " Medal" : 
                        $"{i+1}"
                })
            .OrderBy(x => x.i)
            .Select(x => x.p).ToArray(); 
}