using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Array_Equal
{
    [TestClass]
    public class Minimum_Operations_to_Make_Array_Equal
    {
        /*
         *  7 5 3 1  
         * 1,3,5,7, 9,11,13,15 //8
         *   x * 2 -1
         *
         *  8 6 4 2
         * 1,3,5,7, 9, 11,13,15,17
         *           
         */

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
            var count = 0;
            var factor = n / 2;
            if (n % 2 == 0)
                for (var i = 1; i <= factor; i++) count += i * 2 - 1;
            else
                for (var i = 1; i <= factor; i++) count += i * 2;

            return count;
        }
    }
}
