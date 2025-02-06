using System.Collections.Generic;

namespace AlgoTest.LeetCode.Tuple_with_Same_Product;

public class Tuple_with_Same_Product
{
    public int TupleSameProduct(int[] nums) {
        int n = nums.Length, result = 0;
        Dictionary<int, int> productFrequency = new Dictionary<int, int>();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int product = nums[i] * nums[j];

                if (!productFrequency.TryGetValue(product, out var value))
                    productFrequency.Add(product, 1);
                else
                {
                    result += value++;
                    productFrequency[product] = value;
                }
            }
        }

        return result * 8;
    }
}