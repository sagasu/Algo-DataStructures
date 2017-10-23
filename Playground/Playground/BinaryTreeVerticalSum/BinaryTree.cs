using System;

namespace Playground.BinaryTreeVerticalSum
{
    internal class BinaryTree
    {
        class Node
        {
            public Node(int data)
            {
                Data = data;
            }

            internal int Data { get; set; }
            internal Node LeftChild { get; set; }
            internal Node RightChild { get; set; }
        }

        private Node rootNode;

        private void AddChild(int data)
        {
            if (rootNode == null)
            {
                rootNode = AddChild(rootNode, data);
            }
            else
            {
                AddChild(rootNode, data);
            }

        }

        private Node AddChild(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            
            if (data < root.Data)
            {
                return AddChild(root.LeftChild, data);
            }

            //if (data > root.Data)
            return AddChild(root.RightChild, data);
        }

        private int[] treeData;

        public BinaryTree(int[] treeData)
        {
            this.treeData = treeData;
            foreach (var data in treeData)
            {
                AddChild(data);
            }
        }

        public void InOrderPrintTree()
        {
            

            InOrderPrintTree(rootNode);
        }

        private void InOrderPrintTree(Node node)
        {
            if (node == null)
                return;

            InOrderPrintTree(node.LeftChild);

            Console.Out.WriteLine(node.Data);

            InOrderPrintTree(node.RightChild);
        }
    }
}