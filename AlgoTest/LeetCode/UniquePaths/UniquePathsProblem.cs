using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AlgoTest.LeetCode.UniquePaths
{
    [TestClass]
    public class UniquePathsProblem
    {
        [TestMethod]
        public void Test() {
            //Assert.AreEqual(3, UniquePaths(3, 2));
            Assert.AreEqual(193536720, UniquePaths(23, 12));
        }

        public int UniquePaths(int m, int n)
        {
            var dp = new int[m,n];
            for (var i = 0; i < m; i++) 
                dp[i,0] = 1;
            

            for (var i = 0; i < n; i++)
                dp[0,i] = 1;
            

            for (var i = 1; i < m; i++)
                for (var j = 1; j < n; j++)
                    dp[i,j] = dp[i - 1,j] + dp[i,j - 1];
                

            return dp[m - 1,n - 1];
        }
    }
}
