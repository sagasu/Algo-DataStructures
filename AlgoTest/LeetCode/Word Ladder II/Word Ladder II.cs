using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Word_Ladder_II
{
    internal class Word_Ladder_II
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var wordSet = wordList.ToHashSet();
            var res = new List<IList<string>>();
            var level = new Dictionary<string, List<IList<string>>> { [beginWord] = new List<IList<string>> { new List<string> { beginWord } } };
            while (level.Any())
            {
                var newLevel = new Dictionary<string, List<IList<string>>>();
                foreach (var word in level.Keys)
                {
                    if (word == endWord)
                    {
                        res.AddRange(level[word]);
                    }
                    else
                    {
                        for (var i = 0; i < word.Length; i++)
                        {
                            foreach (var c in "abcdefghijklmnopqrstuvwxyz")
                            {
                                var next = word[0..i] + c + word[(i + 1)..^0];
                                if (wordSet.Contains(next))
                                {
                                    if (!newLevel.ContainsKey(next))
                                    {
                                        newLevel[next] = new List<IList<string>>();
                                    }
                                    newLevel[next].AddRange(level[word].Select(path => path.Append(next).ToList()));
                                }
                            }
                        }
                    }
                }
                wordSet.ExceptWith(newLevel.Keys);
                level = newLevel;
            }
            return res;
        }
	}
}
