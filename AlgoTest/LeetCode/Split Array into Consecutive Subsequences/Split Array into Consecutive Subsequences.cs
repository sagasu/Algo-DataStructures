using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Split_Array_into_Consecutive_Subsequences
{
    internal class Split_Array_into_Consecutive_Subsequences
    {
        public bool IsPossible(int[] nums)
        {
            var maxSequences = nums.Length / 3;
            var d = new Dictionary<int, PriorityQueue<int, int>>();

            var sequences = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                int order;
                if (!d.ContainsKey(num - 1) || d[num - 1].Count == 0)
                {
                    if (sequences == maxSequences) return false;
                    sequences++;
                    order = 0;
                }
                else
                    order = d[num - 1].Dequeue();
                

                if (!d.ContainsKey(num)) d[num] = new PriorityQueue<int, int>();
                d[num].Enqueue(order + 1, order + 1);
            }

            foreach (var (key, pq) in d)
            {
                while (pq.Count > 0)
                {
                    var elementsCount = pq.Dequeue();
                    if (elementsCount < 3) return false;
                }
            }

            return true;
        }
    }
}
