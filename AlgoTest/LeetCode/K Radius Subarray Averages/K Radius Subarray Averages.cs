using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.K_Radius_Subarray_Averages
{
    [TestClass]
    public class K_Radius_Subarray_Averages
    {

        [TestMethod]
        public void Test() => Assert.IsTrue(GetAverages(new[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 }, 3) is [-1, -1, -1, 5, 4, 4, -1, -1, -1]);

        [TestMethod]
        public void Test1() => Assert.IsTrue(GetAverages(new[] { 10000 }, 8) is [-1]);

        [TestMethod]
        public void Test2() => Assert.IsTrue(GetAverages(new[] { 100000 }, 0) is [100000]);

        public int[] GetAverages(int[] nums, int k)
        {
            var avr = new int[nums.Length];
            Array.Fill(avr, -1);

            if (nums.Length < k) return avr;

            var chunkSize = 2 * k + 1;
            var sum = nums.Take(chunkSize - 1).Aggregate(0L, (sum, next) => sum + next);
            for (var i = k; i < nums.Length - k; i++)
            {
                sum += nums[i + k];
                avr[i] = Convert.ToInt32(sum / chunkSize);
                sum -= nums[i - k];
            }
            
            return avr;
        }
        
        public int[] GetAverages2(int[] nums, int k)
        {
            var avr = new int[nums.Length];
            Array.Fill(avr, -1);

            if (nums.Length < k) return avr;
            
            for (var i = k; i < nums.Length-k; i++)
                avr[i] = nums.Take(new Range(i - k, i + k + 1)).Sum() / (k * 2 + 1);
            
            return avr;
        }
        
        public int[] GetAverages3(int[] nums, int k)
        {
            var avr = new int[nums.Length];
            if (nums.Length < k)
            {
                Array.Fill(avr, -1);
                return avr;
            }

            
            Array.Fill(avr,-1,0,k);
            Array.Fill(avr,-1,nums.Length-k,k);

            for (var i = k; i < nums.Length-k; i++)
                avr[i] = nums.Take(new Range(i - k, i + k + 1)).Sum() / (k * 2 + 1);
            
            return avr;
        }
    }
}
