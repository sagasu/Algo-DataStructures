using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Naming_a_Company
{
    // Out of memory for larger set of data on lt
    [TestClass]
    public class Naming_a_Company
    {
        [TestMethod]
        public void Test1()
        {
            var t = new []{ "coffee", "donuts", "time", "toffee" };
            Assert.AreEqual(6, DistinctNames(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new []{ "lack", "back" };
            Assert.AreEqual(0, DistinctNames(t));
        }

        public long DistinctNames(string[] ideas)
        {
            var dic = new Dictionary<string, long>();
            var validNames = new Dictionary<string, long>();

            var distinctNames = 0;
            foreach (var idea in ideas)
            {
                dic.TryAdd(idea,1);
            }

            for (var i = 0; i < ideas.Length; i++)
            {
                var charI = ideas[i].ToCharArray();
                var firstLetterI = charI[0];
                for (var j = i + 1; j < ideas.Length; j++)
                {
                    
                    var charJ = ideas[j].ToCharArray();
                    var firstLetterJ = charJ[0];
                    charJ[0] = firstLetterI;
                    charI[0] = firstLetterJ;

                    var si = new string(charI);
                    var sj = new string(charJ);

                    if (!dic.ContainsKey(si) && !dic.ContainsKey(sj))
                    {
                        if (validNames.TryAdd($"{si} {sj}", 1)) distinctNames += 1;
                        if (validNames.TryAdd($"{sj} {si}", 1)) distinctNames += 1;
                    }
                }
            }

            return distinctNames;
        }
    }
}
