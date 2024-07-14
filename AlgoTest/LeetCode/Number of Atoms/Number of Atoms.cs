using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Atoms;

public class Number_of_Atoms
{
    public string CountOfAtoms(string formula) {
        var i = formula.Length - 1;
        var res = Helper(formula, ref i, new Dictionary<string, int>(), 1);

        return string.Concat(res.OrderBy(u => u.Key).Select(u => u.Key + (u.Value == 1 ? "" : u.Value.ToString())));
    }
    
    public Dictionary<string, int> Helper(string str, ref int i, Dictionary<string, int> dictionary, int count)
    {
        var builder = string.Empty;

        var num = 0;
        var hasNum = false;

        for (; i >= 0; i--)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                num = (str[i] - '0') * (hasNum? 10 : 1) + num;
                hasNum = true;
            }
            else if (str[i] == '(')
                return dictionary;
            else if (str[i] == ')')
            {
                i--;
                var sub = Helper(str, ref i, new Dictionary<string, int>(), num * count);
                foreach (var item in sub)
                {
                    if (dictionary.ContainsKey(item.Key)) dictionary[item.Key] += item.Value;
                    else dictionary.Add(item.Key, item.Value);
                }

                num = 0;
                hasNum = false;
            }
            else if (str[i] >= 'A' && str[i] <= 'Z')
            {
                builder = str[i] + builder;

                num = (num == 0) ? 1 : num;

                if (dictionary.ContainsKey(builder))
                    dictionary[builder] += count * num;
                else
                    dictionary.Add(builder, count * num);

                hasNum = false;
                num = 0;
                builder = string.Empty;
            }
            else if (str[i] >= 'a' && str[i] <= 'z')
                builder += str[i];
        }

        return dictionary;
    }
}