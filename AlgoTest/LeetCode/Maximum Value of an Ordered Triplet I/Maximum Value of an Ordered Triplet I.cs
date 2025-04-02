using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Value_of_an_Ordered_Triplet_I;

public class Maximum_Value_of_an_Ordered_Triplet_I
{
    public long MaximumTripletValue(int[] nums) => 
        nums.Aggregate((0L, 0L, 0L), (item, num) =>
            {
                item.Item1 = Math.Max(item.Item1, item.Item2 * num);
                item.Item2 = Math.Max(item.Item2, item.Item3 - num);
                item.Item3 = Math.Max(item.Item3, num);
                return item;
            }, 
            res => res.Item1);
}
}