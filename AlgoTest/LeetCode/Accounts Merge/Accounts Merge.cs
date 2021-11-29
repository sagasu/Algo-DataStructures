using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Accounts_Merge
{
    class Accounts_Merge
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var dic = new Dictionary<string, IList<HashSet<string>>>();

            foreach (var elem in accounts)
            {
                var account = elem[0];

                if (!dic.TryGetValue(account, out var list))
                {
                    list = new List<HashSet<string>>();
                    dic.Add(account, list);
                }

                var hashSet = new HashSet<string>(elem.Skip(1));
                list.Add(hashSet);
            }

            var result = new List<IList<string>>();
            foreach (var kvp in dic)
            {
                var list = kvp.Value;
                for (var i = 0; i < list.Count; i++)
                {
                    var set1 = list[i];
                    if (set1 == null)
                    {
                        continue;
                    }

                    var queue = new Queue<string>(set1);

                    while (queue.Count > 0)
                    {
                        var email = queue.Dequeue();
                        for (var j = i + 1; j < list.Count; j++)
                        {
                            var set2 = list[j];
                            if (set2 == null)
                            {
                                continue;
                            }

                            if (!set2.Contains(email)) continue;
                            foreach (var e in set2.Except(set1))
                            {
                                queue.Enqueue(e);
                            }

                            set1 = set1.Union(set2).ToHashSet();
                            list[j] = null;
                        }
                    }

                    var subResult = new List<string>() {kvp.Key};
                    subResult.AddRange(set1.OrderBy(e => e, StringComparer.Ordinal));
                    result.Add(subResult);
                }
            }

            return result;
        }
    }
}