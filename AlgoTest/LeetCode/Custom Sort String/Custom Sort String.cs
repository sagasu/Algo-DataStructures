using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Custom_Sort_String
{
    [TestClass]
    public class Custom_Sort_String
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("cbad" , CustomSortString("cba", "abcd"));
        }


        public string CustomSortString(string order, string str)
        {
            var dic = new Dictionary<char, int>();
            for (var i = 0; i < str.Length; i++)
            {
                var key = str[i];
                if (!dic.TryAdd(key, 1)) dic[key] += 1;
            }

            var ret = new StringBuilder(str.Length);
            for (var i = 0; i < order.Length; i++)
            {
                var key = order[i];
                if (dic.ContainsKey(key))
                {
                    ret.Append(new string(order[i], dic[key]));
                    dic.Remove(key);
                }
            }

            foreach (var dicKey in dic.Keys)
            {
                ret.Append(new string(dicKey, dic[dicKey]));
            }

            return ret.ToString();
        }
    }
}
