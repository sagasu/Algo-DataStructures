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
    public class Find_the_Maximum_Number_of_Marked_Indices
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
            if(nums.Length <= 1) return 0;
            var pairs = 0;
            var smallNumbers = new Stack<int>();
            var largeNumbers = new Stack<int>();
            Array.Sort(nums);
            var halfN = nums.Length/2;

            for (var i = 0; i < halfN; i++)
                smallNumbers.Push(nums[i]);

            for (var i = halfN + 1; i < nums.Length; i++)
                largeNumbers.Push(nums[i]);
            
            while (smallNumbers.TryPop(out var small) && largeNumbers.TryPop(out var large))
            {
                while (small * 2 > large)
                {
                    if(!smallNumbers.TryPop(out small)) break;
                }
                pairs += 2;
            }

            return pairs;
        }
    }
}
