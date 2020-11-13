using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.LRUCache
{
    class LRUCache
    {
        private Node Head;
        private Node Tail;
        private Dictionary<int,int> Dic = new Dictionary<int, int>();

        private int Capacity;

        public LRUCache(int capacity)
        {
            Capacity = capacity;
        }

        public int Get(int key)
        {
            var value = Dic[key];
            ChangeWithHeadByKey(key);
            return value;
        }

        public void Put(int key, int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                Tail = Head;
            }
        }

        private void ChangeWithHeadByKey(int key)
        {
            if (Head.Data == key)
                return;
            var current = Head.Next;
            while (current != null)
            {
                if (current.Data == key)
                {
                    
                }
            }
        }

        class Node
        {
            public int Data;
            public Node Previous;
            public Node Next;
            public Node(int data)
            {
                Data = data;
            }
        }
    }
}
