using System.Collections.Generic;

namespace AlgoTest.LeetCode.Replace_Non_Coprime_Numbers_in_Array;

public class Replace_Non_Coprime_Numbers_in_Array
{
    public IList<int> ReplaceNonCoprimes(int[] nums) {
        var result = new List<int>();

        foreach (int num in nums) {
            result.Add(num);
            while (result.Count > 1) {
                int a = result[result.Count - 1];
                int b = result[result.Count - 2];
                int g = GCD(a, b);
                if (g > 1) {
                    result.RemoveAt(result.Count - 1);
                    result.RemoveAt(result.Count - 1);
                    long lcm = (long)a / g * b; 
                    result.Add((int)lcm);
                } else {
                    break;
                }
            }
        }

        return result;
    }

    private int GCD(int a, int b) {
        while (b != 0) {
            int tmp = b;
            b = a % b;
            a = tmp;
        }
        return a;
    }
}