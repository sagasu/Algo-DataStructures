using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Evaluate_the_Bracket_Pairs_of_a_String;

public class Evaluate_the_Bracket_Pairs_of_a_String
{
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        var d = new Dictionary<string, string>();
        foreach (var pair in knowledge)
        {
            d[pair[0]] = pair[1];
        }

        var result = new StringBuilder();     
        var k = new StringBuilder();
        bool start = false;
        foreach(char c in s) {
            if (c == '(') {
                start = true;
                k.Clear();
            }
            else if (c == ')' && start) {
                start = false;
                string key = k.ToString();
                if (d.TryGetValue(key, out string v))
                {
                    result.Append(v);
                }
                else
                {
                    result.Append('?');
                }
            }
            else if (!start) {
                result.Append(c);
            }
            else {
                k.Append(c);
            }
        }

        return result.ToString();
    }
}