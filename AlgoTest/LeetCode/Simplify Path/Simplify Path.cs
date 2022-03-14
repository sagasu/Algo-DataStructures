using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Simplify_Path
{
    internal class Simplify_Path
    {
        public string SimplifyPath(string path)
        {
            var stack = new Stack<string>();

            foreach (var part in path.Split('/', StringSplitOptions.RemoveEmptyEntries).Where(c => c != "."))
            {
                if (part == "..") stack.TryPop(out _);
                else stack.Push(part);
            }

            return "/" + string.Join("/", stack.Reverse());
        }
    }
}
