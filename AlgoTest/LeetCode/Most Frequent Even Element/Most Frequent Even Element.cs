using System.Linq;

namespace AlgoTest.LeetCode.Most_Frequent_Even_Element;

public class Most_Frequent_Even_Element
{
    public int MostFrequentEven(int[] nums)
        => nums
            .GroupBy(n => n)
            .OrderBy(n => n.Count())
            .ThenByDescending(n => n.Key)
            .Select(n => n.Key)
            .LastOrDefault(n => (n & 1) == 0, -1);
}