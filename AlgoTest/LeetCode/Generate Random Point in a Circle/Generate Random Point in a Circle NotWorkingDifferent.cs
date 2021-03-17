using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Generate_Random_Point_in_a_Circle2
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

        [TestMethod]
        public void Test_EdgeDoubleLimit_NoOverflow()
        {
            double d = 0.304684142328186;
            d = 0.999999999999999;
            double d2 = 0.000000000000001;
            Assert.AreEqual(1, d + d2);
        }

        [TestMethod]
        public void Test_RandDoubleInclusive()
        {
            var s = new Solution(1,1,1);
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
            Console.Out.WriteLine(s.RandDoubleInclusive());
        }
    }

    public class Solution
    {

        public double RandDoubleInclusive()
        {
            var smallestDouble = 0.000000000000001;
            var random = new Random();
            var randDouble = random.NextDouble();
            var addExtra = random.Next(0, 2);
            if (addExtra == 1)
                randDouble += smallestDouble;

            return randDouble;
        }


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
            

            while (true)
            {
                var x = Rand.NextDouble() - 0.5;
                var y = Rand.NextDouble() - 0.5;
                if(Math.Pow(x, 2) + Math.Pow(y, 2) <= 25) return new double[]{Radius * x + x, Radius * y + y};
            }
        }
    }
}
