using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Triangle
{
    [TestClass]
    public class Triangle
    {
        [TestMethod]
        public void Test()
        {
            var t = new List<IList<int>>{ new List<int> { 2}, new List<int> { 3, 4},new List<int> { 6, 5, 7},new List<int> { 4, 1, 8, 3}};
            Assert.AreEqual(11, MinimumTotal(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new List<IList<int>>{ new List<int> { 1}};
            Assert.AreEqual(1, MinimumTotal(t));
        }

        /*
         *  2
           3 4             1*2-2
          6 5 7            *2*2-3
         4 1 8 3           *3*2-4
        1 2 3 4 5           4*2-5
         *
         *
         */

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var min = Int32.MaxValue;

            void MinTraverse(int index, int position, int sum)
            {
                if (index == triangle.Count)
                {
                    min = Math.Min(min, sum);
                    return;
                }

                var current = triangle[index][position];

                position += 1;
                var nextPosition = position * 2 - position - 1;
                sum += current;
                MinTraverse(index+1, nextPosition, sum);
                MinTraverse(index+1, nextPosition+1, sum);
            }

            MinTraverse(0, 0,0);

            return min;
        }
    }
}
