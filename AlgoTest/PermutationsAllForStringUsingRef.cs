using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest
{
    // This is interesting implementation swapping ref char[] instead of passing index to array.
    [TestClass]
    public class PermutationsAllForStringUsingRef
    {
        [TestMethod]
        public void Test()
        {
            BuildPermutations("abc".ToCharArray(), 0);
        }

        IList<string> per = new List<string>();

        public void BuildPermutations(char[] s, int index)
        {
            void Swap(ref char a, ref char b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            if (index == s.Length - 1)
            {
                per.Add(string.Join("", s));
                return;
            }

            for(var i = index; i < s.Length; i++)
            {
                Swap(ref s[index], ref s[i]);
                BuildPermutations(s, index + 1);
                Swap(ref s[index], ref s[i]);
            }
        }
    }
}
