using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AlgoTest.LeetCode.LinkedListDataStructure
{
    class LinkedListDS
    {
        private Node Head;

        class Node
        {
            public int Data;
            public Node Next;
            public Node(int data)
            {
                Data = data;
            }
        }

        public void Add(int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                return;
            }

            var current = Head;
            while (true)
            {
                if (current.Next == null)
                {
                    break;
                }
                current = current.Next;
            }

            current.Next = new Node(value);
        }

        public void Prepend(int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
            }

            var oldHead = Head;
            Head = new Node(value) {Next = oldHead};

        }

        public void DeleteByValue(int value)
        {
            if(Head == null)
                throw new ArgumentException("Linked list is empty");

            if (Head.Data == value)
            {
                Head = null;
                return;
            }


            var current = Head;
            while (true)
            {
                if (current.Next == null)
                {
                    throw new ArgumentException("no such value in a list");
                }

                if (current.Next.Data == value)
                {
                    if (current.Next.Next != null)
                    {
                        current.Next = current.Next.Next;
                    }
                    else
                    {
                        current.Next = null;
                    }
                }

                current = current.Next;
            }
        }
    }
}
