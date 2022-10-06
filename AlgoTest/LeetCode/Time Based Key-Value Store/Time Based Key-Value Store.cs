using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Time_Based_Key_Value_Store
{
    internal class TimeMap
    {
        public class Data
        {
            public Data(int ts, string val)
            {
                TimeStamp = ts;
                Value = val;
            }
            public int TimeStamp { get; set; }
            public string Value { get; set; }
        }

        private readonly Dictionary<string, List<Data>> _keyStore;
        public TimeMap()
        {
            _keyStore = new Dictionary<string, List<Data>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!_keyStore.ContainsKey(key))
                _keyStore.Add(key, new List<Data>());

            _keyStore[key].Add(new Data(timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!_keyStore.ContainsKey(key)) return string.Empty;

            var data = _keyStore[key];
            if (data.First().TimeStamp > timestamp) return string.Empty;
            if (data.Last().TimeStamp < timestamp) return data.Last().Value;

            int left = 0, right = data.Count - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (data[mid].TimeStamp == timestamp)
                {
                    return data[mid].Value;
                }
                else if (data[mid].TimeStamp > timestamp)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return data[right].Value;
        }
    }
}
