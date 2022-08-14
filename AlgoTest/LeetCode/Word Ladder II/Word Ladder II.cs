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
            List<IList<string>> ans = new List<IList<string>>();
            var (shortestPathLength, graph) = ComputeGraph(beginWord, endWord, wordList);
            if (graph == null) return ans;

            string[] path = new string[shortestPathLength];
            FindPaths(endWord, 0);
            return ans;

            void FindPaths(string w, int position)
            {
                path[shortestPathLength - (position + 1)] = w;
                if (position == shortestPathLength - 1) ans.Add(path.ToList());
                else if (graph.ContainsKey(w))
                    foreach (string nextWord in graph[w]) FindPaths(nextWord, position + 1);
            }
        }

        private static (int ShortestPathLength, Dictionary<string, HashSet<string>> Graph) ComputeGraph(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

            Queue<string> q = new Queue<string>();
            q.Enqueue(beginWord);

            HashSet<string> used = new HashSet<string>(capacity: wordList.Count + 1);
            HashSet<string> usedInIteration = new HashSet<string>(capacity: wordList.Count + 1);
            bool endIsReached = false;
            int pathLength = 1;
            while (q.Count > 0)
            {
                int iterationCount = q.Count;

                for (int i = 0; i < iterationCount; i++)
                {
                    string current = q.Dequeue();
                    used.Add(current);

                    foreach (string possibleContinuation in wordList.Where(w => !used.Contains(w) && HaveOneLetterDifference(w, current)))
                    {
                        if (possibleContinuation == endWord) endIsReached = true;
                        else if (!usedInIteration.Contains(possibleContinuation))
                        {
                            q.Enqueue(possibleContinuation);
                            usedInIteration.Add(possibleContinuation);
                        }

                        if (!graph.ContainsKey(possibleContinuation)) graph[possibleContinuation] = new HashSet<string>();
                        graph[possibleContinuation].Add(current);
                    }
                }

                if (endIsReached) return (pathLength + 1, graph);

                foreach (string usedContinuation in usedInIteration) used.Add(usedContinuation);
                usedInIteration.Clear();
                pathLength++;
            }

            return (int.MaxValue, null);
        }

        private static bool HaveOneLetterDifference(string a, string b)
        {
            bool hadDifference = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (hadDifference) return false;
                    else hadDifference = true;
                }
            }

            return hadDifference;
        }
    }
}
