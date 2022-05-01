using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Backspace_String_Compare
{
    internal class Backspace_String_Compare
    {
		public bool BackspaceCompare(string s, string t)
		{
			var sStack = new Stack();
			var tStack = new Stack();
			foreach (var st in s)
			{
				if (st.Equals('#') && sStack.Count > 0) sStack.Pop();
				else if (st != '#') sStack.Push(st);
			}

			foreach (var ts in t)
			{
				if (ts.Equals('#') && tStack.Count > 0) tStack.Pop();
				else if (ts != '#') tStack.Push(ts);
			}

			if (sStack.ToArray().SequenceEqual((tStack.ToArray()))) return true;

			return false;
		}
	}
}
