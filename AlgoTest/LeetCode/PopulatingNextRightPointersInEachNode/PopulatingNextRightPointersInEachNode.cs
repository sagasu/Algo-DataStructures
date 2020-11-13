using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PopulatingNextRightPointersInEachNode
{
    [TestClass]
    public class PopulatingNextRightPointersInEachNode
    {
        [TestMethod]
        public void Test()
        {
            var t = new Node(1,
                new Node(2, new Node(4), new Node(5),null),
                new Node(3, new Node(6), new Node(7),null),
                null);
            var res = Connect(t);
            // [1,#,2,3,#,4,5,6,7,#]
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;

            var previousPointer = root;
            var currentPointer = root.left;

            while (currentPointer != null)
            {
                var previousPointerHead = previousPointer;

                while (previousPointer != null)
                {
                    currentPointer.next = previousPointer.right;
                    currentPointer = currentPointer.next;

                    previousPointer = previousPointer.next;
                    if (previousPointer != null)
                    {
                        currentPointer.next = previousPointer.left;
                        currentPointer = currentPointer.next;
                    }
                }

                previousPointer = previousPointerHead.left;
                currentPointer = previousPointer.left;
            }

            return root;

        }
    }
}
