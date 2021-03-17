using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Generate_Random_Point_in_a_Circle
{
    [TestClass]
    // This solution doesn't work for some reason. Probably LeetCode has a random distribution check and it believes that my random distribution is not equal distributing points in the circle.
    public class Generate_Random_Point_in_a_Circle_NotWorking
    {
        [TestMethod]
        public void Test()
        {
            var s = new Solution(3.3, 1.1, 1.1);
            var r = s.RandPoint();
            Console.WriteLine($"{r[0]} {r[1]}");
            r = s.RandPoint();
            Console.WriteLine($"{r[0]} {r[1]}");
            r = s.RandPoint();
            Console.WriteLine($"{r[0]} {r[1]}");
            r = s.RandPoint();
            Console.WriteLine($"{r[0]} {r[1]}");
            r = s.RandPoint();
            Console.WriteLine($"{r[0]} {r[1]}");
        }
    }

    public class Solution
    {
        private double Radius;
        private double X;
        private double Y;
        private Random Rand;
        public Solution(double radius, double x_center, double y_center)
        {
            Radius = radius;
            X = x_center;
            Y = y_center;
            Rand = new Random();
        }

        public double[] RandPoint()
        {
            
            var x = Rand.NextDouble() * Radius;
            var y = Rand.NextDouble() * Radius;
            var isXPositive = Rand.Next(2);
            var isYPositive = Rand.Next(1);
            var xx = isXPositive == 0 ? x + X : X - x;
            var yy = isYPositive == 0 ? y + Y : Y - x; 
            return new double[]{ xx, yy };
        }
    }
}
