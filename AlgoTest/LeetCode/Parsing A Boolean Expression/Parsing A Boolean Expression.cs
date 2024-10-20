using System.Collections.Generic;

namespace AlgoTest.LeetCode.Parsing_A_Boolean_Expression;

public class Parsing_A_Boolean_Expression
{
    public bool ParseBoolExpr(string expression) {
            var ops = new Stack<char>();
            var vals = new Stack<Queue<bool>>();
            vals.Push(new Queue<bool>());
            foreach (var t in expression)
            {
                switch(t) {
                    case '!':
                    case '&':
                    case '|':
                        ops.Push(t);
                        break;
                    case '(':
                        vals.Push(new Queue<bool>());
                        break;
                    case ')':
                        char op = ops.Pop();
                        var cur = vals.Pop();
                        var prev = vals.Peek();
                        switch(op) {
                            case '!':
                                prev.Enqueue(!cur.Dequeue());
                                break;
                            case '&':
                                bool res1 = true;
                                foreach(bool v in cur) {
                                    res1 &= v;
                                    if (!res1) break;
                                }
                                prev.Enqueue(res1);
                                break;
                            case '|':
                                bool res2 = false;
                                foreach (bool v in cur) {
                                    res2 |= v;
                                    if (res2) break;
                                }
                                prev.Enqueue(res2);
                                break;
                        }
                        break;
                    case 't':
                        vals.Peek().Enqueue(true);
                        break;
                    case 'f':
                        vals.Peek().Enqueue(false);
                        break;
                }
            }
            return vals.Pop().Dequeue();
        }
}