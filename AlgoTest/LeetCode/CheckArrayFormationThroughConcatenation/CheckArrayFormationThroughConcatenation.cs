using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CheckArrayFormationThroughConcatenation
{
    [TestClass]
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

            Assert.AreEqual(true, CanFormArray(t1,t2));
        }
        
        [TestMethod]
        public void Test5()
        {
            var t1 = new [] { 37, 69, 3, 74, 46 };
            var t2 = new int[][] { new[] { 37, 69, 3, 74, 46 } };

            Assert.AreEqual(true, CanFormArray(t1,t2));
        }

        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            var dic = new Dictionary<int,int>();
            for (var i = 0; i < pieces.Length; i++)
            {
                dic.Add(pieces[i][0], i);
            }

            for (var i = 0; i < arr.Length; i++)
            {
                if (!dic.ContainsKey(arr[i])) return false;
                var piece = pieces[dic[arr[i]]];
                for (var j = 1; j < piece.Length; j++)
                {
                    i += 1;
                    if (arr[i] != piece[j]) return false;
                }
            }

            return true;
        }
    }
}
