using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Kth_Largest_Element_in_a_Stream
{
    internal class KthLargest
    {
        PriorityQueue<int, int> pq = new();
        int k = 0;
        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            foreach (var num in nums)
                this.Add(num);
        }

        public int Add(int val)
        {
            pq.Enqueue(val, val);
            if (pq.Count > k) pq.Dequeue();
            return pq.Peek();
        }
    }
}
