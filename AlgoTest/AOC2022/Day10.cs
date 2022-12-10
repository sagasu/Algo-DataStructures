using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{

    [TestClass]
    public class Day10
    {
        private int visited = 0;
        [TestMethod]
        public void Test1()
        {
            var data = realData;

            int cycle = 1;
            int needed_cycles;
            int buffer;
            int X = 1;

            int sum = 0;
            int[] wanted = new int[6] { 20, 60, 100, 140, 180, 220 };

            for (var j=0;j<data.Length;j++)
            {
                var line = data[j];
                string[] instruction = line.Split(" ");

                if (instruction[0] == "addx")
                {
                    buffer = int.Parse(instruction[1]);
                    needed_cycles = 2;
                }
                else
                {
                    needed_cycles = 1;
                    buffer = 0;
                }

                for (int i = 0; i < needed_cycles; i++)
                {
                    if (wanted.Contains(cycle))
                        sum += X * cycle;

                    cycle++;
                }

                X += buffer;
                
            }

            Assert.AreEqual(6266, sum);
        }

       
        [TestMethod]
        public void Test2()
        {
            var data = realData;

            int cycle = 1;
            int needed_cycles;
            int buffer;
            int X = 1;

            for (var j = 0; j < data.Length; j++)
            {
                var line = data[j];
                string[] instruction = line.Split(" ");

                if (instruction[0] == "addx")
                {
                    buffer = int.Parse(instruction[1]);
                    needed_cycles = 2;
                }
                else
                {
                    needed_cycles = 1;
                    buffer = 0;
                }

                for (int i = 0; i < needed_cycles; i++)
                {
                    //Drawing
                    Console.Write((Math.Abs(X - ((cycle - 1) % 40)) <= 1) ? "#" : ".");
                    if ((cycle % 40) == 0)
                        Console.Write("\n");

                    cycle++;
                }

                X += buffer;
                
            }
            

            Assert.AreEqual("RFKZCPEF", "RFKZCPEF");
        }
       

        private string[] testData = new[]
        {
            "addx 15",
            "addx -11",
            "addx 6",
            "addx -3",
            "addx 5",
            "addx -1",
            "addx -8",
            "addx 13",
            "addx 4",
            "noop",
            "addx -1",
            "addx 5",
            "addx -1",
            "addx 5",
            "addx -1",
            "addx 5",
            "addx -1",
            "addx 5",
            "addx -1",
            "addx -35",
            "addx 1",
            "addx 24",
            "addx -19",
            "addx 1",
            "addx 16",
            "addx -11",
            "noop",
            "noop",
            "addx 21",
            "addx -15",
            "noop",
            "noop",
            "addx -3",
            "addx 9",
            "addx 1",
            "addx -3",
            "addx 8",
            "addx 1",
            "addx 5",
            "noop",
            "noop",
            "noop",
            "noop",
            "noop",
            "addx -36",
            "noop",
            "addx 1",
            "addx 7",
            "noop",
            "noop",
            "noop",
            "addx 2",
            "addx 6",
            "noop",
            "noop",
            "noop",
            "noop",
            "noop",
            "addx 1",
            "noop",
            "noop",
            "addx 7",
            "addx 1",
            "noop",
            "addx -13",
            "addx 13",
            "addx 7",
            "noop",
            "addx 1",
            "addx -33",
            "noop",
            "noop",
            "noop",
            "addx 2",
            "noop",
            "noop",
            "noop",
            "addx 8",
            "noop",
            "addx -1",
            "addx 2",
            "addx 1",
            "noop",
            "addx 17",
            "addx -9",
            "addx 1",
            "addx 1",
            "addx -3",
            "addx 11",
            "noop",
            "noop",
            "addx 1",
            "noop",
            "addx 1",
            "noop",
            "noop",
            "addx -13",
            "addx -19",
            "addx 1",
            "addx 3",
            "addx 26",
            "addx -30",
            "addx 12",
            "addx -1",
            "addx 3",
            "addx 1",
            "noop",
            "noop",
            "noop",
            "addx -9",
            "addx 18",
            "addx 1",
            "addx 2",
            "noop",
            "noop",
            "addx 9",
            "noop",
            "noop",
            "noop",
            "addx -1",
            "addx 2",
            "addx -37",
            "addx 1",
            "addx 3",
            "noop",
            "addx 15",
            "addx -21",
            "addx 22",
            "addx -6",
            "addx 1",
            "noop",
            "addx 2",
            "addx 1",
            "noop",
            "addx -10",
            "noop",
            "noop",
            "addx 20",
            "addx 1",
            "addx 2",
            "addx 2",
            "addx -6",
            "addx -11",
            "noop",
            "noop",
            "noop",
        };



        private string[] realData = new[]
        {
            "noop",
            "noop",
            "noop",
            "addx 5",
            "noop",
            "addx 1",
            "addx 2",
            "addx 5",
            "addx 2",
            "addx 1",
            "noop",
            "addx 5",
            "noop",
            "addx -1",
            "noop",
            "addx 5",
            "noop",
            "noop",
            "addx 5",
            "addx 1",
            "noop",
            "noop",
            "addx 3",
            "addx 2",
            "noop",
            "addx -38",
            "noop",
            "addx 3",
            "addx 2",
            "addx -5",
            "addx 12",
            "addx 2",
            "addx 27",
            "addx -40",
            "addx 19",
            "addx 2",
            "addx 19",
            "addx -18",
            "addx 2",
            "addx 5",
            "addx 2",
            "addx -23",
            "addx 22",
            "addx 4",
            "addx -34",
            "addx -1",
            "addx 5",
            "noop",
            "addx 2",
            "addx 1",
            "addx 20",
            "addx -17",
            "noop",
            "addx 25",
            "addx -17",
            "addx -2",
            "noop",
            "addx 3",
            "addx 19",
            "addx -12",
            "addx 3",
            "addx -2",
            "addx 3",
            "addx 1",
            "noop",
            "addx 5",
            "noop",
            "noop",
            "addx -37",
            "addx 3",
            "addx 4",
            "noop",
            "addx 24",
            "addx -6",
            "addx -15",
            "addx 2",
            "noop",
            "addx 6",
            "addx -2",
            "addx 6",
            "addx -12",
            "addx -2",
            "addx 19",
            "noop",
            "noop",
            "noop",
            "addx 3",
            "noop",
            "addx 7",
            "addx -2",
            "addx -24",
            "addx -11",
            "addx 4",
            "addx 3",
            "addx -2",
            "noop",
            "addx 7",
            "addx -2",
            "addx 2",
            "noop",
            "addx 3",
            "addx 7",
            "noop",
            "addx -2",
            "addx 5",
            "addx 2",
            "addx 5",
            "noop",
            "noop",
            "noop",
            "addx 3",
            "addx -35",
            "addx 35",
            "addx -21",
            "addx -14",
            "noop",
            "addx 5",
            "addx 2",
            "addx 33",
            "addx -7",
            "addx -23",
            "addx 5",
            "addx 2",
            "addx 1",
            "noop",
            "noop",
            "addx 5",
            "addx -1",
            "noop",
            "addx 3",
            "addx -23",
            "addx 30",
            "addx 1",
            "noop",
            "addx 4",
            "addx -17",
            "addx 11",
            "noop",
            "noop",
        };

    }


}
