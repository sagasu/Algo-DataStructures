using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest
{
    [TestClass]
    public class PermutationsAllForString
    {
        [TestMethod]
        public void Test()
        {
            BuildPermutations("abc".ToCharArray(), 0);
            Assert.AreEqual(6, per.Count);
        }

        IList<string> per = new List<string>();

        public void BuildPermutations(char[] s, int index)
        {
            void Swap(int a, int b)
            {
                var temp = s[a];
                s[a] = s[b];
                s[b] = temp;
            }

            // it is important that it is length -1 because in recoursion in for we have i < s.length so it will never go to length in this implementation.
            if (index == s.Length - 1)
            {
                per.Add(string.Join("", s));
                return;
            }

            // it is important that we start from index and not index + 1
            for(var i = index; i < s.Length; i++)
            {
                Swap(index, i);
                BuildPermutations(s, index + 1);
                Swap(index, i);
            }
        }
    }
}
