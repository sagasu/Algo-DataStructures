using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.IPO
{
    internal class IPO
    {
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            var projects = new List<(int capital, int profit)>();

            for (var i = 0; i < profits.Length; i++)
                projects.Add((capital[i], profits[i]));
            
            projects = projects.OrderBy(x => x.capital).ToList();

            var queue = new PriorityQueue<int, int>();

            var completedProjects = 0;

            while (k-- > 0)
            {
                while (completedProjects < projects.Count && projects[completedProjects].capital <= w)
                {
                    var profit = projects[completedProjects].profit;
                    // `int.MaxValue - profit` is a hack to reverse the order of priority queue, because the lowest number is on the top, and we want it to be otherwise around.
                    queue.Enqueue(profit, int.MaxValue - profit);
                    completedProjects++;
                }

                if (queue.Count == 0) break;
                
                w += queue.Dequeue();
            }

            return w;
        }
    }
}
