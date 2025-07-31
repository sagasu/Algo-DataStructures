using System.Collections.Generic;

namespace AlgoTest.LeetCode.Bitwise_ORs_of_Subarrays;

public class Bitwise_ORs_of_Subarrays
{
    public int SubarrayBitwiseORs(int[] arr) {
        HashSet<int> res = new(), cur = new(), next = new();

        foreach (int x in arr) {
            next.Clear();
            next.Add(x);

            foreach (int y in cur) {
                next.Add(x | y);
            }

            foreach (int y in next) {
                res.Add(y);
            }

            (cur, next) = (next, cur);
        }

        return res.Count;
    }
}