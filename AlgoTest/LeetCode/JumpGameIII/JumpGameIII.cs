using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.JumpGameIII
{
    [TestClass]
    public class JumpGameIII
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {4, 2, 3, 0, 3, 1, 2};
            Assert.AreEqual(true, CanReach(t, 5));
        }


        [TestMethod]
        public void Test1()
        {
            var t = new int[] { 4, 2, 3, 0, 3, 1, 2 };
            Assert.AreEqual(true, CanReach(t, 0));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 3, 0, 2, 1, 2 };
            Assert.AreEqual(false, CanReach(t, 2));
        }

        public bool CanReach(int[] arr, int start)
        {
            cache = new bool?[arr.Length];
            return CanReachDFS(arr, start, new List<int>());
        }

        bool?[] cache;

        public bool CanReachDFS(int[] arr, int start, List<int> used)
        {
            if (start < 0 || start >= arr.Length) return false;

            if (cache[start] != null) return cache[start].Value;

            if (arr[start] == 0)
            {
                cache[start] = true;
                return true;
            }

            if (used.Contains(start)) return false;

            used.Add(start);
            if(CanReachDFS(arr, start + arr[start], used) ||
               CanReachDFS(arr, start - arr[start], used))
                    return true;

            used.RemoveAt(used.Count-1);

            cache[start] = false;
            return false;
        }
    }
}
