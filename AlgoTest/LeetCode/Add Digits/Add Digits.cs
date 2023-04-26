using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Add_Digits
{
    [TestClass]
    public class Add_Digits
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(2, AddDigits(38));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual(0, AddDigits(0));
        
        [TestMethod]
        public void Test3() => Assert.AreEqual(4, AddDigits(13));
        
        [TestMethod]
        public void Test4() => Assert.AreEqual(2, AddDigits(2));

        public int AddDigits(int num)
        {
            var sum = num;
            while (sum >= 10)
            {
                num = sum;
                sum = 0;
                foreach (var n in num.ToString())
                {
                    sum += int.Parse(n.ToString());
                }
            }
            return sum;
        }
    }
}
