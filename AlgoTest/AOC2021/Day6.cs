using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2021
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        public void Test1()
        {
            var data = realData.ToList();
            var ndData = new List<int>();
            for (var day = 0; day < 80; day++){
                for (var i = 0; i < data.Count; i++)
                {
                    if (data[i] == 0)
                    {
                        ndData.Add(6);
                        ndData.Add(8);
                    }
                    else ndData.Add(data[i] - 1);


                }

                data = ndData;
                ndData = new List<int>();
            }

            Assert.AreEqual(5934, data.Count);
        }

        [TestMethod]
        public void Test2()
        {
            var data = realData.ToList();

            var dic = new Dictionary<int,long>();

            for (int i = 0; i < data.Count; i++)
            {
                if(!dic.TryAdd(data[i], 1)) dic[data[i]] +=1 ;
            }

            var dic2 = new Dictionary<int,long>();
            for (var day = 0; day < 256; day++)
            {
                foreach (var key in dic.Keys)
                {
                    if (key >= 1)
                    {
                        if (!dic2.TryAdd(key - 1, dic[key])) dic2[key - 1] += dic[key];
                    }
                    else
                    {
                        if (!dic2.TryAdd(6, dic[0])) dic2[6] += dic[0];
                        dic2.Add(8, dic[0]);
                    }
                }

                dic = dic2;
                dic2 = new Dictionary<int, long>();
            }

            long sum = 0;
            foreach (var key in dic.Keys)
            {
                sum += dic[key];
            }

            Assert.AreEqual(1686252324092, sum);
        }



        private int[] testData = new[] {3, 4, 3, 1, 2};

        private int[] realData = new[] { 1, 1, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 3, 1, 5, 1, 4, 1, 5, 1, 2, 5, 1, 1, 1, 1, 3, 1, 4, 5, 1, 1, 2, 1, 1, 1, 2, 4, 3, 2, 1, 1, 2, 1, 5, 4, 4, 1, 4, 1, 1, 1, 4, 1, 3, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 5, 4, 4, 2, 4, 5, 2, 1, 5, 3, 1, 3, 3, 1, 1, 5, 4, 1, 1, 3, 5, 1, 1, 1, 4, 4, 2, 4, 1, 1, 4, 1, 1, 2, 1, 1, 1, 2, 1, 5, 2, 5, 1, 1, 1, 4, 1, 2, 1, 1, 1, 2, 2, 1, 3, 1, 4, 4, 1, 1, 3, 1, 4, 1, 1, 1, 2, 5, 5, 1, 4, 1, 4, 4, 1, 4, 1, 2, 4, 1, 1, 4, 1, 3, 4, 4, 1, 1, 5, 3, 1, 1, 5, 1, 3, 4, 2, 1, 3, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 5, 1, 1, 1, 1, 3, 1, 1, 5, 1, 1, 4, 1, 1, 3, 1, 1, 5, 2, 1, 4, 4, 1, 4, 1, 2, 1, 1, 1, 1, 2, 1, 4, 1, 1, 2, 5, 1, 4, 4, 1, 1, 1, 4, 1, 1, 1, 5, 3, 1, 4, 1, 4, 1, 1, 3, 5, 3, 5, 5, 5, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 4, 2, 1, 1, 4, 5, 3, 1, 1, 5, 5, 1, 1, 2, 1, 4, 1, 3, 5, 1, 1, 1, 5, 2, 2, 1, 4, 2, 1, 1, 4, 1, 3, 1, 1, 1, 3, 1, 5, 1, 5, 1, 1, 4, 1, 2, 1 };
    }



    
}
