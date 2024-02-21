using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Convert_an_Array_Into_a_2D_Array_With_Conditions;

public class Convert_an_Array_Into_a_2D_Array_With_Conditions
{
    public IList<IList<int>> FindMatrix(int[] nums) {
        List<HashSet<int>> unique = new();

        foreach (var item in nums) {
            var found = false;

            foreach (var hs in unique.Where(hs => found = hs.Add(item)))
                break;

            if (!found)
                unique.Add(new HashSet<int> { item });
        }     

        return unique
            .Select(hs => hs.ToList() as IList<int>)
            .ToList();
    }
}