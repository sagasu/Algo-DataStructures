using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Design_HashMap3
{
    public class MyHashMap
    {
        private int?[] store;
        private const int LARGE_PRIME_SMALLER_THAN_1M = 999983;
        public MyHashMap()
        {
            store = new int?[LARGE_PRIME_SMALLER_THAN_1M];
        }

        private int Hash(int key)
        {
            return key % LARGE_PRIME_SMALLER_THAN_1M;
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            store[Hash(key)] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return store[Hash(key)].HasValue ? store[Hash(key)].Value : -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            store[Hash(key)] = null;
        }
    }
}
