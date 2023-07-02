using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Number_of_Achievable_Transfer_Requests
{
    internal class Maximum_Number_of_Achievable_Transfer_Requests
    {
        public int MaximumRequests(int n, int[][] requests) => GetMaxRequests(n, 0, requests, new int[n], 0);
        
        private int GetMaxRequests(int n, int start, int[][] requests, int[] changes, int count)
        {
            if (start == requests.Length)
            {
                for (var i = 0; i < n; i++)
                    if (changes[i] != 0)
                        return 0;
                
                return count;
            }
            
            changes[requests[start][0]]--;
            changes[requests[start][1]]++;
            var consider = GetMaxRequests(n, start + 1, requests, changes, count + 1);
            
            changes[requests[start][0]]++;
            changes[requests[start][1]]--;
            var notconsider = GetMaxRequests(n, start + 1, requests, changes, count);

            return Math.Max(consider, notconsider);
        }
    }
}
