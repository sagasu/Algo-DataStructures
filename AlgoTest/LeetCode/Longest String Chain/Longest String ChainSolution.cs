using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_String_Chain
{
    internal class Longest_String_ChainSolution
    {
        public static int LongestStrChain(string[] words)
        {
            var dic = new Dictionary<string, int>();
            foreach (var word in words.OrderBy(w => w.Length)) 
                for (var i = 0; i < word.Length; i++)
                {
                    var word2 = word.Remove(i, 1);
                    dic[word] = Math.Max(dic.ContainsKey(word) ? dic[word] : 1, dic.ContainsKey(word2) ? dic[word2] + 1 : 1);
                }
            
            return dic.Values.Max();
        }
    }
}
