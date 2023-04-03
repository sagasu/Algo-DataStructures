using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Boats_to_Save_People
{
    [TestClass]
    public class Boats_to_Save_People
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 2 };
            Assert.AreEqual(1,NumRescueBoats(t,3));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 3, 2, 2, 1 };
            Assert.AreEqual(3,NumRescueBoats(t,3));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 3, 5, 3, 4 };
            Assert.AreEqual(4,NumRescueBoats(t,5));
        }

        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);

            var left = 0;
            var right = people.Length-1;
            var sum = 0;
            while (left < right)
            {
                if (people[right] + people[left] <= limit)
                {
                    sum++;
                    left++;
                }
                else sum += 1;
                
                right--;
            }

            if (left == right) sum++;
            return sum;
        }
    }
}
