using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Successful_Pairs_of_Spells_and_Potions
{
    [TestClass]
    public class Successful_Pairs_of_Spells_and_PotionsSolution
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(
                SuccessfulPairs(new int[] { 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 }, 5) is [4, 0, 3]);
        }

        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);
            var result = new int[spells.Length];

            for (var i = 0; i < spells.Length; i++)
            {
                var left = 0;
                var right = potions.Length - 1;

                while (left < right)
                {
                    var mid = (left + right) / 2;
                    if (potions[mid] * spells[i] >= success) right = mid;
                    else left = mid +1;
                }

                if (potions[left] * spells[i] < success) result[i] = 0;
                else result[i] = right;
            }
            

            return result;
        }
    }
}
