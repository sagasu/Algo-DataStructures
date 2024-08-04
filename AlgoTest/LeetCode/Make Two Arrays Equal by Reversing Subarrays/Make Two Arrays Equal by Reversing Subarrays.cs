using System;
using System.Linq;

namespace AlgoTest.LeetCode.Make_Two_Arrays_Equal_by_Reversing_Subarrays;

public class Make_Two_Arrays_Equal_by_Reversing_Subarrays
{
    public bool CanBeEqual(int[] target, int[] arr) {
        Array.Sort(target);
        Array.Sort(arr);
        return !target.Where((t, i) => t != arr[i]).Any();
    }
}