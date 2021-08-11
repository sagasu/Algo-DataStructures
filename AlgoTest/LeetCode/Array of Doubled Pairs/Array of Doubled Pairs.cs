using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Array_of_Doubled_Pairs
{
    [TestClass]
    public class Array_of_Doubled_Pairs
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {4, -2, 2, -4};
            Assert.AreEqual(true, CanReorderDoubled(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 2, 1, 2, 6 };
            Assert.AreEqual(false, CanReorderDoubled(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 3, 1, 3, 6 };
            Assert.AreEqual(false, CanReorderDoubled(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] { 1, 2, 4, 16, 8, 4 };
            Assert.AreEqual(false, CanReorderDoubled(t));
        }

        public bool CanReorderDoubled(int[] arr)
        {
            Array.Sort(arr, (a, b) => -Math.Abs(a).CompareTo(Math.Abs(b)));

            var dic = new Dictionary<int,int>();
            foreach (var i in arr)
            {
                if (!dic.ContainsKey(i * 2)) dic.Add(i * 2, 0);
                if (!dic.ContainsKey(i)) dic.Add(i,0);

                if (dic[i * 2] > 0) dic[i * 2] -= 1;
                else dic[i] += 1;
            }

            return dic.Values.Sum() == 0;
        }
    }
}
