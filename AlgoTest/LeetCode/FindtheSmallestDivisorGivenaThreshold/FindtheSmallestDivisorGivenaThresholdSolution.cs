using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.FindtheSmallestDivisorGivenaThreshold
{
    [TestClass]
    public class FindtheSmallestDivisorGivenaThresholdSolution
    {
        [TestMethod]
        public void TesT()
        {
            var t = new int[] {1, 2, 5, 9};
            Assert.AreEqual(5, SmallestDivisor(t, 6));

            t = new int[] { 19 };
            Assert.AreEqual(4, SmallestDivisor(t, 5));

            t = new int[] { 2, 3, 5, 7, 11 };
            Assert.AreEqual(3, SmallestDivisor(t, 11)); 
            
            t = new int[] { 962551, 933661, 905225, 923035, 990560};
            Assert.AreEqual(495280, SmallestDivisor(t, 10));
        }

        public int SmallestDivisor(int[] nums, int threshold)
        {
            bool Good(int divisor)
            {
                var maxSum = 0;
                foreach (var num in nums)
                {
                    maxSum += (num + divisor - 1) / divisor;
                }

                return (maxSum <= threshold);
            }


            var left = 1;
            var right = 10 ^ 7;
            while (left < right)
            {
                var mid = (right + left) / 2;

                if (Good(mid))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        
    }
}
