using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.TopKFrequentElements
{
    [TestClass]
    public class TopKFrequentElements
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 1, 1, 2, 2, 3 };
            TopKFrequent(t, 2);
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length <= k)
                return nums;

            var freq = new Dictionary<int, int>();
            var maxFreq = 1;
            for(var i = 0; i < nums.Length; i++) {
                var key = nums[i];
                if (freq.ContainsKey(key))
                {
                    freq[key] += 1;
                    if (maxFreq < freq[key])
                        maxFreq = freq[key];
                }
                else freq.Add(key, 1);
                
            }

            // this should be a min heap
            var freqBuckets = new List<List<int>>(maxFreq + 1);
            for (var i = 0; i <freqBuckets.Capacity ; i++)
            {
                foreach (var key in freq.Keys)
                {
                    if (freq[key] == i)
                    {
                        if (freqBuckets.Count <= i)
                        {
                            while (freqBuckets.Count <= i)
                            {
                                freqBuckets.Add(new List<int>());
                            }

                        }

                        freqBuckets[i].Add(key);
                    }
                }
            }

            var kMostFreq = new int[k];
            var found = 0;
            for(var i = freqBuckets.Count - 1; i >= 0; i--)
            {
                if (found == k)
                    break;

                foreach (var element in freqBuckets[i])
                {
                    kMostFreq[found] = element;
                    found += 1;

                    if (found == k)
                        break;
                }
                
            }
            return kMostFreq;
        }
    }
}
