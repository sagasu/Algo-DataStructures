using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximize_the_Confusion_of_an_Exam
{
    public class Maximize_the_Confusion_of_an_Exam
    {
        public int MaxConsecutiveAnswers(string answerKey, int k)
            => Math.Max(MaxConsecutiveCount(answerKey, k, 'T'),
                MaxConsecutiveCount(answerKey, k, 'F'));

        int MaxConsecutiveCount(string answerKey, int k, char target)
        {
            var count = 0;
            int left = 0, right = 0;
            for (; right < answerKey.Length; right++)
            {
                if (answerKey[right] != target)
                {
                    if (k == 0)
                        while (answerKey[left++] == target) continue;
                    else
                        k--;
                }
                count = Math.Max(count, right - left + 1);
            }
            return count;
        }
    }
}
