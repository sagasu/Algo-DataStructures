using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Time_Needed_to_Inform_All_Employees
{
    // This will: Time Limit Exceeded, because we are iterating entire array over and over again, that is why it is better to construct a tree and just traverse tree as in other solution
    [TestClass]
    public class Time_Needed_to_Inform_All_EmployeesSolution
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(0,NumOfMinutes(1, 0, new[] { -1 }, new[] { 0 }));

        [TestMethod]
        public void Test1() => Assert.AreEqual(6,NumOfMinutes(6, 2, new[] { 2, 2, -1, 2, 2, 2 }, new[] { 0, 0, 6, 0, 0, 0 }));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual(12,NumOfMinutes(6, 2, new[] { 2, 0, -1, 2, 2, 2 }, new[] { 0, 6, 6, 0, 0, 0 }));

        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            int DFS(int managerId, int time)
            {
                var max = time;
                for (var i = 0; i < n; i++)
                {
                    if (manager[i] == managerId)
                    {
                        max = Math.Max(max, DFS(i, informTime[i] + time));
                    }
                }

                return max;
            }

            return DFS(headID, informTime[headID]);
        }
    }
}
