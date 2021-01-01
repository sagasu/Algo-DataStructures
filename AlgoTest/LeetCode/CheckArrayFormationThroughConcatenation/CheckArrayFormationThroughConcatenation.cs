using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CheckArrayFormationThroughConcatenation
{
    [TestClass]
    // This is a wrong approach because I thought that elements in arr can be reordered.
    public class CheckArrayFormationThroughConcatenation
    {
        [TestMethod]
        public void Test1()
        {
            var t1 = new [] {85};
            var t2 = new int[][] { new[] {85} };

            Assert.AreEqual(true, CanFormArray(t1,t2));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t1 = new [] {15,88};
            var t2 = new int[][] { new[] {88}, new[] { 15 } };

            Assert.AreEqual(true, CanFormArray(t1,t2));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t1 = new [] { 49, 18, 16 };
            var t2 = new int[][] { new[] { 16, 18, 49 } };

            Assert.AreEqual(false, CanFormArray(t1,t2));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t1 = new [] { 91, 4, 64, 78 };
            var t2 = new int[][] { new[] { 78 }, new[] { 4, 64 }, new[] { 91 } };

            Assert.AreEqual(false, CanFormArray(t1,t2));
        }

        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            Array.Sort(arr);

            Array.Sort(pieces, ((a, b) => a[0].CompareTo(b[0])));

            var startIndex = 0;
            var current = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] != pieces[startIndex][current]) return false;

                if (current == pieces[startIndex].Length - 1)
                {
                    startIndex += 1;
                    current = 0;
                }
                else
                {
                    current += 1;
                }
            }

            return true;
        }
    }
}
