using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.GasStation
{
    [TestClass]
    public class GasStation
    {
        [TestMethod]
        public void Test()
        {
            //var gas = new int[] { 1, 2, 3, 4, 5 };
            //var cost = new int[] { 3, 4, 5, 1, 2 };

            //Assert.AreEqual(3, CanCompleteCircuit(gas, cost));


            //var gas = new int[] { 4, 5, 2, 6, 5, 3 };
            //var cost = new int[] { 3, 2, 7, 3, 2, 9 };

            //Assert.AreEqual(-1, CanCompleteCircuit(gas, cost));


            //var gas = new int[] { 2, 3, 4 };
            //var cost = new int[] { 3, 4, 3 };

            //Assert.AreEqual(-1, CanCompleteCircuit(gas, cost));
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            for (var i = 0; i < gas.Length; i++)
                if (CanCompleteCircuit(gas, cost, i, i, 0))
                    return i;
                
            return -1;
        }

        public bool CanCompleteCircuit(int[] gas, int[] cost, int index, int startIndex, int gasInTank)
        {
            if (gasInTank == 0 && index != startIndex) return false;

            gasInTank += gas[index];
            if (cost[index] > gasInTank) return false;

            var nextIndex = GetNextIndex(index, gas.Length);
            if (nextIndex == startIndex) return true;

            if (CanCompleteCircuit(gas, cost, nextIndex, startIndex, gasInTank - cost[index]))
                return true;

            return false;
        }

        private static int GetNextIndex(int index, int limit)
        {
            return index == limit -1 ? 0 : index + 1;
        }
    }
}
