using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Array_Equal2
{
    [TestClass]
    public class Minimum_Operations_to_Make_Array_Equal
    {
        
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, MinOperations(4));
            Assert.AreEqual(2, MinOperations(3));
            Assert.AreEqual(6, MinOperations(5));
            Assert.AreEqual(9, MinOperations(6));
            Assert.AreEqual(16, MinOperations(8));
            Assert.AreEqual(20, MinOperations(9));
            Assert.AreEqual(0, MinOperations(1));
            Assert.AreEqual(1, MinOperations(2));
        }

        public int MinOperations(int n)
        {
            var factor = n / 2;
            return factor * (n - factor);
        }
    }
}
