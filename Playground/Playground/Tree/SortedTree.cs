using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Tree
{
    public class SortedTree<T> where T : IComparable<T>
    {
        private TreeNode _head;

        public void AddRange(IEnumerable<T> elements)
        {
            if(elements == null) throw new ArgumentException("Collection of elements can not be empty.");

            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public void Add(T t)
        {
            if (_head == null)
            {
                _head = new TreeNode(t);
                return;
            }

            _head.Add(t);
        }

        public IEnumerable<T> Traverse()
        {
            return _head == null ? Enumerable.Empty<T>() : Traverse(_head);
        }

        private static IEnumerable<T> Traverse(TreeNode head)
        {
            var smallerFirst = new List<T>();
            if (head.Smaller != null)
            {
                smallerFirst.AddRange(Traverse(head.Smaller));
            }
            smallerFirst.Add(head.Value);
            if (head.Greater != null)
            {
                smallerFirst.AddRange(Traverse(head.Greater));
            }
            return smallerFirst;

        }

        private class TreeNode
        {
            public TreeNode(T t)
            {
                Value = t;
            }

            public T Value { get; private set; }
            public TreeNode Smaller { get; private set; }
            public TreeNode Greater { get; private set; }

            public void Add(T t)
            {
                if (t.CompareTo(Value) > 0)
                {
                    if (Greater == null)
                    {
                        Greater = new TreeNode(t);
                        return;
                    }

                    Greater.Add(t);
                }else if (t.CompareTo(Value) < 0)
                {
                    if (Smaller == null)
                    {
                        Smaller = new TreeNode(t);
                        return;
                    }

                    Smaller.Add(t);
                }
                else // t = Value
                {
                    throw new ArgumentException("Can not have two elements with this same value.");
                }
            }
        }
    }
}
