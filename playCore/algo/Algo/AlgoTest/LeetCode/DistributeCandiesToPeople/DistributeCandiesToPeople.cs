using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.DistributeCandiesToPeople
{
    [TestClass]
    public class DistributeCandiesToPeople
    {
        [TestMethod]
        public void Test()
        {
            DistributeCandies(7, 4);
            DistributeCandies(10, 3);
        }

        private int[] candiesDis;
        public int[] DistributeCandies(int candies, int num_people)
        {
            candiesDis = new int[num_people];
            BuildDistributeCandies(candies, num_people, 0, 0);
            return candiesDis;
        }

        private void BuildDistributeCandies(int candies, int numPeople, int index, int usedCandies)
        {
            if(numPeople == 0 && candies == 0)
                return;

            if (numPeople == 0)
            {
                numPeople = index;
                index = 0;
            }

            var availableCandies = usedCandies + 1;
            if (candies < availableCandies)
                availableCandies = candies;

            candiesDis[index] += availableCandies;
            BuildDistributeCandies(candies - availableCandies, numPeople - 1, index + 1, usedCandies + 1);
        }
    }
}
