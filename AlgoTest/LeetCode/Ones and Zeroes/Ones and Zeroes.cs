using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Ones_and_Zeroes
{
    [TestClass]
    
    public class Ones_and_Zeroes
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] { "10", "0001", "111001", "1", "0" };
            Assert.AreEqual(4, FindMaxForm(t, 5,3));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[] { "10", "0", "1" };
            Assert.AreEqual(2, FindMaxForm(t, 1,1));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new string[] { "10", "0001", "111001", "1", "0" };
            Assert.AreEqual(3, FindMaxForm(t, 4,3));
        }

        public int FindMaxForm(string[] strs, int m, int n)
        {
            var ar = new int?[strs.Length, 101, 101];

            int FindMax(int index, int zeros, int ones)
            {
                if (zeros > m || ones > n) return -1;

                if (index == strs.Length) return 0;

                if(ar[index, zeros, ones].HasValue) return ar[index, zeros, ones].Value;

                var zerosInCurrent = strs[index].Count(x => x == '0');
                var onesInCurrent = strs[index].Length - zerosInCurrent;

                var takenMax = FindMax(index + 1, zeros + zerosInCurrent, ones + onesInCurrent) + 1;
                var notTakenMax = FindMax(index + 1, zeros, ones);

                var max = Math.Max(takenMax, notTakenMax);
                ar[index, zeros, ones] = max;
                return max;
            }

            return FindMax(0, 0, 0);
        }

    }
}
