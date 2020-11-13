using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CourseScheduleII
{
    [TestClass]
    public class CourseScheduleII
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new int[] {1, 0}};
            FindOrder(2, t);
        }

        // Topological sort implementation with adj matrix and stack, going for DFS approach.

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var adj = new HashSet<int>[numCourses];
            //var depNodes = new int[numCourses];

            for (var i = 0; i < numCourses; i++)
            {
                adj[i] = new HashSet<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                var req = prerequisites[i][1];
                var course= prerequisites[i][0];
                adj[course].Add(req);
                //depNodes[req] += 1;
            }

            var stack = new Stack<int>();
            var order = new List<int>(numCourses);
            var nextDepth = 1;
            for (var i = 0; i < numCourses; i++)
            {
                if (adj[i].Count == 0)
                {
                    stack.Push(i);
                }
            }

            if (stack.Count == 0)
                return new int[0];

            while(stack.Count > 0)
            {
                var node = stack.Pop();
                order.Add(node);

                foreach (var prereq in adj[node])
                {
                    if (order.Contains(prereq))
                        continue;

                    stack.Push(prereq);
                }

                for(var i =0;i< adj.Length;i++)
                {
                    if (adj[i].Count == nextDepth && !order.Contains(i))
                    {
                        stack.Push(i);
                    }
                }

                nextDepth += 1;
            }

            if(order.Count != numCourses)
                return new int[0];

            return order.ToArray();
        }
    }
}
