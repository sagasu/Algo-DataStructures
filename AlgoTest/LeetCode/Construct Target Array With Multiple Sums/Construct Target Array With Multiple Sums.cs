using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Construct_Target_Array_With_Multiple_Sums
{
    internal class Construct_Target_Array_With_Multiple_Sums
    {
        public bool IsPossible(int[] target)
        {
            var res = true;
            long sum = target.Aggregate<int, long>(0, (current, t) => current + t);

            while (target.Max() > 1)
            {
                var index = Array.IndexOf(target, target.Max());
                long dif = sum - target.Max();
                if (dif < 1 || dif > target.Max() || (target[index] % dif == 0 && dif != 1))
                {
                    res = false;
                    break;
                }
                sum -= target.Max();
                target[index] %= (int)dif;
                sum += target[index];

            }
            return res;
        }
    }
}
