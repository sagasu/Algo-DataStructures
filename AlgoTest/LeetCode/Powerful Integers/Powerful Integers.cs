using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Powerful_Integers
{
    [TestClass]
    public class Powerful_Integers
    {

        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(new List<int>{ 2, 3, 4, 5, 7, 9, 10 },PowerfulIntegers(2,3,10).OrderBy(x=>x).ToList());
        }
        
        [TestMethod]
        public void Test2()
        {
            CollectionAssert.AreEqual(new List<int>{ 2, 3,  5, 9 },PowerfulIntegers(2,1,10).OrderBy(x=>x).ToList());
        }
        
        [TestMethod]
        public void Test3()
        {
            CollectionAssert.AreEqual(new List<int>{ 2, 3, 5, 9 },PowerfulIntegers(0,2,10).OrderBy(x=>x).ToList());
        }
        
        [TestMethod]
        public void Test4()
        {
            CollectionAssert.AreEqual(new List<int>{ 1,2 },PowerfulIntegers(1,0,10).OrderBy(x=>x).ToList());
        }

        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            var hashSet = new HashSet<int>();
            var i = 0;
            while(Math.Pow(x, i) <= bound)
            {
                var j = 1;
                var sum = (int)(Math.Pow(x, i) + Math.Pow(y, 0));
                while (sum <= bound)
                {
                    hashSet.Add(sum);
                    var newSum = (int)(Math.Pow(x, i) + Math.Pow(y, j));
                    if (newSum == sum) break;
                    sum = newSum;
                    j += 1;
                }

                if (x == 1 || x == 0) break;
                i += 1;
            }

            return hashSet.ToList();
        }
    }
}
