using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SequentialDigits
{
    [TestClass]
    public class SequentialDigitsSolution
    {
        [TestMethod]
        public void Test()
        {
            SequentialDigits(100, 300);
        }

        //This implementation is so different in approach to typical algorithms.
        public IList<int> SequentialDigits(int low, int high)
        {
            var res = new List<int>();
            var s = "123456789";
            for(var i = 2; i<=s.Length;i++)
            for (var j = 0; j <= s.Length - i; j++)
            {
                var num = int.Parse(s.Substring(j,  i));
                if (num > high) return res;
                if(num >= low) res.Add(num);
            }

            return res;
        }

        List<int> sequentialDigits = new List<int>();

        //public void BuildSequentialDigits(int low, int high, List<int> seq, int index)
        //{
        //    var lo = low % 10;
        //    var hi = high % 10;

        //    if (index == lastHi && digit == maxDigit)
        //    {
        //        sequentialDigits.Add(int.Parse(string.Join("", seq)));
        //        return;
        //    }

        //    for (var i = index; i < max; i++)
        //    {
        //        seq.Add(i);
        //        BuildSequentialDigits(low, high, digit + 1, maxDigit, lastLo, lastHi, seq, i);
        //        seq.RemoveAt(i);
        //    }
        //}

        //public void BuildSequentialDigits(int low, int high, int digit, int maxDigit, int lastLo, int lastHi, List<int> seq, int index)
        //{
        //    if (index == lastHi && digit == maxDigit)
        //    {
        //        sequentialDigits.Add(int.Parse(string.Join("",seq)));
        //        return;
        //    }

        //    for(var i = index; i < 10; i++)
        //    {
        //        seq.Add(i);
        //        BuildSequentialDigits(low, high, digit+1, maxDigit, lastLo, lastHi, seq, i);
        //        seq.RemoveAt(i);
        //    }
        //}
    }
}
