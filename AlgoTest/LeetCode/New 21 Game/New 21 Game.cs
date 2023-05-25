using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.New_21_Game
{
    internal class New_21_Game
    {
        public double New21Game(int n, int k, int maxPts)
        {
            if (k == 0 || n >= k + maxPts) return 1.0;

            var op = new double[n + 1];
            var sum = 1.0;
            var res = 0.0;
            op[0] = 1;

            for (var i = 1; i < op.Length; i++)
            {
                op[i] = sum / maxPts;

                if (i < k) sum += op[i];
                else res += op[i];

                if (i - maxPts >= 0) sum -= op[i - maxPts];
            }

            return res;
        }
    }
}
