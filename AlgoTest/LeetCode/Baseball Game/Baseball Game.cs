using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Baseball_Game
{
    internal class Baseball_Game
    {
        public int CalPoints(string[] ops)
        {
            var stack = new Stack<int>();
            foreach (var op in ops)
            {
                switch (op)
                {
                    case "D":
                        stack.Push(2 * stack.Peek());
                        break;
                    case "C":
                        stack.Pop();
                        break;
                    case "+":
                        var poppedValue = stack.Pop();
                        var newValue = poppedValue + stack.Peek();
                        stack.Push(poppedValue);
                        stack.Push(newValue);
                        break;
                    default:
                        stack.Push(Convert.ToInt32(op));
                        break;
                }
            }
            return stack.Sum();
        }
    }
}
