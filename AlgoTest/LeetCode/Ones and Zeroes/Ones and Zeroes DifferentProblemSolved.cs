using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Ones_and_Zeroes
{
    [TestClass]
    // Here I understood that "at most" means at most in one substring, not in a subset. So solution is for a different problem.
    public class Ones_and_Zeroes_DifferentProblemSolved
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] { "10", "0001", "111001", "1", "0" };
            Assert.AreEqual(4, FindMaxForm(t, 5,3));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[] { "10", "0", "1" };
            Assert.AreEqual(2, FindMaxForm(t, 1,1));
        }

        public int FindMaxForm(string[] strs, int m, int n)
        {
            var count = 0;
            foreach (var str in strs)
            {
                var zeros = 0;
                var ones = 0;
                foreach (var chr in str)
                {
                    if (chr == '0')
                        zeros += 1;
                    else
                        ones += 1;

                    if (zeros == m || ones == n) break;
                }

                if (zeros != m && ones != n) count += 1;
            }

            return count;
        }

    }
}
