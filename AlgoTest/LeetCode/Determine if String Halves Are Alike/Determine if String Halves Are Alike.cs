using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Determine_if_String_Halves_Are_Alike
{
    [TestClass]
    public class Determine_if_String_Halves_Are_Alike
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, HalvesAreAlike("book"));
            Assert.AreEqual(false, HalvesAreAlike("textbook"));
            Assert.AreEqual(false, HalvesAreAlike("MerryChristmas"));
            Assert.AreEqual(true, HalvesAreAlike("AbCdEfGh"));
        }

        public bool HalvesAreAlike(string s)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            var chars = s.ToCharArray();
            var half = chars.Length / 2;
            var leftCount = 0;
            var rightCount = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                if (vowels.Contains(chars[i]))
                {
                    if (i < half)
                        leftCount += 1;
                    else
                        rightCount += 1;
                }
            }

            return leftCount == rightCount;
        }
    }
}
