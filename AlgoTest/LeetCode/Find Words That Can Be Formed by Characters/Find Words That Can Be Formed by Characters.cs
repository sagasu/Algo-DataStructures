using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_Words_That_Can_Be_Formed_by_Characters;

[TestClass]
public class Find_Words_That_Can_Be_Formed_by_Characters
{
    [TestMethod]
    public void Test() => Assert.AreEqual(6, CountCharacters(new[] { "cat", "bt", "hat", "tree" }, "atach"));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(10, CountCharacters(new[] { "hello","world","leetcode" }, "welldonehoneyr"));
    
    [TestMethod]
    public void Test3() => Assert.AreEqual(0, CountCharacters(new[]
        {
            "dyiclysmffuhibgfvapygkorkqllqlvokosagyelotobicwcmebnpznjbirzrzsrtzjxhsfpiwyfhzyonmuabtlwin","ndqeyhhcquplmznwslewjzuyfgklssvkqxmqjpwhrshycmvrb",
            "ulrrbpspyudncdlbkxkrqpivfftrggemkpyjl","boygirdlggnh","xmqohbyqwagkjzpyawsydmdaattthmuvjbzwpyopyafphx","nulvimegcsiwvhwuiyednoxpugfeimnnyeoczuzxgxbqjvegcxeqnjbwnbvowastqhojepisusvsidhqmszbrnynkyop",
            "hiefuovybkpgzygprmndrkyspoiyapdwkxebgsmodhzpx","juldqdzeskpffaoqcyyxiqqowsalqumddcufhouhrskozhlmobiwzxnhdkidr","lnnvsdcrvzfmrvurucrzlfyigcycffpiuoo","oxgaskztzroxuntiwlfyufddl",
            "tfspedteabxatkaypitjfkhkkigdwdkctqbczcugripkgcyfezpuklfqfcsccboarbfbjfrkxp","qnagrpfzlyrouolqquytwnwnsqnmuzphne","eeilfdaookieawrrbvtnqfzcricvhpiv","sisvsjzyrbdsjcwwygdnxcjhzhsxhpceqz",
            "yhouqhjevqxtecomahbwoptzlkyvjexhzcbccusbjjdgcfzlkoqwiwue","hwxxighzvceaplsycajkhynkhzkwkouszwaiuzqcleyflqrxgjsvlegvupzqijbornbfwpefhxekgpuvgiyeudhncv","cpwcjwgbcquirnsazumgjjcltitmeyfaudbnbqhflvecjsupjmgwfbjo",
            "teyygdmmyadppuopvqdodaczob","qaeowuwqsqffvibrtxnjnzvzuuonrkwpysyxvkijemmpdmtnqxwekbpfzs","qqxpxpmemkldghbmbyxpkwgkaykaerhmwwjonrhcsubchs"
        },
        "usdruypficfbpfbilvrhutcgvyjenlxzeovdyjtgvvfdjzcmikjraspdfp"));
    
    public int CountCharacters(string[] words, string chars)
    {
        var sum = 0;
        foreach (var word in words)
        {
            var usedIndex = new List<int>();
            for (var i = 0; i < word.Length; i++)
            {
                var isFound = false;
                for (var j = 0; j < chars.Length; j++)
                {
                    if (word[i] == chars[j] && !usedIndex.Contains(j))
                    {
                        isFound = true;
                        usedIndex.Add(j);
                        if (i == word.Length - 1) sum += word.Length;
                        break;
                    }
                }

                if (!isFound) break;
            }
        }

        return sum;
    }
}