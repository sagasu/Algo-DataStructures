namespace AlgoTest.LeetCode.Count_Good_Triplets_in_an_Array;

public class Count_Good_Triplets_in_an_Array
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] pos = new int[n];
        for (int i = 0; i < n; i++)
        {
            pos[nums2[i]] = i;
        }

        // [8,2,3,4,9]
        // [3,9,8,2,4]
        int[] mapped = new int[n];
        for (int i = 0; i < n; i++)
        {
            mapped[i] = pos[nums1[i]];
        }

        long[] leftSmaller = new long[n];
        long[] rightLarger = new long[n];
        FenwickTree leftTree = new FenwickTree(n);
        FenwickTree rightTree = new FenwickTree(n);

        for (int i = 0; i < n; i++)
        {
            rightTree.Add(mapped[i], 1);
        }

        for (int i = 0; i < n; i++)
        {
            rightTree.Add(mapped[i], -1);
            leftSmaller[i] = leftTree.Query(mapped[i] - 1);
            rightLarger[i] = rightTree.Query(n - 1) - rightTree.Query(mapped[i]);
            leftTree.Add(mapped[i], 1);
        }

        long result = 0;
        for (int i = 0; i < n; i++)
        {
            result += leftSmaller[i] * rightLarger[i];
        }

        return result;
    }

    private class FenwickTree(int size)
    {
        private readonly long[] _tree = new long[size + 1];

        public void Add(int index, long value)
        {
            index++;
            while (index < _tree.Length)
            {
                _tree[index] += value;
                index += index & -index;
            }
        }

        public long Query(int index)
        {
            index++;
            long sum = 0;
            while (index > 0)
            {
                sum += _tree[index];
                index -= index & -index;
            }

            return sum;
        }
    }
}