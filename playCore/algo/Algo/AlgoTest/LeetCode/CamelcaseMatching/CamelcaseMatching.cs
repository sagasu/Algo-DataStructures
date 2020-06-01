using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CamelcaseMatching
{
    [TestClass]
    public class CamelcaseMatching
    {
        [TestMethod]
        public void Test()
        {
            //var queries = new string[] {"FooBar", "FooBarTest", "FootBall", "FrameBuffer", "ForceFeedBack"};
            //var pattern = "FB";


            var queries = new string[] {  "ControlPanel" };
            var pattern = "CooP";
            CamelMatch(queries, pattern);
        }

        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            var res = new List<bool>(queries.Length);

            foreach (var query in queries)
            {
                var matched = false;
                var index = 0;
                foreach (var letter in query)
                {
                    if (matched)
                    {
                        if (letter <= 'Z')
                        {
                            matched = false;
                            break;
                        }
                        continue;
                    }

                    if (letter == pattern[index])
                    {
                        index += 1;
                    }
                    else if (letter <= 'Z')
                    {
                        break;
                    }

                    if (index == pattern.Length)
                    {
                        matched = true;
                    }

                }
                res.Add(matched);
            }

            return res;
        }
    }
}
