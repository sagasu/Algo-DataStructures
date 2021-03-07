using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Design_HashMap
{
    public class MyHashMap
    {
        private int[] store;

        public MyHashMap()
        {
            store = new int[1000001];
            Array.Fill(store, -1);
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            store[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return key < store.Length ? store[key] : -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            store[key] = -1;
        }
    }
}
