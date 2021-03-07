using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Design_HashMap
{
    public class MyHashMap
    {

        IDictionary<int, int> dic;

        public MyHashMap()
        {
            dic = new Dictionary<int, int>();
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            if (dic.ContainsKey(key))
                dic[key] = value;
            else
                dic.Add(key, value);
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return dic.ContainsKey(key) ? dic[key] : -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            if (dic.ContainsKey(key))
                dic.Remove(key);
        }
    }
}
