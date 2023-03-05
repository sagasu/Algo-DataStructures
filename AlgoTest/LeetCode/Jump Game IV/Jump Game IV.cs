using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Jump_Game_IV
{
    public class Jump_Game_IV
    {
        public int MinJumps(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return 0;

            var dic = new Dictionary<int, List<int>>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (!dic.ContainsKey(arr[i])) dic.Add(arr[i], new List<int>() { i });
                else dic[arr[i]].Add(i);
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);

            var visited = new bool[arr.Length];
            visited[0] = true;
            var res = 0;

            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (var i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    if (curr == arr.Length - 1) return res;

                    var left = curr - 1;
                    var right = curr + 1;
                    if (left >= 0 && !visited[left])
                    {
                        queue.Enqueue(left);
                        visited[left] = true;
                    }

                    if (right < arr.Length && !visited[right])
                    {
                        queue.Enqueue(right);
                        visited[right] = true;
                    }

                    foreach (var next in dic[arr[curr]])
                    {
                        if (!visited[next])
                        {
                            queue.Enqueue(next);
                            visited[next] = true;
                        }
                    }
                    dic[arr[curr]].Clear(); 
                }
                res++;
            }

            return -1;
        }
    }
}
