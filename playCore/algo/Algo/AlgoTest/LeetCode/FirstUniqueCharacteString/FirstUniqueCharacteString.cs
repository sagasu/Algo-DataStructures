using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.FirstUniqueCharacteString
{
    [TestClass]
    public class FirstUniqueCharacteString
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, FirstUniqChar("dddccdbba"));
        }

        IDictionary<char,ValueTuple<int, int>> dic = new Dictionary<char, ValueTuple<int, int>>();
        public int FirstUniqChar(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    var d = dic[s[i]];
                    dic[s[i]] = new ValueTuple<int,int>(d.Item1+1, d.Item2);
                }
                else
                {
                    dic[s[i]] = new ValueTuple<int,int>(1,i);
                }
            }
            
            foreach (var dicKey in dic.Keys)
            {
                if (dic[dicKey].Item1 == 1)
                    return dic[dicKey].Item2;
                
            }

            return -1;
        }
    }
}
