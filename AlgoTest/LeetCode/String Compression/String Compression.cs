using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.String_Compression
{
    [TestClass]
    public class String_Compression
    {

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(6, Compress(new []{ 'a', 'a', 'b', 'b', 'c', 'c', 'c' }));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(1, Compress(new []{ 'a',  }));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(4, Compress(new []{ 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }));
        } 
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(6, Compress(new []{ 'a', 'a', 'b', 'b', 'a', 'a', 'a' }));
        }

        public int Compress(char[] chars)
        {
            var index = 0;
            var endIndex = chars.Length;
            var nextIndex = 0;
            var count = 1;
            while (index < endIndex)
            {
                if (index == endIndex - 1 || chars[index] != chars[index + 1])
                {
                    chars[nextIndex++] = chars[index];
                    if (count > 1)
                    {
                        var digit = count.ToString().ToCharArray();
                        foreach (var digitChar in digit) chars[nextIndex++] = digitChar;
                    }
                    count = 1;
                }
                else count++;
                
                index++;
            }

            return nextIndex;
        }
        
        public int Compress2(char[] chars)
        {
            var totalSum = 0;
            var currentLength = 1;
            for (var i = 1; i < chars.Length; i++)
            {
                if (chars[i] != chars[i - 1])
                {

                    totalSum += currentLength > 1 ? GetLength() + 1: GetLength();
                    currentLength = 1;
                }else currentLength += 1;
            }

            int GetLength() => currentLength.ToString().Length;
            if(currentLength > 0) return currentLength > 1 ? totalSum + GetLength()+1 : totalSum + GetLength();
            return totalSum;
        }
    }
}
