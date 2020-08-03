using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.DesignHashSet
{
    // Implementing HashSet as an array of lists to solve a collision problem, that will definitely happen if high prime number is not large enough.
    public class MyHashSet
    {
        private List<int>[] hashSet;
        const int highPrimeNumber = 769; //prime number to decrease chance of collision

        /** Initialize your data structure here. */
        public MyHashSet()
        {
            hashSet = new List<int>[highPrimeNumber];
            for(var i = 0; i < highPrimeNumber; i++)
            {
                hashSet[i] = new List<int>();
            }
        }

        public void Add(int key)
        {
            var hash = GetHash(key);
            if(!hashSet[hash].Contains(key))
                hashSet[hash].Add(key);
        }

        private int GetHash(int key)
        {
            return key % highPrimeNumber;
        }

        public void Remove(int key)
        {
            var hash = GetHash(key);
            hashSet[hash].Remove(key);
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var hash = GetHash(key);
            return hashSet[hash].Contains(key);
        }
    }
}
