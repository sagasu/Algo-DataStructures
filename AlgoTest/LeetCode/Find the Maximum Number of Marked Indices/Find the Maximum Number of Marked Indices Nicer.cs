using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_the_Maximum_Number_of_Marked_Indices
{
    [TestClass]
    public class Find_the_Maximum_Number_of_Marked_Indices_Nicer
    {
        [TestMethod]
        public void Test1()
        {
            var t = new[] { 3, 5, 2, 4 };
            Assert.AreEqual(2, MaxNumOfMarkedIndices(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new[] { 9, 2, 5, 4 };
            Assert.AreEqual(4, MaxNumOfMarkedIndices(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new[] { 7, 6, 8 };
            Assert.AreEqual(0, MaxNumOfMarkedIndices(t));
        }

        public int MaxNumOfMarkedIndices(int[] nums)
        {
            var markedIndices = 0;
            
            Array.Sort(nums);
            var halfN = nums.Length/2;
            var smallNumbers = new Stack<int>(nums.Take(halfN));
            var largeNumbers = new Stack<int>(nums.Skip(halfN));
            
            while (smallNumbers.Count > 0 && largeNumbers.Count > 0)
            {
                if (smallNumbers.Peek() * 2 <= largeNumbers.Peek())
                {
                    markedIndices += 2;
                    smallNumbers.Pop();
                    largeNumbers.Pop();
                    continue;
                }

                smallNumbers.Pop();
            }

            return markedIndices;
        }
    }
}
