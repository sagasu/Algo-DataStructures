using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.HackerRank.SockMerchant
{
    [TestClass]
    public class SockMerchant
    {
        [TestMethod]
        public void SockMerchantTest()
        {
            int n = 5;
            int[] ar = new[] {1, 2, 3, 3, 1};
            GetSockMerchant(n, ar);
        }

        public int GetSockMerchant(int n, int[] ar)
        {
            if (n == 0)
                return 0;

            var visitedColors = new Dictionary<int, int>();
            var pairs = 0;
            for (var i = 0; i < n; i++)
            {
                var color = ar[i];
                if (visitedColors.Keys.Contains(color))
                    continue;
                visitedColors[color] = 1;
                for (var j = i+1; j < n; j++)
                {
                    if (ar[j] == color)
                    {
                        visitedColors[color] += 1;
                        if (visitedColors[color] % 2 == 0)
                            pairs += 1;
                    }
                }
            }

            return pairs;

        }
    }
}
