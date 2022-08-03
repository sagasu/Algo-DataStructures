using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.My_Calendar_I
{
    internal class My_Calendar_I
    {
        IntervalTreeNode root;

        public bool Book(int start, int end)
        {
            if (this.root == null)
            {
                this.root = new IntervalTreeNode(start, end);
                return true;
            }

            return this.root.Insert(new IntervalTreeNode(start, end));
        }
    }
    public class IntervalTreeNode
    {
        public int Start;
        public int End;
        IntervalTreeNode left;
        IntervalTreeNode right;

        public IntervalTreeNode(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public bool Insert(IntervalTreeNode node)
        {
            if (node.Start == node.End || node.Start > node.End) return false;

            if (node.End <= this.Start)
            {
                if (left == null) left = node;
                else return left.Insert(node);
            }else if (node.Start >= this.End) {
                if (right == null) right = node;
                else return right.Insert(node);
            }
            else return false;

            return true;
        }
    }
}
