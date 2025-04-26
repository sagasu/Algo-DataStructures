using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Array_Values_Equal_to_K;

public class Minimum_Operations_to_Make_Array_Values_Equal_to_K
{
    public int MinOperations(int[] nums, int k) {
        var st = new HashSet<int>();
        foreach (int x in nums) {
            if (x < k) {
                return -1;
            } else if (x > k) {
                st.Add(x);
            }
        }
        return st.Count;
    }
}