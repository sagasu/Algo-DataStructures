using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.OtherCodingChallanges.BinaryGap
{
    [TestClass]
    public class BinaryGap
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(5,solution(1041));
        }

        public int solution(int N)
        {
            var binary = Convert.ToString(N, 2);
            var max = 0;
            var localMax = 0;
            var oneFound = false;

            foreach (var bit in binary)
            {
                if (bit == '1')
                    oneFound = true;

                if (oneFound)
                {
                    if (bit == '0')
                    {
                        localMax += 1;
                    }
                    else
                    {
                        if (localMax > max)
                            max = localMax;

                        localMax = 0;
                    }
                }
            }

            return max;
        }
    }
}
