using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Jump_Game_IV
{
    public class Jump_Game_IV
    {
        //not working
        public int MinJumps(int[] arr)
        {
            var N = arr.Length;
            var q = new Queue<int>();
            var best = new int[N];

            var dic = new Dictionary<int, IList<int>>();

            for (var i = 0; i < N; i++)
                if(!dic.TryAdd(arr[i], new List<int> {i})) dic[arr[i]].Add(i);

            q.Enqueue(0);
            best[0] = 0;
            var done = new HashSet<int>();

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current == N - 1) return best[current];

                foreach (var i in new List<int> { current - 1, current + 1 })
                {
                    if (0 <= i && i < N && best[current] + 1 < best[i])
                    {
                        q.Enqueue(i);
                        best[i] = best[current] + 1;
                    }
                }

                if (!done.Contains(arr[current]))
                {
                    done.Add(arr[current]);

                    foreach (var i in dic[arr[current]])
                    {
                        if (best[current] + 1 < best[i])
                        {
                            q.Enqueue(i);
                            best[i] = best[current] + 1;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
