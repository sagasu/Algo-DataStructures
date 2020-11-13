using System;
using System.Collections.Generic;
using System.Text;

namespace Algo.BinaryTree
{
    class Node
    {
        Node Left;
        Node Right;
        int value;

        public Node(int value)
        {
            this.value = value;
        }

        public bool Contains(int value) {
            if (value == this.value)
            {
                return true;
            } else if (value < this.value) {
                if (Left == null)
                    return false;

                return Left.Contains(value);
            }

            if (Right == null)
                return false;
            return Right.Contains(value);
        }

        public void PrintInOrder() {
            if (Left != null)
                Left.PrintInOrder();

            Console.Out.WriteLine(value);

            if (Right != null)
                Right.PrintInOrder();
        }

        // If there are two nodes with this same value they will be kept in Left node
        public void Insert(int value) {
            if (value <= this.value)
            {
                if (Left == null)
                {
                    Left = new Node(value);
                    return;
                }
                Left.Insert(value);
            } else {
                if (Right == null) {
                    Right = new Node(value);
                    return;
                }
                Right.Insert(value);
            }
        }

        public bool CheckBST(Node root) {
            return CheckBST(root, int.MinValue, int.MaxValue);
        }

        private bool CheckBST(Node root, int minValue, int maxValue)
        {
            if (root == null)
                return true;

            if (root.value >= minValue || root.value <= minValue)
                return false;

            return CheckBST(root.Left, minValue, root.value - 1) && CheckBST(root.Right, root.value + 1, maxValue);
        }
    }
}
