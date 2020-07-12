using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PerfectSquares
{
    [TestClass]
    public class PerfectSquares
    {
        [TestMethod]
        public void Test()
        {
            //Assert.AreEqual(3,NumSquares(12));
            Assert.AreEqual(4,NumSquares(47));
        }

        public int NumSquares(int n)
        {
            var i = 1;
            while (true)
            {
                var square = i * i;
                if (square > n)
                    break;
                perfectSquares.Add(square);
                i += 1;
            }
            FindNumSquares(n,0,0);
            return min;
        }

        private int min = int.MaxValue;
        public void FindNumSquares(int n, int count, int sum)
        {
            if (sum > n)
                return;

            if (n == sum)
            {
                if (count < min)
                    min = count;
                return;
            }

            for (var i = perfectSquares.Count-1; i >= 0; i--)
            {
                if (sum > n || count + 1 > min)
                    return;

                FindNumSquares(n, count + 1, sum + perfectSquares[i]);
            }
        }

        List<int> perfectSquares = new List<int>();
    }
}
