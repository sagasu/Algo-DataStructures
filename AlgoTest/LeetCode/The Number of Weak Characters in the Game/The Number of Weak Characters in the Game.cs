using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.The_Number_of_Weak_Characters_in_the_Game
{
    internal class The_Number_of_Weak_Characters_in_the_Game
    {
        HashSet<int> weakChars = new();
        public int NumberOfWeakCharacters(int[][] properties)
        {
            var props = properties.OrderByDescending(p => p[0]).ToList();
            var maxDefense = 0;
            var previousOffense = props[0][0];
            var previousMaxDefense = props[0][1];
            var weak = 0;
            for (var i = 0; i < props.Count; i++)
            {
                if (previousOffense != props[i][0])
                {
                    if (maxDefense < previousMaxDefense)
                        maxDefense = previousMaxDefense;
                    previousMaxDefense = props[i][1];
                    previousOffense = props[i][0];
                }
                else if (previousMaxDefense < props[i][1])
                    previousMaxDefense = props[i][1];

                if (maxDefense > props[i][1])
                    weak++;
            }
            return weak;
        }
    }
}
