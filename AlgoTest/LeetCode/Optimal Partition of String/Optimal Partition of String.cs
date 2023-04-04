using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Optimal_Partition_of_String
{
    [TestClass]
    public class Optimal_Partition_of_String
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, PartitionString("abacaba"));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(6, PartitionString("ssssss"));
        }

        public int PartitionString(string s)
        {
            var nrOfSubstrings = 1;
            var charLastPosition = new int[26];
            var beginningOfSubstring = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (charLastPosition[s[i] - 'a'] > beginningOfSubstring)
                {
                    nrOfSubstrings++;
                    beginningOfSubstring = i;
                }
                charLastPosition[s[i] - 'a'] = i + 1;
            }

            return nrOfSubstrings;
        }
    }
}
