using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.QueueReconstructionByHeight
{
    [TestClass]
    public class QueueReconstructionByHeight
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new[] {7, 0}, new[] {4, 4}, new[] {7, 1}, new[] {5, 0}, new[] {6, 1}, new[] {5, 2}};
            ReconstructQueue(t);
        }

        public int[][] ReconstructQueue(int[][] people)
        {
            var sorted = people.OrderByDescending(x => x[0]).ThenBy(x => x[1]);
            var ret = new List<int[]>(people.Length);
            foreach (var elements in sorted)
            {
                ret.Insert(elements[1], elements);
            }

            return ret.ToArray();
        }
    }
}
