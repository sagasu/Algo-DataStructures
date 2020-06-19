using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.LongestDuplicateSubstring
{
    class LongestDuplicateSubstringProblem
    {
        public string LongestDupSubstring(string S)
        {
            if (string.IsNullOrEmpty(S))
                return "";

            var longestSub = 0;
            var index = 0;
            var currentLength = 0;
            var isSub = false;
            for (var i = 0; i < S.Length; i++) {
                for (var j = index; j <= i; j++) {
                    if (S[i] == S[j])
                    {
                        currentLength += 1;
                        isSub = true;
                        index = i;
                    }
                    else {
                        if (isSub) {
                            if (currentLength > longestSub)
                                longestSub = currentLength;
                        }
                        currentLength = 0;
                        isSub = false;
                    }
                }
            }
        }
    }
}
