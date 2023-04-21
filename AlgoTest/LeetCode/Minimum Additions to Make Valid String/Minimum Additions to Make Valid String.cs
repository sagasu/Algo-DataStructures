using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Additions_to_Make_Valid_String
{
    [TestClass]
    public class Minimum_Additions_to_Make_Valid_String
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(2, AddMinimum("b"));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual(6, AddMinimum("aaa"));
        [TestMethod]
        public void Test3() => Assert.AreEqual(0, AddMinimum("abc"));

        //TODO: This is a great solution for any pattern matching - add elements.
        //We either add element or move index forward
        public int AddMinimum(string word)
        {
            var count = 0;
            var i = 0;
            while(i < word.Length)
                foreach (var chr in "abc")
                    if (i >= word.Length || word[i] != chr) count++;
                    else i+=1;
            
            return count;
        }
    }
}
