using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Group_Anagrams
{
    [TestClass]
    public class Group_Anagrams
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var expected = new List<IList<string>>
                {new List<string> {"eat", "tea", "ate"}, new List<string> {"tan", "nat"}, new List<string> {"bat"}};

            //CollectionAssert.AreEqual(expected.ToList(), GroupAnagrams(t).ToList()); //This doesn't work because of nested collection
            Assert.IsTrue(expected.SequenceEqual(GroupAnagrams(t), new EqualityComparerIList()));// Too bad that this can not be a lambda.
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var key =string.Concat(str.OrderBy(_ => _));
                if(!dic.TryAdd(key,new List<string>(){ str })) dic[key].Add(str);
            }

            return dic.Keys.Select(dicKey => dic[dicKey]).ToList();
        }

        class EqualityComparerIList : IEqualityComparer<IList<string>>
        {
            public bool Equals(IList<string> x, IList<string> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(IList<string> obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
