using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ZigZagConversion
{
    [TestClass]
    public class ZigZagConversion
    {
        [TestMethod]
        public void Test()
        {
            //Assert.AreEqual("PAHNAPLSIIGYIR", Convert("PAYPALISHIRING",3));
            //Assert.AreEqual("AB", Convert("AB",1));
            Assert.AreEqual("ACBD", Convert("ABCD", 2));
        }

        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            if (s.Length == 1)
                return s;

            IDictionary<int, string> dic = new Dictionary<int, string>();
            var currentLine = 0;
            var currentZig = numRows - 2;
            var index = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (currentLine < numRows)
                {
                    if (currentLine == 0)
                    {
                        currentZig = numRows - 2;
                    }

                    index = currentLine;
                    currentLine += 1;
                }
                else
                {

                    index = currentZig < 0 ? 0 : currentZig;
                    currentZig -= 1;
                    if (currentZig <= 0)
                        currentLine = numRows == 2 ? 1 : 0;
                }

                if (dic.ContainsKey(index))
                {
                    dic[index] += s[i];
                }
                else
                {
                    dic.Add(index, s[i].ToString());
                }


            }

            var ret = "";
            for (var i = 0; i < numRows; i++)
            {
                if(!dic.ContainsKey(i))
                    continue;
                
                ret += dic[i];
            }

            return ret;
        }
    }
}
