using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Advantage_Shuffle
{
    // Out of time solution
    [TestClass]
    public class Advantage_Shuffle_Timeout
    {
        [TestMethod]
        public void Test()
        {
            var t1 = new int[] { 2, 7, 11, 15 };
            var t2 = new int[] { 1, 10, 4, 11 };
            CollectionAssert.AreEqual(new int[]{ 2, 11, 7, 15 }, AdvantageCount(t1, t2));
        }

        [TestMethod]
        public void Test2()
        {
            var t1 = new int[] { 12, 24, 8, 32 };
            var t2 = new int[] { 13, 25, 32, 11 };
            CollectionAssert.AreEqual(new int[] { 24, 32, 8, 12 }, AdvantageCount(t1, t2));
        }


        [TestMethod]
        public void Test3()
        {
            var t1 = new int[] { 15, 15, 4, 5, 0, 1, 7, 10, 3, 1, 10, 10, 8, 2, 3 };
            var t2 = new int[] { 4, 13, 14, 0, 14, 14, 12, 3, 15, 12, 2, 0, 6, 9, 0 };
            CollectionAssert.AreEqual(new int[] { 24, 32, 8, 12 }, AdvantageCount(t1, t2));
        }

        public int[] AdvantageCount(int[] A, int[] B)
        {
            comp = B;
            ret = new int[B.Length];
            BuildPermutations(A, 0);
            return ret;
        }

        private int[] comp;
        private int maxCount;
        private int[] ret;

        public void BuildPermutations(int[] s, int index)
        {
            void Swap(int a, int b)
            {
                var temp = s[a];
                s[a] = s[b];
                s[b] = temp;
            }

            if (index == s.Length - 1)
            {
                var count = 0;
                for(var i =0;i < s.Length; i++)
                {
                    if (s[i] > comp[i]) count += 1;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    Array.Copy(s, ret, s.Length);
                }
                return;
            }

            for (var i = index; i < s.Length; i++)
            {
                Swap(index, i);
                BuildPermutations(s, index + 1);
                Swap(index, i);
            }
        }
    }
}
