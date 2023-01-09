public class Solution {
          public class singleTask
        {
            public int index;
            public int en;
            public int pr;

            public int compare(singleTask other)
            {
                if (other.pr != pr)
                    return pr.CompareTo(other.pr);
                return index.CompareTo(other.index);
            }
        }
        public int[] GetOrder(int[][] tasks)
        {

            var ans = new List<int>();
            var waiting = new PriorityQueue<singleTask, int>();

            for (int i = 0; i < tasks.GetLength(0); i++)
                waiting.Enqueue(new singleTask { index = i, en = tasks[i][0], pr = tasks[i][1] }, tasks[i][0]);

            var aval = new PriorityQueue<int, singleTask>(Comparer<singleTask>.Create((st1, st2) => st1.compare(st2)));


            int cur = 0;
            while (waiting.Count > 0 || aval.Count > 0)
            {
                if (aval.Count == 0 && cur< waiting.Peek().en)
                    cur = waiting.Peek().en;


                while (waiting.Count > 0 && cur >= waiting.Peek().en)
                {
                    var deq = waiting.Dequeue();
                    aval.Enqueue(deq.index, deq);
                }
                
                var t = aval.Dequeue();
                ans.Add(t);
                cur += tasks[t][1];

            }

            return ans.ToArray();
        }
}