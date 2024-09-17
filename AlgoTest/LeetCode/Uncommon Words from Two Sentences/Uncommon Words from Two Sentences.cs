using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Uncommon_Words_from_Two_Sentences;

[TestClass]
public class Uncommon_Words_from_Two_Sentences
{
    [TestMethod]
    public void Test() => CollectionAssert.AreEqual(new[] { "sweet", "sour" },
        UncommonFromSentences("this apple is sweet", "this apple is sour"));
    
    public string[] UncommonFromSentences(string s, string t) => $"{s} {t}"
        .Split(' ')
        .GroupBy(w => w)
        .Where(g => g.Count() == 1)
        .Select(g => g.Key)
        .ToArray();
}