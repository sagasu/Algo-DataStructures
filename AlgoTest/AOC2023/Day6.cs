using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day6
{
    [TestMethod]
    public void Test()
    {
        (int time, int distance)[] races = { (40, 233), (82, 1011), (84, 1110), (92, 1487) };

        var multSum = 1;

        foreach(var race in races)
        {
            int solutions = 0, lastSolution = 0, hold = 0;
            
            while (true)
            {
                var currSolution = (race.time - hold) * hold;
                if (currSolution < lastSolution && currSolution < race.distance) break;
                if (currSolution > race.distance) solutions++;
                lastSolution = currSolution;
                hold++;
            }
            
            multSum *= solutions;
        }

        Console.WriteLine(multSum);
    }

    [TestMethod]
    public void Test2()
    {
        (long time, long distance) race = (40828492, 233101111101487);

        long solutions = 0, lastSolution = 0, hold = 0;
        
        while (true)
        {
            long currSolution = (race.time - hold) * hold;
            if (currSolution < lastSolution && currSolution < race.distance) break;
            if (currSolution > race.distance) solutions++;
            lastSolution = currSolution;
            hold++;
        }

        Console.WriteLine(solutions);
    }
}