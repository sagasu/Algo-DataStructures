using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Solving_Questions_With_Brainpower
{
    internal class Solving_Questions_With_Brainpower
    {
        public long MostPoints(int[][] questions)
        {
            return MostPoints(0, new Dictionary<int, long>(), questions);
        }

        long MostPoints(int index, IDictionary<int, long> dic, IReadOnlyList<int[]> questions)
        {
            if (index >= questions.Count) return 0;
            if (dic.ContainsKey(index)) return dic[index];

            var rs0 = questions[index][0] + MostPoints(index + questions[index][1] + 1, dic, questions);
            var rs1 = MostPoints(index + 1, dic, questions);
            var rs = Math.Max(rs0, rs1);

            if (!dic.ContainsKey(index)) dic.Add(index, rs);

            return rs;
        }
    }
}
