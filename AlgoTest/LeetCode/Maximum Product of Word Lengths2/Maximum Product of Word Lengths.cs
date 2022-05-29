using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Product_of_Word_Lengths2
{
    internal class Maximum_Product_of_Word_Lengths
    {
        public int MaxProduct(string[] words)
        {
            Array.Sort(words, (w1, w2) => w2.Length.CompareTo(w1.Length));
            var charSets = new int[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                var mask = 0;
                for (var j = 0; j < words[i].Length; j++)
                    mask |= (1 << (words[i][j] - 'a'));
                
                charSets[i] = mask;
            }

            var res = 0;
            for (var i = 0; i < words.Length; i++)
            for (var j = i; j < words.Length; j++)
            {
                    if ((charSets[i] & charSets[j]) != 0) continue;
                    res = Math.Max(res, words[i].Length * words[j].Length);
                    break;
            }
            

            return res;
        }
    }
}
