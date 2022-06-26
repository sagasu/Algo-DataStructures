using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Points_You_Can_Obtain_from_Cards
{
    internal class Maximum_Points_You_Can_Obtain_from_Cards
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            var points = 0;
            for (var i = 0; i < k; i++) // sum of first k elements 
                points += cardPoints[i];
            if (k == cardPoints.Length)
                return points;
            var maxPoints = points;
            var left = k - 1;
            var right = cardPoints.Length - 1;
            while (left >= 0)
            {
                points -= cardPoints[left--];
                points += cardPoints[right--];
                maxPoints = Math.Max(points, maxPoints);
            }
            return maxPoints;
        }
    }
}
