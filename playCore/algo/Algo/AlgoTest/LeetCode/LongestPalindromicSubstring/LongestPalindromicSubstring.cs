using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LongestPalindromicSubstring
{
    [TestClass]
    public class LongestPalindromicSubstring
    {
        [TestMethod]
        public void Test()
        {
            //Assert.AreEqual("bab",LongestPalindrome("babad"));
            //Assert.AreEqual("bb", LongestPalindrome("cbbd"));
            //Assert.AreEqual("ccc", LongestPalindrome("ccc"));
            Assert.AreEqual("aaaa", LongestPalindrome("aaaa"));
            //Assert.AreEqual("abba", LongestPalindrome("abba"));
        }

        private int max = 0;
        private string ret = "";
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            for (var i = 0; i < s.Length; i++)
            {
                CalculateMaxPalindrome(s, i, true);
                CalculateMaxPalindrome(s, i, false);
            }

            return ret == "" ? s[0].ToString() : ret;
        }

        private void CalculateMaxPalindrome(string s, int i, bool odd)
        {
            var j = i + 1;
            var localMax = 0;
            if (odd)
            {
                i -= 1;
            }
            
            while (true)
            {
                if (i >= 0 && j < s.Length && s[i] == s[j])
                {
                    i -= 1;
                    j += 1;
                    localMax += 1;
                }
                else
                {
                    if(odd && localMax > 0)
                        localMax += 1;
                    if (localMax > max || (localMax == max && !odd))
                    {
                        max = localMax;
                        ret = s.Substring(i + 1, j - (i +1));
                    }

                    break;
                }
            }
        }
    }
}
