using System.Collections.Generic;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode
{
    public class Solution7
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var groupedByLoses = matches
                .GroupBy(x => x[1])
                .ToDictionary(x => x, x => x.Count());

            var losers = groupedByLoses
                .Where(x => x.Value > 0)
                .Select(x => x.Key.Key);

            var zeroMatchLosers = matches
                .Select(x => x[0])
                .Except(losers)
                .OrderBy(x => x)
                .ToList();

            var oneMatchLosers = groupedByLoses
                .Where(x => x.Value == 1)
                .Select(x => x.Key.Key)
                .OrderBy(x => x)
                .ToList();

            return new List<IList<int>> { zeroMatchLosers, oneMatchLosers };
        }
    }
}