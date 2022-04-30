using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Evaluate_Division
{
    internal class Evaluate_Division
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var dict = new Dictionary<string, Dictionary<string, double>>();
            foreach (var a in equations.SelectMany(eq => eq).Distinct())
                Set(dict, a, a, 1);
            
            foreach (var (eq, val) in equations.Zip(values, (eq, val) => (eq, val)))
            {
                Set(dict, eq[0], eq[1], val);
                Set(dict, eq[1], eq[0], 1 / val);
            }

            foreach (var k in dict.Keys)
            foreach (var (a, b) in dict.Keys.SelectMany(k => dict.Keys, (a, b) => (a, b)))
                    if (dict.ContainsKey(a) && dict[a].ContainsKey(k) && dict[k].ContainsKey(b)) Set(dict, a, b, dict[a][k] * dict[k][b]);
            
            return queries.Select(q => Get(dict, q[0], q[1])).ToArray();
        }

        void Set(Dictionary<string, Dictionary<string, double>> dict, string a, string b, double v)
        {
            if (!dict.ContainsKey(a)) dict[a] = new Dictionary<string, double>();
            
            dict[a][b] = v;
        }

        double Get(Dictionary<string, Dictionary<string, double>> dict, string a, string b)
        {
            return dict.TryGetValue(a, out var dict1)
                ? dict1.TryGetValue(b, out var v) ? v : -1
                : -1;
        }
    }
}
