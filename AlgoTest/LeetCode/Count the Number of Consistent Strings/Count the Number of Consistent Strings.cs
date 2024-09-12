using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_the_Number_of_Consistent_Strings;

[TestClass]
public class Count_the_Number_of_Consistent_Strings
{
    [TestMethod]
    public void Test() =>
        Assert.AreEqual(2, CountConsistentStrings("ab", new[] { "ad", "bd", "aaab", "baa", "badab" }));
    
    [TestMethod]
    public void Test2() =>
        Assert.AreEqual(7, CountConsistentStrings("abc", new[] { "a","b","c","ab","ac","bc","abc" }));
    
    [TestMethod]
    public void Test3() =>
        Assert.AreEqual(4, CountConsistentStrings("cad", new[] { "cc","acd","b","ba","bac","bad","ac","d" }));
    
    public int CountConsistentStrings(string allowed, string[] words) => words.Sum(word => word.All(c => allowed.Contains(c)) ? 1 : 0);
    
}