public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var result = new List<IList<string>>();
        var set = new HashSet<string>();
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        var traces = new Dictionary<string, List<List<string>>>();
        var found = false;

            traces.Add(beginWord, new List<List<string>>());
            traces[beginWord].Add(new List<string>());
            traces[beginWord][0].Add(beginWord);

            foreach (var item in wordList)
            {
                set.Add(item);

                if (!traces.ContainsKey(item))
                    traces.Add(item, new List<List<string>>());
            }

            if (!set.Contains(endWord))
                return new List<IList<string>>();

            queue.Enqueue(beginWord);
            visited.Add(beginWord);

            while (queue.Count > 0)
            {
                int count = queue.Count;

                while (count > 0)
                {
                    var cur = queue.Dequeue();

                    for (var j = 0; j < cur.Length; j++)
                        for (var k = 0; k < 26; k++)
                        {
                            var temp = cur.ToArray();

                            temp[j] = (char)('a' + k);

                            if (new string(temp) == endWord)
                            {
                                foreach (var trace in traces[cur])
                                {
                                    List<string> tempList = new List<string>(trace);
                                    tempList.Add(new string(temp));
                                    result.Add(tempList);
                                }

                                found = !found ? true : found;
                            }
                            else if (!found && set.Contains(new string(temp)))
                            {
                                if (!visited.Contains(new string(temp)))
                                {
                                    queue.Enqueue(new string(temp));
                                    visited.Add(new string(temp));
                                }

                                foreach (var trace in traces[cur])
                                {
                                    List<string> tempList = new List<string>(trace);
                                    tempList.Add(new string(temp));

                                    if (traces[new string(temp)].Count == 0 || (traces[new string(temp)].Count != 0 && traces[new string(temp)][0].Count == tempList.Count))
                                        traces[new string(temp)].Add(tempList);
                                }
                            }
                        }

                    count--;
                }

                if (found)
                    break;
            }

            return result;
    }
}
