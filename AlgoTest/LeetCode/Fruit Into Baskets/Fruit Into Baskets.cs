using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Fruit_Into_Baskets
{

    [TestClass]
    public class Fruit_Into_Baskets
    {

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(3, TotalFruit(new int[] { 1, 2, 1 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(3, TotalFruit(new int[] { 0, 1, 2, 2 }));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(4, TotalFruit(new int[] { 1, 2, 3, 2, 2 }));
        }
        public int TotalFruit(int[] fruits)
        {
            var count = int.MinValue;
            var map = new Dictionary<int, int>();
            var start = 0;
            var end = 0;

            while (end < fruits.Length)
            {
                if (!map.ContainsKey(fruits[end]))
                    map[fruits[end]] = 0;

                ++map[fruits[end]];

                while (map.Count > 2)
                {
                    --map[fruits[start]];

                    if (map[fruits[start]] <= 0)
                        map.Remove(fruits[start]);

                    ++start;
                }

                count = Math.Max(end - start + 1, count);

                ++end;
            }

            return count;
        }

    }
}
