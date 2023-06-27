using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_K_Pairs_with_Smallest_Sums
{
    [TestClass]
    public class Find_K_Pairs_with_Smallest_Sums
    {
        [TestMethod]
        public void Test() => Assert.IsTrue(KSmallestPairs(new []{ 1, 7, 11 }, new []{2,4,6}, 3) is [[1,2],[1,4],[1,6]]);

        [TestMethod]
        public void Test1() => Assert.IsTrue(KSmallestPairs(new []{ 1, 1, 2 }, new []{ 1, 2, 3 }, 2) is [[1,1],[1,1]]);
        [TestMethod]
        public void Test3() => Assert.IsTrue(KSmallestPairs(new []{ 1, 1, 2 }, new []{ 1, 2, 3 }, 10) is [ [1, 1], [1, 1], [2, 1], [1, 2], [1, 2], [2, 2], [1, 3], [1, 3], [2, 3]]);
        
        [TestMethod]
        public void Test2() => Assert.IsTrue(KSmallestPairs(new []{ 1, 2 }, new []{ 3 }, 3) is [[1,3],[2,3]]);

        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {

            var result = new List<IList<int>>();
            var priorityQueue = new PriorityQueue<(int sum, int position), int>();

            foreach (var x in nums1)
            {
                var sum = x + nums2[0];
                priorityQueue.Enqueue((sum, 0), sum);
            }

            while (k-- > 0 && priorityQueue.Count > 0)
            {
                var (sum, pos) = priorityQueue.Dequeue();

                result.Add(new List<int> { sum - nums2[pos], nums2[pos] });
                
                if (pos + 1 < nums2.Length)
                {
                    var s1 = sum - nums2[pos] + nums2[pos + 1];
                    priorityQueue.Enqueue((s1, pos + 1), s1);
                }
            }

            return result;
        }

        //Wrong solution
        public IList<IList<int>> KSmallestPairs2(int[] nums1, int[] nums2, int k)
        {
            var i1 = 0;
            var i2 = 0;
            var count = 0;
            var pairs = new List<IList<int>>();
            
            while (k > count++)
            {
                pairs.Add(new List<int>() { nums1[i1], nums2[i2] });
                if(i1 == nums1.Length-1 && i2 == nums2.Length-1) break;

                var s1 = i1 + 1 < nums1.Length ? nums1[i1+1] + nums2[i1] : int.MaxValue;
                var s2 = i2 + 1 < nums2.Length ? nums2[i1] + nums2[i2+1] : int.MaxValue;
                if (s1 > s2) i2++;
                else i1++;
            }

            return pairs;
        }
    }
}
