using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_Smallest_Letter_Greater_Than_Target
{
    [TestClass]
    public class Find_Smallest_Letter_Greater_Than_Target
    {
        [TestMethod]
        public void Test() => Assert.AreEqual('c', NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'a'));
        
        [TestMethod]
        public void Test1() => Assert.AreEqual('f', NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'c'));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual('x', NextGreatestLetter(new char[] { 'x', 'x', 'y','y' }, 'z'));

        public char NextGreatestLetter(char[] letters, char target)
        {
            var low = 0;
            var high = letters.Length-1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                if(letters[mid] <= target) low = mid + 1; 
                else high = mid - 1;
            }

            return low == letters.Length ? letters[0] : letters[low];
        }
    }
}
