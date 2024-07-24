using System.Linq;

namespace AlgoTest.LeetCode.Sort_the_Jumbled_Numbers;

public class Sort_the_Jumbled_Numbers
{
    public int[] SortJumbled(int[] mapping, int[] nums) => nums
        .Select((int original) => {
            if (original < 10)
                return (original, mapping[original]);
            
            var mapped = 0;
            for (int pow = 1, temp = original; temp > 0; pow *= 10, temp /= 10)
                mapped += pow * mapping[(temp % 10)];
            
            return (original, mapped);
        })
        .OrderBy(((int original, int mapped) s) => s.mapped)
        .Select(((int original, int mapped) s) => s.original)
        .ToArray();
}