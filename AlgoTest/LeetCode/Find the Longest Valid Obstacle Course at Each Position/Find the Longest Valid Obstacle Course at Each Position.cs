using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Find_the_Longest_Valid_Obstacle_Course_at_Each_Position
{
    internal class Find_the_Longest_Valid_Obstacle_Course_at_Each_Position
    {
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            int n = obstacles.Length, length = 0;
            var res = new int[n];
            var mono = new int[n];

            for (var i = 0; i < n; ++i)
            {
                int l = 0, r = length;
                while (l < r)
                {
                    var m = (l + r) / 2;
                    if (mono[m] <= obstacles[i]) l = m + 1;
                    else r = m;
                }

                res[i] = l + 1;
                if (length == l) length++;
                mono[l] = obstacles[i];

            }

            return res;
        }
    }
}
