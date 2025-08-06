using System;

namespace AlgoTest.LeetCode.Fruits_Into_Baskets_III;

public class Fruits_Into_Baskets_III
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.Length;
        int size = 1;
        while (size < n) size <<= 1;
        int[] tree = new int[2 * size];

        for (int i = 0; i < n; i++)
            tree[size + i] = baskets[i];
        for (int i = size - 1; i > 0; i--)
            tree[i] = Math.Max(tree[i << 1], tree[(i << 1) | 1]);

        int unplaced = 0;
        foreach (int qty in fruits) {
            int idx = Query(qty);
            if (idx < 0)
                unplaced++;
            else
                Update(idx);
        }
        return unplaced;

        int Query(int x) {
            if (tree[1] < x) return -1;
            int k = 1;
            while (k < size) {
                if (tree[k << 1] >= x)
                    k = k << 1;
                else
                    k = (k << 1) | 1;
            }
            return k - size;
        }

        void Update(int pos) {
            int k = pos + size;
            tree[k] = 0;
            for (k >>= 1; k > 0; k >>= 1)
                tree[k] = Math.Max(tree[k << 1], tree[(k << 1) | 1]);
        }
    }
}