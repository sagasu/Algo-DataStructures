using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers
{
    [TestClass]
    public class Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers_Faster
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(9,MinPartitions("27346209830709182346"));
            Assert.AreEqual(8,MinPartitions("82734"));
            Assert.AreEqual(3,MinPartitions("32"));
        }

        public int MinPartitions(string n)
        {
            return  int.Parse(n.ToCharArray().Max(x => x).ToString());

        }
    }
}
