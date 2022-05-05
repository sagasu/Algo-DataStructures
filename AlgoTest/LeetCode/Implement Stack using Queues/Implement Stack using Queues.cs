using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Implement_Stack_using_Queues
{
    internal class MyStack //Implement_Stack_using_Queues
    {
        internal Queue<int> q1 = null;
        internal List<int> lst = null;
        public MyStack()
        {
            this.q1 = new Queue<int>();
            this.lst = new List<int>();
        }
        public void Push(int x)
        {
            q1.Enqueue(x);
            lst.Insert(0, q1.Dequeue());
        }
        public int Pop()
        {
            var x = lst[0];
            lst.RemoveAt(0);
            return x;
        }
        public int Top()
        {
            return lst[0];
        }
        public bool Empty()
        {
            return lst.Count() == 0;
        }
    }
}
