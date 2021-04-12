using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Beautiful_Arrangement_II
{
    [TestClass]
    public class Beautiful_Arrangement_II
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(new int[]{1,2,3}, ConstructArray(3,1));
        }
        
        [TestMethod]
        public void Test2()
        {
            CollectionAssert.AreEqual(new int[]{1,3,2}, ConstructArray(3,2));
        }
        /*
         * n = 4
         * k = 1;  1 2 3 4
         * k = 2;  1 2 4 3
         * k = 3;  1 4 2 3
         *
         * n = 5
         * k = 1; 1 2 3 4 5 -> 1
         * k = 2; 1 2 3 5 4 -> 1 2
         * k = 2; 1 3 2 4 5
         * k = 3; 1 2 5 3 4 ->1 2 3
         * k = 3; 1 4 2 3 5 ->1 2 3
         * k = 4; 1 5 2 4 3 ->1 2 3 4
         */
        public int[] ConstructArray(int n, int k)
        {
            var ans = new List<int>(){1};
            var sign = 1;
            for (var delta = k; delta >= 1; delta -= 1)
            {
                ans.Add(ans[ans.Count - 1] + sign * delta);
                sign *= -1;
            }

            var count = 1;
            var seen = new HashSet<int>(ans);
            while (ans.Count < n)
            {
                while (seen.Contains(count)) count += 1;

                ans.Add(count);
                seen.Add(count);
            }

            return ans.ToArray();
        }
    }
}
