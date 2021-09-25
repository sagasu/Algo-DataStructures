using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Expression_Add_Operators
{
    class Expression_Add_Operators
    {
        public IList<string> AddOperators(string num, int target)
        {
            var result = new List<string>();
            Iterator(num, target, "", 0, 0, result);
            return result;
        }

        private void Iterator(string num, int target, string temp, long curRes, long preNumber, List<string> result)
        {
            if (curRes == target && num.Length == 0)
            {
                result.Add(temp);
                return;
            }

            for (var i = 1; i <= num.Length; i++)
            {
                var curStr = num.Substring(0, i);
                if (curStr.Length > 1 && curStr[0] == '0') return;

                var curNumber = long.Parse(curStr);
                var next = num.Substring(i);
                if (temp.Length != 0)
                {
                    Iterator(next, target, $"{temp}*{curNumber}", (curRes - preNumber) + preNumber * curNumber, preNumber * curNumber, result);
                    Iterator(next, target, $"{temp}+{curNumber}", curRes + curNumber, curNumber, result);
                    Iterator(next, target, $"{temp}-{curNumber}", curRes - curNumber, -curNumber, result);
                }
                else Iterator(next, target, curStr, curNumber, curNumber, result);
            }
        }
	}
}
