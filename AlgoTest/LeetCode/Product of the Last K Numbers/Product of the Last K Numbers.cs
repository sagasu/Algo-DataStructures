using System.Collections.Generic;

namespace AlgoTest.LeetCode.Product_of_the_Last_K_Numbers;

public class ProductOfNumbers
{
    private List<long> _prefixProduct = [1];

    public ProductOfNumbers()
    {
    }

    public void Add(int num)
    {
        if (num == 0)
            _prefixProduct = [1];
        else
            _prefixProduct.Add(_prefixProduct[^1] * num);
    }

    public int GetProduct(int k)
    {
        if (k >= _prefixProduct.Count)
            return 0;

        return (int)(_prefixProduct[^1] / _prefixProduct[_prefixProduct.Count - k - 1]);
    }
}