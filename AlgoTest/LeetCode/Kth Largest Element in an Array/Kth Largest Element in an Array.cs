using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Kth_Largest_Element_in_an_Array
{
    internal class Kth_Largest_Element_in_an_Array
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                queue.Enqueue(num, num);
                if (queue.Count <= k) continue;
                queue.Dequeue();
            }

            return queue.Peek();
        }
    }
}
