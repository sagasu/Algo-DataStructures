using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.My_Calendar_III
{
    internal class MyCalendarThree
    {
        private readonly SortedDictionary<int, int> _eventMap;

        public MyCalendarThree()
        {
            _eventMap = new SortedDictionary<int, int>();
        }

        public int Book(int start, int end)
        {
            if (_eventMap.Count == 0)
            {
                _eventMap[start] = 1;
                _eventMap[end] = -1;

                return 1;
            }

            int res = 0;
            if (!_eventMap.ContainsKey(start))
            {
                _eventMap[start] = 0;
            }

            if (!_eventMap.ContainsKey(end))
            {
                _eventMap[end] = 0;
            }

            _eventMap[start]++;
            _eventMap[end]--;

            int curr = 0;
            foreach (var pair in _eventMap)
            {
                curr += pair.Value;
                res = Math.Max(res, curr);
            }

            return res;
        }
    }
}
