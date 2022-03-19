using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Frequency_Stack
{
    //Maximum Frequency Stack
    internal class FreqStack
    {
        Dictionary<int, Stack<int>> groups;
        Dictionary<int, int> freqs;
        int maxFreq;

        public FreqStack()
        {
            groups = new Dictionary<int, Stack<int>>();
            freqs = new Dictionary<int, int>();
            maxFreq = 0;
        }

        public void Push(int x)
        {
            if (!freqs.TryAdd(x, 1))
                freqs[x]++;

            if (freqs[x] > maxFreq)
                maxFreq = freqs[x];

            Stack<int> group = null;
            if (!groups.TryGetValue(freqs[x], out group))
            {
                group = new Stack<int>();
                groups.Add(freqs[x], group);
            }
            group.Push(x);
        }

        public int Pop()
        {

            var x = groups[maxFreq].Pop();
            freqs[x]--;

            if (groups[maxFreq].Count == 0)
                maxFreq--;

            return x;
        }
    }
}
