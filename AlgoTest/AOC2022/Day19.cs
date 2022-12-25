using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{

    [TestClass]
    public class Day19
    {

        public record BluePrint(
        int Id,
        int OreRobotOreCost,
        int ClayRobotOreCost,
        int ObsidianRobotOreCost,
        int ObsidianRobotClayCost,
        int GeodeRobotOreCost,
        int GeodeRobotObsidianCost)
        {
            public static BluePrint[] ParseBluePrints(string[] lines)
            {
                return lines
                    .Select(line =>
                        Create(
                            line
                                .Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries)
                                .Where(x => int.TryParse(x, out _))
                                .Select(int.Parse)
                                .ToArray()))
                    .ToArray();
            }

            private static BluePrint Create(int[] values) =>
                new(
                    values[0],
                    values[1],
                    values[2],
                    values[3],
                    values[4],
                    values[5],
                    values[6]
                );

            private int MaxOreCost =>
                new[] { OreRobotOreCost, ClayRobotOreCost, ObsidianRobotOreCost, GeodeRobotOreCost }.Max();

            public int GetMaxGeodeCount(BluePrint bluePrint, int timeLimit)
            {
                var visited = new HashSet<(int time, (int, int, int, int) resources, (int, int, int, int) robots)>();
                var startState = (timeLimit, (0, 0, 0, 0), (1, 0, 0, 0));
                var queue = new Queue<(
                    int time,
                    (int ore, int clay, int obsidian, int geodes) resources,
                    (int oreRobots, int clayRobots, int obsidianRobots, int geodeRobots) robots)>();
                queue.Enqueue(startState);

                var maxGeodesCount = 0;
                while (queue.Count > 0)
                {
                    var (time, resources, robots) = queue.Dequeue();

                    maxGeodesCount = Math.Max(resources.geodes, maxGeodesCount);

                    if (time == 0)
                    {
                        continue;
                    }

                    //prune excessive robots (if their production level is greater than necessary)
                    robots = robots with
                    {
                        oreRobots = Math.Min(robots.oreRobots, bluePrint.MaxOreCost),
                        clayRobots = Math.Min(robots.clayRobots, bluePrint.ObsidianRobotClayCost),
                        obsidianRobots = Math.Min(robots.obsidianRobots, bluePrint.GeodeRobotObsidianCost)
                    };

                    //prune excessive resources (more than enough resource to build the most expensive robot, requiring that resource)
                    resources = resources with
                    {
                        ore = Math.Min(resources.ore, time * bluePrint.MaxOreCost - robots.oreRobots * (time - 1)),
                        clay = Math.Min(resources.clay,
                            time * bluePrint.ObsidianRobotClayCost - robots.clayRobots * (time - 1)),
                        obsidian = Math.Min(resources.obsidian,
                            time * bluePrint.GeodeRobotObsidianCost - robots.obsidianRobots * (time - 1))
                    };

                    if (visited.Contains((bluePrint.Id, resources, robots)))
                    {
                        continue;
                    }

                    visited.Add((bluePrint.Id, resources, robots));

                    var commonNextState = (
                        time: time - 1,
                        resources: (
                            ore: resources.ore + robots.oreRobots,
                            clay: resources.clay + robots.clayRobots,
                            obsidian: resources.obsidian + robots.obsidianRobots,
                            geodes: resources.geodes + robots.geodeRobots),
                        robots);

                    //build geode cracking robot
                    if (resources.ore >= bluePrint.GeodeRobotOreCost && resources.obsidian >= bluePrint.GeodeRobotObsidianCost)
                    {
                        queue.Enqueue(commonNextState with
                        {
                            resources = commonNextState.resources with
                            {
                                ore = commonNextState.resources.ore - bluePrint.GeodeRobotOreCost,
                                obsidian = commonNextState.resources.obsidian - bluePrint.GeodeRobotObsidianCost
                            },
                            robots = commonNextState.robots with { geodeRobots = robots.geodeRobots + 1 }
                        });
                        continue;
                    }

                    //collect resources
                    queue.Enqueue(commonNextState);

                    //build ore collecting robot
                    if (resources.ore >= bluePrint.OreRobotOreCost)
                    {
                        queue.Enqueue(commonNextState with
                        {
                            resources = commonNextState.resources with
                            {
                                ore = commonNextState.resources.ore - bluePrint.OreRobotOreCost
                            },
                            robots = commonNextState.robots with { oreRobots = robots.oreRobots + 1 }
                        });
                    }

                    //build clay collecting robot
                    if (resources.ore >= bluePrint.ClayRobotOreCost)
                    {
                        queue.Enqueue(commonNextState with
                        {
                            resources = commonNextState.resources with
                            {
                                ore = commonNextState.resources.ore - bluePrint.ClayRobotOreCost
                            },
                            robots = commonNextState.robots with { clayRobots = robots.clayRobots + 1 }
                        });
                    }

                    //build obsidian collecting robot
                    if (resources.ore >= bluePrint.ObsidianRobotOreCost && resources.clay >= bluePrint.ObsidianRobotClayCost)
                    {
                        queue.Enqueue(commonNextState with
                        {
                            resources = commonNextState.resources with
                            {
                                ore = commonNextState.resources.ore - bluePrint.ObsidianRobotOreCost,
                                clay = commonNextState.resources.clay - bluePrint.ObsidianRobotClayCost
                            },
                            robots = commonNextState.robots with { obsidianRobots = robots.obsidianRobots + 1 }
                        });
                    }
                }

                return maxGeodesCount;
            }
        }

        [TestMethod]
        public void Test1()
        {
            var bluePrints = BluePrint.ParseBluePrints(realData);
            var timeLimit = 24;
            var res = bluePrints.Select(bluePrint => bluePrint.Id * bluePrint.GetMaxGeodeCount(bluePrint, timeLimit)).Sum();


            Assert.AreEqual(1306, res);
        }

        [TestMethod]
        public void Test2()
        {
            var bluePrints = BluePrint.ParseBluePrints(realData);
            var timeLimit = 32;
            var result = bluePrints
                .Take(3)
                .Select(bluePrint => bluePrint.GetMaxGeodeCount(bluePrint, timeLimit))
                .ToArray();
             ;
            Assert.AreEqual(1306, result
                .Aggregate(1, (acc, current) => acc * current));
        }


        private string[] realData = new[]
        {
            "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 12 clay. Each geode robot costs 3 ore and 8 obsidian.",
"Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 2 ore and 7 obsidian.",
"Blueprint 3: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 4 ore and 11 obsidian.",
"Blueprint 4: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 10 clay. Each geode robot costs 2 ore and 11 obsidian.",
"Blueprint 5: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 2 ore and 9 obsidian.",
"Blueprint 6: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 12 clay. Each geode robot costs 2 ore and 10 obsidian.",
"Blueprint 7: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 10 clay. Each geode robot costs 2 ore and 7 obsidian.",
"Blueprint 8: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 10 clay. Each geode robot costs 3 ore and 14 obsidian.",
"Blueprint 9: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 3 ore and 8 obsidian.",
"Blueprint 10: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 2 ore and 8 obsidian.",
"Blueprint 11: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 19 obsidian.",
"Blueprint 12: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 12 obsidian.",
"Blueprint 13: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 6 clay. Each geode robot costs 2 ore and 20 obsidian.",
"Blueprint 14: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 5 clay. Each geode robot costs 3 ore and 18 obsidian.",
"Blueprint 15: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 7 obsidian.",
"Blueprint 16: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 11 obsidian.",
"Blueprint 17: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 16 obsidian.",
"Blueprint 18: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 3 ore and 8 obsidian.",
"Blueprint 19: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 14 clay. Each geode robot costs 3 ore and 17 obsidian.",
"Blueprint 20: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 3 ore and 14 obsidian.",
"Blueprint 21: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 6 clay. Each geode robot costs 2 ore and 16 obsidian.",
"Blueprint 22: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 3 ore and 14 obsidian.",
"Blueprint 23: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 10 clay. Each geode robot costs 2 ore and 14 obsidian.",
"Blueprint 24: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 4 ore and 13 obsidian.",
"Blueprint 25: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 4 ore and 12 obsidian.",
"Blueprint 26: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 11 clay. Each geode robot costs 4 ore and 12 obsidian.",
"Blueprint 27: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 9 clay. Each geode robot costs 4 ore and 16 obsidian.",
"Blueprint 28: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 2 ore and 7 obsidian.",
"Blueprint 29: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 14 clay. Each geode robot costs 4 ore and 19 obsidian.",
"Blueprint 30: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 15 obsidian.",
        };

    }


}
