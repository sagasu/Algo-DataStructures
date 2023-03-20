using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Can_Place_Flowers
{
    [TestClass]
    public class Can_Place_Flowers
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1));
        }
        
        [TestMethod]
        public void Test1()
        {
            Assert.IsFalse(CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 2));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(CanPlaceFlowers(new int[] { 1, 0, 1, 0, 0 }, 1));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.IsTrue(CanPlaceFlowers(new int[] { 1, 0, 0 }, 1));
        }
        
        [TestMethod]
        public void Test4()
        {
            Assert.IsTrue(CanPlaceFlowers(new int[] { 1, 0, 0, 0, 0, 0, 1 }, 2));
        }
        
        [TestMethod]
        public void Test5()
        {
            Assert.IsTrue(CanPlaceFlowers(new int[] { 0, 0, 1, 0, 1 }, 1));
        }
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            var isPrevFlower = false;
            var result = 0;
            for (var i = 0; i < flowerbed.Length; i++)
                if (flowerbed[i] == 0)
                {
                    if (!isPrevFlower && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                    {
                        isPrevFlower = true;
                        result++;
                    }
                    else isPrevFlower = false;
                } else isPrevFlower = true;
            
            return result >= n;
        }
    }
}
