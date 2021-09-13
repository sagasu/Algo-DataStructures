using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Maximum_Number_of_Balloons
{
    class Maximum_Number_of_Balloons
    {
        public int MaxNumberOfBalloons(string text)
        {
            var s = new HashSet<char>(new[] { 'b', 'a', 'l', 'o', 'n' });
            var source = text.ToCharArray();

            if (s.Intersect(source).Count() != s.Count) return 0;

            return source.GroupBy(i => i)
                .Where(j => s.Contains(j.Key))
                .Select(k => k.Key == 'l' || k.Key == 'o' ? k.Count() / 2 : k.Count())
                .Aggregate(int.MaxValue, (acc, val) => Math.Min(acc, val));
        }
    }
}
