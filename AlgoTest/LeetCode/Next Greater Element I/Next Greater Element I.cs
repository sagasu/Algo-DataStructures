using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Next_Greater_Element_I
{
    class Next_Greater_Element_I
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();
            var stack = new Stack<int>();

            foreach (var n in nums2)
            {
                while (stack.Any() && stack.Peek() < n)
                    dict[stack.Pop()] = n;
                stack.Push(n);
            }

            return nums1.Select(x => dict.GetValueOrDefault(x, -1)).ToArray();
        }
    }
}
