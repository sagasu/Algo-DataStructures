
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode
{
    public class Solution
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return string.Join("", word1) == string.Join("", word2);
        }
    }
}