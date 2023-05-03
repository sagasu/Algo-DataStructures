using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_the_Difference_of_Two_Arrays
{
    [TestClass]
    public class Find_the_Difference_of_Two_Arrays
    {
        [TestMethod]
        public void Test() => Assert.IsTrue(FindDifference(new[]{ 1, 2, 3 }, new []{2,4,6}) is [[1,3], [4,6]]);
        
        [TestMethod]
        public void Test2() => Assert.IsTrue(FindDifference(new[]{ 1, 2, 3, 3 }, new []{ 1, 1, 2, 2 }) is [[3], []]);

        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var s1 = new HashSet<int>();
            var s2 = new HashSet<int>();

            var set1 = new HashSet<int>(nums1);
            var set2 = new HashSet<int>(nums2);
            foreach (var n2 in nums2)
                if(!set1.Contains(n2)) s2.Add(n2);
            
            foreach (var n1 in nums1)
                if(!set2.Contains(n1)) s1.Add(n1);
            
            return new List<IList<int>> { s1.ToList(), s2.ToList() };
        }
    }
}
