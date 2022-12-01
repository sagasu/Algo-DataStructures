using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.AOC2022
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace AlgoTest.AOC2021
    {
        [TestClass]
        public class Day1
        {
            [TestMethod]
            public void Test1()
            {
                var count = 0;
                for (var i = 1; i < data.Length; i++)
                    if (data[i] > data[i - 1]) count += 1;

                Assert.AreEqual(1529, count);
            }

            [TestMethod]
            public void Test2()
            {
                var count = 0;
                var prev = data[0] + data[1] + data[2];
                for (var i = 1; i < data.Length - 2; i++)
                {
                    var sum = data[i] + data[i + 1] + data[i + 2];

                    if (sum > prev) count += 1;
                    prev = sum;
                }

                Assert.AreEqual(1567, count);
            }

            int[] data = new int[]
            {
                
            };
        }
    }

}
