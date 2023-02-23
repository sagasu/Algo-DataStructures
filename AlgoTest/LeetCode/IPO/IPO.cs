using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.IPO
{
    [TestClass]
    public class IPO
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, FindMaximizedCapital(2, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 1 }));
        }
        //time limit exceeded 
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            var profitsWithCapital = capital.Zip(profits);

            var profitable = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => -1*x.CompareTo(y)));
            profitable.EnqueueRange(profitsWithCapital);
            
            var tooCostly = new List<(int Element, int Priority)>();
            while (k > 0)
            {
                profitable.TryDequeue(out var cost, out var profit);

                while (cost > w)
                {
                    tooCostly.Add((cost, profit));
                    profitable.TryDequeue(out cost, out profit);
                }

                w += profit;
                profitable.EnqueueRange(tooCostly);
                tooCostly.Clear();
                k -= 1;
            }

            return w;
        }
    }
}
