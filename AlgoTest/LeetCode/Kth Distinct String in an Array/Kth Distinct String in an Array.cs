using System.Linq;

namespace AlgoTest.LeetCode.Kth_Distinct_String_in_an_Array;

public class Kth_Distinct_String_in_an_Array
{
    public string KthDistinct(string[] arr, int k)
    {
        var map = arr.GroupBy(a => a).ToDictionary(g => g.Key, g => g.Count());

        foreach (var a in arr)
            if (map[a] == 1 && --k == 0)
                return a;

        return string.Empty;
    }
}