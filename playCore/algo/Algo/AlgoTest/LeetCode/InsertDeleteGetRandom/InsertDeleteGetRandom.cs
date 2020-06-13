using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.InsertDeleteGetRandom
{
    [TestClass]
    public class RandomizedSet
    {
        [TestMethod]
        public void Test() {
            Insert(0);
            Insert(1);
            Insert(1);
            Remove(0);
            Insert(2);
            Remove(1);
            var rand = GetRandom();
        }
        /** Initialize your data structure here. */
        public RandomizedSet()
        {

        }

        IDictionary<int, int> dic = new Dictionary<int, int>();
        IList<int> list = new List<int>();

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (dic.ContainsKey(val))
                return false;

            //list.Add(val);
            dic.Add(val, Math.Max(0,list.Count - 1));
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!dic.ContainsKey(val))
                return false;

            var index = dic[val];
            //list.RemoveAt(index);
            dic.Remove(val);
            
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var random = new Random();
            //int index = random.Next(list.Count);
            var v = dic.ElementAt(random.Next(0, dic.Count)).Key;
            return v;
        }
    }
}
