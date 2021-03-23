using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._3Sum_With_Multiplicity
{
    // This is timeout approach, too slow. even if I add cache it will be too slow.
    [TestClass]
    public class _3Sum_With_Multiplicity_TooSlow
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 1, 2, 2, 2, 2};
            Assert.AreEqual(12, ThreeSumMulti(t, 5));
        }

        public int ThreeSumMulti(int[] arr, int target)
        {
            var mod = Math.Pow(10, 9) + 7;

            double GetThreeSum(int index, int takenNr, int sum)
            {
                double found = 0;

                if (takenNr == 3)
                {
                    if (sum == target) return 1;
                    return 0;
                }

                if (index == arr.Length || sum > target) return 0;

                found += GetThreeSum(index + 1, takenNr +1, sum + arr[index]);

                found += GetThreeSum(index + 1, takenNr, sum);
                return found;
            }

            var threesum = GetThreeSum(0, 0, 0);
            return  (int)(threesum % mod);
        }
    }
}
