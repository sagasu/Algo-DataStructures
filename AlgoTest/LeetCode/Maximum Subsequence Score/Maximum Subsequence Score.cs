using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Subsequence_Score
{
    internal class Maximum_Subsequence_Score
    {
        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            var n = nums2.Length;
            var nums = new int[n][];

            for (var i = 0; i < n; i++)
            {
                nums[i] = new int[2];
                nums[i][0] = nums1[i];
                nums[i][1] = nums2[i];
            }
            Array.Sort(nums, (x, y) => y[1].CompareTo(x[1]));

            var pq = new PriorityQueue<int, int>();
            long sum = 0;

            for (var i = 0; i < k; i++)
            {
                sum += nums[i][0];
                pq.Enqueue(nums[i][0], nums[i][0]);
            }
            var ans = sum * nums[k - 1][1];
            
            for (var i = k; i < n; i++)
            {
                sum += nums[i][0] - pq.Dequeue();
                pq.Enqueue(nums[i][0], nums[i][0]);

                ans = Math.Max(ans, sum * nums[i][1]);
            }

            return ans;
        }
    }
}
