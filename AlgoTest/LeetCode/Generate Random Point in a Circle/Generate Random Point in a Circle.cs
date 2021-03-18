using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Generate_Random_Point_in_a_Circle3
{
    [TestClass]
    public class Generate_Random_Point_in_a_Circle
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
            
            var r = Math.Pow(Rand.NextDouble(), 0.5)  * Radius;
            var theta = Rand.NextDouble() * 2 * Math.PI;


            var x = r * Math.Cos(theta);
            var y = r * Math.Sin(theta);

            return new double[]{ x + X, y + Y};
        }
    }
}
