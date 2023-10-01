using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Reverse_String_II;

[TestClass]
public class Reverse_String_II
{

    [TestMethod]
    public void Test() => Assert.AreEqual("bacdfeg", ReverseStr("abcdefg", 2));

    [TestMethod]
    public void Test2() => Assert.AreEqual("bacd", ReverseStr("abcd", 2));

    public string ReverseStr(string s, int k) =>
        string.Concat(s
            .Take(k).Reverse()
            .Concat(s.Skip(k).Take(k))
            .Concat(s.Length > 2 * k
                ? ReverseStr(s.Substring(2 * k), k)
                : string.Empty
            )
        );
}