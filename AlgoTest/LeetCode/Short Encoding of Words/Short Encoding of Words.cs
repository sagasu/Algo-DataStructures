using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Short_Encoding_of_Words
{
    [TestClass]
    public class Short_Encoding_of_Words
    {
        [TestMethod]
        public void Test()
        {
            var words = new string[] {"time", "me", "bell"};
            Assert.AreEqual(10, MinimumLengthEncoding(words));
        }

        public int MinimumLengthEncoding(string[] words)
        {
            Array.Sort(words, (s1, s2) => -s1.Length.CompareTo(s2.Length));
            var lookup = new HashSet<string>();

            var answer = 0;
            foreach (var word in words)
            {
                if(lookup.Contains(word)) continue;

                answer += word.Length + 1;

                for (var i = 1; i < word.Length + 1; i++)
                {
                    lookup.Add(new String(word.TakeLast(i).ToArray()));
                }
            }

            return answer;
        }
    }
}
