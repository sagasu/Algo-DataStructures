using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Remove_All_Adjacent_Duplicates_in_String_II
{
    [TestClass]
    public class Remove_All_Adjacent_Duplicates_in_String_II
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("abcd", RemoveDuplicates("abcd", 2));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("aa", RemoveDuplicates("deeedbbcccbdaa", 3));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("", RemoveDuplicates("adeeedbbcccbdaa", 3));
        }
        
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("ybth", RemoveDuplicates("yfttttfbbbbnnnnffbgffffgbbbbgssssgthyyyy", 4));
        }
        
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("vcnasu", RemoveDuplicates("viittttttiiiillllkkkkkkllllllkkkkkkllkkkkkkcnoooossssssooasu", 6));
        }

        public string RemoveDuplicates(string s, int k)
        {
            var count = 1;
            var start = 0;
            var streak = 0;
            var sb = new StringBuilder(s);
            while (count > 0)
            {
                count = 0;
                if (start < 0) start = 0;
                for (var i = start+1; i < sb.Length; i++)
                {
                    if (sb[i] == sb[i - 1])
                    {
                        streak += 1;
                        if (streak == k-1)
                        {
                            count += 1;
                            start = start - k;
                            sb.Remove(i + 1 - k, k);
                            streak = 0;
                            break;
                        }
                    }
                    else
                    {
                        start = i;
                        streak = 0;
                    }

                }
            }

            return sb.ToString();
        }
    }
}
