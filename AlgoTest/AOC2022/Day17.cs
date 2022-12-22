﻿using System;
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
    public class Day17
    {
        public const int width = 7;
        public const int startOffset = 2;
        public const int startHeight = 3;
        public const long nbrocks = 5;
        public readonly int[] wiggle = new int[5] { 0, 1, 1, 3, 2 };

        public char[,] shapes = new char[,]{
            { '.','.','.','.',
                '.','.','.','.',
                '.','.','.','.',
                '#','#','#','#'},

            { '.','.','.','.',
                '.','#','.','.',
                '#','#','#','.',
                '.','#','.','.'},

            { '.','.','.','.',
                '.','.','#','.',
                '.','.','#','.',
                '#','#','#','.'},

            { '#','.','.','.',
                '#','.','.','.',
                '#','.','.','.',
                '#','.','.','.'},

            { '.','.','.','.',
                '.','.','.','.',
                '#','#','.','.',
                '#','#','.','.'},
        };
        public bool CanMove(Dictionary<long, char[]> grid, int rock, long y, int x)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = x; col < width; col++)
                {
                    if (col - x > 3)
                    {
                        break;
                    }

                    var sh = shapes[rock, row * 4 + col - x];
                    if (sh == '.')
                    {
                        continue;
                    }

                    var gr = grid[y + 3 - row][col];
                    if (gr != '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int SimulateBlock(Dictionary<long, char[]> grid, char[] movementPattern, int p, long maxlevel, long r)
        {
            int rock = (int)(r % (long)nbrocks);
            long y = maxlevel + 1 + startHeight;
            int x = startOffset;

            while (y >= 0)
            {
                // shift
                if (movementPattern[p] == '<')
                {
                    if (x > 0 && CanMove(grid, rock, y, x - 1))
                    {
                        x--;
                    }
                }
                else
                {
                    if ((4 - wiggle[rock] + x < width) && CanMove(grid, rock, y, x + 1))
                    {
                        x++;
                    }
                }

                p++;
                if (p >= movementPattern.Length)
                {
                    p = 0;
                }

                // fall
                if (y > 0 && CanMove(grid, rock, y - 1, x))
                {
                    y--;
                }
                else
                {
                    break;
                }
            }

            // apply
            Apply(grid, rock, y, x);

            return p;
        }
        public void Apply(Dictionary<long, char[]> grid, int rock, long y, int x)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (col < x || (col - x) > 3)
                    {
                        continue;
                    }

                    var sh = shapes[rock, row * 4 + col - x];
                    if (sh != '.')
                    {
                        grid[y + 3 - row][col] = (char)('1' + rock);
                    }
                }
            }
        }
        public char[] ParseInput()
        {
            return realData.ToCharArray();
        }
        [TestMethod]
        public void Test1()
        {
            var movementPattern = ParseInput();
            var grid = new Dictionary<long, char[]>();
            
            for (long i = 0; i < 10000; i++)
            {
                grid[i] = Enumerable.Repeat('.', width).ToArray();
            }

            long maxlevel = -1;
            int p = 0;

            for (long r = 0; r < 2022; r++)
            {
                p = SimulateBlock(grid, movementPattern, p, maxlevel, r);

                foreach (var kv in grid)
                {
                    if (kv.Key >= maxlevel && kv.Value.Any(c => c != '.'))
                    {
                        maxlevel = kv.Key;
                    }
                }
            }
            Assert.AreEqual(3048, maxlevel + 1);
        }
        
        [TestMethod]
        public void Test2()
        {
            var totalCycles = 1000000000000L;
            var theTower = new RockTower(realData);
            var rock = 1;
            var cycleStart = -1;
            var cycleLength = 0L;
            var heightAtCycleStart = 0L;
            var heightOfCycle = 0L;
            var cycleEnd = -1L;
            var towerEnd = -1L;
            var heightAtTowerEnd = 0L;
            var sequentialHeights = new List<long>();
            var previousRows = new Dictionary<(int, int, int, int, int, int, int, int, int), int>();
            while (heightAtTowerEnd == 0)
            {
                var nextRockData = theTower.NextRock();
                if (previousRows.ContainsKey(nextRockData) && cycleLength == 0L)
                {
                    cycleLength = rock - previousRows[nextRockData];
                    cycleStart = previousRows[nextRockData];
                    heightAtCycleStart = sequentialHeights[cycleStart];
                    cycleEnd = cycleStart + cycleLength;
                    towerEnd = (totalCycles - cycleStart) % cycleLength + cycleStart + cycleLength;
                }
                else
                {
                    previousRows[nextRockData] = rock;
                }
                theTower.Push();
                while (theTower.CanFall())
                {
                    theTower.Fall();
                    theTower.Push();
                }
                theTower.UpdateCavern();
                if (cycleLength == 0)
                {
                    sequentialHeights.Add(theTower.GetTowerHeight());
                }
                if (rock == cycleEnd)
                {
                    heightOfCycle = theTower.GetTowerHeight() - heightAtCycleStart;
                }
                if (rock == towerEnd)
                {
                    heightAtTowerEnd = theTower.GetTowerHeight() - (heightAtCycleStart + heightOfCycle);
                }
                rock++;
            }
            var cycleCount = (totalCycles - cycleStart) / cycleLength;
            var totalTowerSize = heightAtCycleStart + cycleCount * heightOfCycle + heightAtTowerEnd;
            Console.WriteLine($"Part 2: {totalTowerSize}");
            //to low
            Assert.AreEqual(1502339181289, totalTowerSize);
        }
        internal class RockTower
        {
            private string wind = "";
            private int windIndex = 0;
            private int rockType = -1;
            private (int, int) location;
            private static readonly int rockTypeCount = 5;
            private static readonly int cavernWidth = 7;
            private static readonly int[] rockWidths = new int[] { 4, 3, 3, 1, 2 };
            private readonly List<HashSet<int>> settledRocks = new List<HashSet<int>>();
            private static readonly Dictionary<int, (int, int)[]> relativeLocations = new()
            {
                [0] = new (int, int)[] { (0, 0), (1, 0), (2, 0), (3, 0) },
                [1] = new (int, int)[] { (1, 2), (0, 1), (1, 1), (2, 1), (1, 0) },
                [2] = new (int, int)[] { (2, 2), (2, 1), (0, 0), (1, 0), (2, 0) },
                [3] = new (int, int)[] { (0, 3), (0, 2), (0, 1), (0, 0) },
                [4] = new (int, int)[] { (0, 1), (1, 1), (0, 0), (1, 0) }
            };
            private static readonly Dictionary<int, (int, int)[]> relativeBottomLocations = new()
            {
                [0] = new (int, int)[] { (0, 0), (1, 0), (2, 0), (3, 0) },
                [1] = new (int, int)[] { (0, 1), (1, 0), (2, 1) },
                [2] = new (int, int)[] { (0, 0), (1, 0), (2, 0) },
                [3] = new (int, int)[] { (0, 0) },
                [4] = new (int, int)[] { (0, 0), (1, 0) }
            };
            private static readonly Dictionary<int, (int, int)[]> relativeLeftLocations = new()
            {
                [0] = new (int, int)[] { (0, 0) },
                [1] = new (int, int)[] { (1, 2), (0, 1), (1, 0) },
                [2] = new (int, int)[] { (2, 2), (2, 1), (0, 0) },
                [3] = new (int, int)[] { (0, 3), (0, 2), (0, 1), (0, 0) },
                [4] = new (int, int)[] { (0, 1), (0, 0) },
            };
            private static readonly Dictionary<int, (int, int)[]> relativeRightLocations = new()
            {
                [0] = new (int, int)[] { (3, 0) },
                [1] = new (int, int)[] { (1, 2), (2, 1), (1, 0) },
                [2] = new (int, int)[] { (2, 2), (2, 1), (2, 0) },
                [3] = new (int, int)[] { (0, 3), (0, 2), (0, 1), (0, 0) },
                [4] = new (int, int)[] { (1, 1), (1, 0) },
            };

            public RockTower(string wind)
            {
                this.wind = wind;
                for (int i = 0; i < cavernWidth; i++)
                {
                    settledRocks.Add(new HashSet<int>());
                }
            }

            public (int, int, int, int, int, int, int, int, int) NextRock()
            {
                rockType = (rockType + 1) % rockTypeCount;
                location = (2, GetTowerHeight() + 4);
                var minColumnHeight = settledRocks.Select(x => x.Count == 0 ? 0 : x.Max()).Min();
                var relativeColumnHeights = new List<int>();
                foreach (HashSet<int> thisColumn in settledRocks)
                {
                    if (thisColumn.Count == 0)
                    {
                        relativeColumnHeights.Add(0);
                    }
                    else
                    {
                        relativeColumnHeights.Add(thisColumn.Max() - minColumnHeight);
                    }
                }
                return (rockType, windIndex,
                    relativeColumnHeights[0],
                    relativeColumnHeights[1],
                    relativeColumnHeights[2],
                    relativeColumnHeights[3],
                    relativeColumnHeights[4],
                    relativeColumnHeights[5],
                    relativeColumnHeights[6]);
            }

            public bool CanFall()
            {
                if (location.Item2 == 1)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < relativeBottomLocations[rockType].Length; i++)
                    {
                        var absoluteX = location.Item1 + relativeBottomLocations[rockType][i].Item1;
                        var absoluteY = location.Item2 + relativeBottomLocations[rockType][i].Item2;
                        if (settledRocks[absoluteX].Contains(absoluteY - 1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void Fall()
            {
                location = (location.Item1, location.Item2 - 1);
            }

            public bool CanSlideLeft()
            {
                if (location.Item1 == 0)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < relativeLeftLocations[rockType].Length; i++)
                    {
                        var absoluteX = location.Item1 + relativeLeftLocations[rockType][i].Item1;
                        var absoluteY = location.Item2 + relativeLeftLocations[rockType][i].Item2;
                        if (settledRocks[absoluteX - 1].Contains(absoluteY))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public bool CanSlideRight()
            {
                if (location.Item1 + rockWidths[rockType] == cavernWidth)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < relativeRightLocations[rockType].Length; i++)
                    {
                        var absoluteX = location.Item1 + relativeRightLocations[rockType][i].Item1;
                        var absoluteY = location.Item2 + relativeRightLocations[rockType][i].Item2;
                        if (settledRocks[absoluteX + 1].Contains(absoluteY))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void Push()
            {
                var nextWind = GetNextWind();
                if (nextWind == '<' && CanSlideLeft())
                {
                    location = (Math.Max(location.Item1 - 1, 0), location.Item2);
                }
                else if (nextWind == '>' && CanSlideRight())
                {
                    location = (Math.Min(location.Item1 + 1, cavernWidth - rockWidths[rockType]), location.Item2);
                }
            }

            public void UpdateCavern()
            {
                for (int i = 0; i < relativeLocations[rockType].Length; i++)
                {
                    var absoluteX = location.Item1 + relativeLocations[rockType][i].Item1;
                    var absoluteY = location.Item2 + relativeLocations[rockType][i].Item2;
                    settledRocks[absoluteX].Add(absoluteY);
                }
            }

            public int GetTowerHeight()
            {
                return settledRocks.Select(x => x.Count == 0 ? 0 : x.Max()).Max();
            }

            public char GetNextWind()
            {
                char nextChar = wind[windIndex];
                windIndex = (windIndex + 1) % wind.Length;
                return nextChar;
            }
        }

        private string testData = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
        
        private string realData = ">>>><<<><<<>><<>>>><>>><<<>><<<>><<<<>>>><>>><<>><<<>>>><<<<>>><<><>>><<<<>>>><>><<><<<><<<><<>><><><<<<>>><<<<><<>>>><<>>>><>><<<<>><<<>><<<<>>><<<>>>><<>>><>><>>><>><<>>>><<><><<<>>><<><><<<<>><<<>>><<<<>>>><<><<>>><<<>>><<<><<<<>>>><<<>><><<<>>><<<>>><<<<><<<>>>><<>>><>>><<<<>>>><>><<<<>><<<>>>><<>><>>>><<<>>><<>><<<>>>><>>>><><<>>>><<<>><<>><<>>>><<<>>><<>>><<<<>>><<<<>>>><<<<>>>><>><<<>>><<>><>>><>>><<>>><>>><<<>>><<<<>><<><<<><>>>><<<><>>>><<<<>>><<<<>><><<<<>>><<><<<<>>><<<<>><>><>>><<<><<<<>>>><><><<<>><<<<>><<<>><<<><<<<>>>><<<<>>><<<>>><>><<<<><<<>><<<>><>><<<<><><>>><<>>>><>>><>>><<<<>><<>><<>><<<>><<><<<<>><><<<<>><<>>>><<>>>><>>><<<>><<<<>><<<>>>><<<<>><<<<>>><<>>>><>>><<<<>>><<<<><<><<<><<<<>><<<>><<<><<<>>><<<<>><<<>>><><<>>><>>>><<<<>>>><<<>>><<>><><>>><<<><<>><>><<>>>><<<<><<>><<<<><<>>><<<<>><<<>>><<<>>>><>><<><<<><>><<<>>>><<<<>>><><<<<><<><<<>><<<<>><<<>><>>><<><<><<>>>><<>>>><<>>>><><<>>>><<<<>>><<<>>><<<>>><<<<>>><<<>><<<<><><><<<>><<<<>>>><<<<>>>><<<>>><<>>>><>>>><<<<>><<<><<<>>>><><><<><<<>>><<>>>><>>><>>><<>><>>>><<<>><><<<><<<<>>><<<<><><><>>><>><>>>><>>>><<<<>><<<>>><<<>>>><<<>><<>>>><<<><<<<>><<><<<>>>><<<<>>><><>>><>>>><<<<>><<><<<>>><<>>><<>><<><<>><>>><<<>><<<<>><>>><<><<>><<<<>><<<>><>>>><<<>>><<>><<><>>><<<<>>>><<<<>><<<>>>><><<>><<>>><><<<<>>>><<<<>><>>>><<<>>><<<>>>><<<<>><<><<<<>><><<>>><<<<>>>><<<<>>><<><<<>>><<<<>>><<<<><<<<>>>><<>>>><<>>><<>><<<<><<<>><<<>>>><<<<>>><<<<><>>>><<<<>>>><<<><<<>>>><<>>><<<<>>><<<<><<<>><<<<><>>><>>><<<<>>><>><<>>>><<<>><<><<<>>>><<<>>>><<<>>><<<<>>>><<>>><<<><<<<>>><<<>><<<<><><>><<>>>><<>><<><<>>>><<<>>>><<<<><>><>>><<>>><><<<>>>><<>><<><<<<>>>><<<>>><<<<>>>><<<>><<<<><<<<>><<><>>><>><<>>>><<<<>>>><<<>>><><<><<><>>>><<>>>><<<><>>><<<>><<<<>>><><<<><<>>>><><<>>><<<<>><<>>><<>>>><<<<>>>><<>>><><>>>><<<<>>><<<<>>><<<<>>>><<<>><>>><<<<><<<>><<<<>>><>><<>><<<<><<<><<>>><>>><<<>><<<>>><<>><<><>><<<>>>><>>><<<<>><<>>>><<<>>><<><<<>>>><<<><<<>>>><<<<>>><>>><>><<<>>>><<<<>>><<<>>>><<>><<<<>>>><>><>>><<<>>>><>>>><<>><<<><><<>>><<<>>>><>>>><>>><<><<<<>>>><<<>>>><<<>>><<<<>>><>>>><<<>>>><<<><<<>><<<<><<<><<<<><<<>>>><>><>><<<>><<<><<<><><<<>>><<>>>><<<<>>>><<>>>><>><<<>>><<><<<<><<<<>>>><<>>><<<><>>><>>><<<>>><>><<<<><<<<>>>><<>>>><>><<<<><><><<><<>>>><<>><>><>>>><<>>>><<<<>>>><>><>>><<<>>><<>><<<>>><><<<><<<>><<><<>>>><>>>><<>>>><><<<>>>><<<>>>><<<>>><<>>>><<>>>><<<>>><<<<>>>><<<<>><>>>><<>>><<<>>><<>>>><<<<>><<<>><<><>>>><<<>>><<>>>><<<<>>>><<>><<<>>><>><>><>>><><<>><<<>><<><<>>><>>>><<><>>><<<<><<<<>><>><<<<>>><<<>>>><>><<<>>><<<<>>>><<<>>>><<>><<><<<>>><><>><>><>>>><><<<>>><<>>>><<<<>><><<>>>><<<>>><<>><<<>><<<><<>><<>>><<>>><>><<>>>><<><<<<><<<<>>><<<<>>>><<>>><<>><<<><<<><<<>>><<<<>><>>><<>>><<>>>><<>>>><<>>>><<<>><><<<<><>><<><<<>><<<<>>>><<<<>>>><<<><<<>><<<>>><>><>>>><<<<>>><<<>>><>>>><<<>>>><>><<<><<><<<>>>><<<>>><>>><<<>>><<<><<>>>><<<>><<><<>><<<><<<<>>><<<>><<>>><<<<>><>>>><<>>><<><<<<>><><<>>>><<<><<>><<>><<>>><<<<>>>><<<<>>><<<><<<<>>><<<>>><>>><<>><<<<><>>><<<<>><<<<>>><<><<<<>>><<<>>><<<<>><<<<>>>><><><<>>>><>><<<><><<<<>>><><<<<>>>><><><<<>>><>><<<<><>><<<<>>>><<>>>><<<>>><>>><>>><><>>>><<>><<<>>>><<<>>>><<<>>>><<<<>>>><<<><>><<<<>>>><<><<<<><<<>>>><<><>>>><<><<<>>>><><<<><<>><<<<>><<>><>><<<>><<<>>><>>>><>>>><<><<<>><<<>>>><<<<><<<>>><>><<>>><<>>><<<>>><<>>><>><<>>><<<<><<>><<<<>><<<>><>>>><>><><<<>><<<>><>>><<<<><<<>><<>><<<<>>>><<<<>>><>>><<<>>>><<<>>>><<<>><<<>>>><<<>><<<>><<<<>>><><<>><<<<>><>><<>><<<>><<<>>><<<<>>>><<<><<<<>>>><>>><<<<>>><<>>>><<<<>>><>>>><<<>><>>>><<><<>>><>>>><<>>>><<<>><<<><<<<>>><<<>>><<<>>>><<><>>>><<<>>>><<<<>>>><>>><<<><>><<>>>><<<<>>><>>><<<<>>><<<<>><<<<>><<<>><<>>><<<>>>><><<>>><>>>><<>>><<<<><<><<>>>><<<<>><<<<>>>><<<>><<><<>><<<<>>>><>><<<<>><<<>>><>>>><<<>>>><<><<<<><<<>><<<>>><<<<>>><<<>>><<<>>>><<<>>><><<<>>><>><<<>>><<>>><><<<>>>><<<<>>>><<<><<<<>>><<><<<>>><<<<>><<<>><>>>><<<>><<><<<<>>>><>><<<<>><<<>>><<>>><<<>>><<<>>><<<<>>><<<<><>>><>><><<<<>><<<>>><<<<><<<>>><<>><>><<>>>><<>>>><>>>><<><<>><>>>><<><<<<><<<<>>><>><<>>>><<<<>>><>>><<<<><<>><<><<<>>>><<>>>><<>>>><<<<><<>><>><><<<>><<<<>>><<<><<<>><>><<<>><><>>>><><<<>>><<<<><<<<>>><<<>>>><>>><<>>><<>>>><>>>><><<<<>>>><<<>>>><<<>><<>>><<><<<>>>><<<>>><<<><><>><<<>>><<<>>>><<>><<<<>><><<<<>><<<>><<<<><<>>>><<>>><<>><<>>>><<>>><<>>><<<<>>>><>>><<>>><<<>>><>>>><<<><<<<>><<><<<<>><<<>><<<>>><<<<>><>><<>><<<>>>><<>>><<<>><<>>>><<<<>><<>>>><<<>>><<<<><<<>>>><<<>>><<<>><<><>>>><<<<><<<<>>><<<<>>>><>>><><>>>><<<>>><<<<>>>><>>>><<<>>>><<><<<<>>><<>><<<<>><<<><<><<<>><<<>>><<<>>><<>>>><<<<>>><<>>><<>><><<<<>>><<<<>>>><><<><>><<<>>>><<<><<>>><<>>>><<<>>><>>>><>><>>><<<><>><<<<>>><>>><>><>><<<<>>><<>>><>>>><<<>><<>>><<<>><<<>><<<<><<>>>><>>><>><<<<>>>><><<<><<><<>>><<><<<>>>><<>><<>>><<<>>>><<>>>><<><<>>><>>>><<>><<<>><><>><<<>>>><<>><>><<>>>><<<<>>>><<<<>>>><<<><<>><<<<>>><<<<>>><<<<>>><<<<>><<<<>>><<<>><<>>><<<<>>><<>>>><<<>><>><>>><>>>><>><<<<><><<>>>><>>><<<>>>><<<>>>><<>>><<<<>><>>><<<<>>>><><<<<><<>><>>>><>>><<>>>><><<><<<<>><<<><><<<<>><<>>>><<<<>><>><<>><<>><<><<<>>><><>>><<<>>>><<<<><>>>><><>>>><<<<>>><<>><<>><<<<>>>><<>>>><<<<>>>><><<<><<>>><<<<>>>><<>>>><>>>><<<<>><<<>><<>>><<<<>>>><<<<>>>><<<<>><<<<><>>>><>>><<<<><<<<>>>><<<><<<<><<>>><>>>><<<>>><<<<>>><<>>>><<>>><<<<><<<<>>>><>>>><<<>><<<<>><>>>><>>><<<<>>>><>>>><<>>><<<>>>><>><<<<>>><<>>><<><<<><<<<>><<<<>><<><<<<><<<>>><<>>>><<<><<<<>>><<>><<<<>>>><>><<>>><<<<>>>><<<>>>><><>>><>>><<<<><>><<>>>><>>>><<>>>><<<<><>>>><<<>>>><<<<>>>><>><<<<><<<<>><<<>><<>>><<><<>>><<>><>>>><><<<>>>><<<<><<<>><<<<><<><>>><<>>>><<><<<<>><><<<>>><<<<>>><<<<><<<<>><>>>><<><<<>>><<>><<<<>>>><>>>><>>>><>><<<<><<<>>>><<<>><<<>>>><>>>><<<<>>>><<<>>>><<><<><<>><<><<<>>><<<<>><>>><<><<<<>><<<<>>>><<<<>>><<>>>><>><<<<>><><<<<>><<>><<<<>>>><<>>>><<<<>><>>><<<>><<><>>><<>><<<><<<<>>><>>>><<>><<>>><<>><<><<>>><<<<><<>>>><<>>>><<>><>>>><<>><>><>><<<<>>>><>>>><<<>>>><<<<>>>><<><<>>><><<>>><>>><><<<>><<<<>>><<<><<<<>>>><<<>>>><><>>><<<><<<>>><<<<><<<<>>><<>><<>><><<>>><<<><<<<>><>><<><<<>>><<>>><<>>>><>><>>><<<>><>>>><<<<><<<<>>>><><>>><>><><<<>>>><<<<>><<>><><>>><<<><<><<>>>><<<>>><>>>><<<<>>>><>><<<<><>>>><>>>><<<>>><<><<>>>><<>>><<<>>><<<>>><><<<>><<<<>>>><<>>>><<<<>>><<<>>><<<<><<>><>>>><>>>><<><<<<>><<<<>>><<<<>>><>>><><<>><<<><<<><<<>><<>>>><>><>>><><<<><<><>>>><<<<><<<>>>><><<><>>><<<<>>><<<>><<<<>>><<>>>><>>><>><<>><<<<>><<><<>><>>>><<>>><<<>><><<>>>><<>>><<>><<>><<<>>><<<>>>><<<<><<<<>>><<<>><>>><<<>><<<>>><<<>>>><<<<>><<<<>>><<><<<<>>><><<>>>><<<><<<<>>><<<<>>><<<>>>><<><<<<>>>><>>><<><<<<>>><>>>><<<<>>><><<<>>><>>><<>>>><<<>>><<<<>><<<<>><<>>><<<<>><>>>><<<<>>>><<<<>>><>><<>>>><<<<>>>><<<<>><<<>>><<<>>><>>><>>>><>><><>><<><<><><<>><>>><<<><<<>><<<>><<<>>><>><<>>>><<>><<<>>>><><<<><<>><<<<><<<><<>>>><>><<><<>><<>>><<<><>>><<<>>>><<<<>><<>>>><<<>>>><><>>><><<<<><<>>><>><<<><<<>>>><><>>>><>>>><<<<>>><><<<>><<<>>><<>>><<<><<<<>><<>>>><<<>>>><<>><<><<<>>>><<>>><<<>><><<><<<<>>><><>>>><<>><><<<<>>>><>>>><<<<><<>>>><<>>>><<<<><>><<<>>>><<<<><<<<>>><<<>><<<<><<<>>><>>>><<<<>>><<<>>><<>>><<>><<<><<<>>><<<>>>><<<><<<<>>><<<>><>>>><>><<<<>>>><><<<>><<>>>><<<<>>><><>><<>><>>><<<>>><>>>><<<<><><<<<>><<>>>><<<<>>><<><<<<>>><<<>>>><<<<><>>><>><><<>><<<><>>><<<><><<>><<<>><<<<><<<>>>><><><<<<><<<>>>><>>>><<>>><<>>><<<>><<>>><<<><<>>>><><<><><>>><<<>><<<<><<<><<>><<><<<>>>><<>>>><<><>>>><<>>><<<<><<<<><<<<>><<<<>>>><<><<<><>>><<<<>>><<<>><<<<>>>><<<>>>><<<>><<><><><><<><<<<><<<>><<<>><<<>><>><<<<>><<>>><<><<>>><<<><<<<>><<<>>>><<>>>><>>><<><>><<<<>>><>><<<>>><<<><<>>>><<<<>>><<<<>>><<<<>>><>>><>>><>><<>>>><<<><<<><<<>><<<>><<<>><<<>>><>>><<>>><<<<><>>><<<<><<<>>><<<>>>><<<<>>><<>><>>><>>><>><<<<>>><<<<><><<<><<>><<<>>>><<<>>><<><>>><<>><>>><<<>>>><<<>>>><<<><>>>><<><<><<<<>>><<<<><<><<>>>><<<>><<<<>>>><<<<>>>><><<<<>><<>>><<<<>>>><<>>><<<>>><>>><>>>><<<>><><<>>><<<>>><<><<<><<<<><<<<><>><<>>><<<<>>>><<<><<><<<<>>>><<<>><<<<><<>><<<><<<>><<<>>>><<<<>>><<<>><<<<><<<>>><<<<>><<>>>><<<>><<><<<<><<<>><>>><>>><<>>>><<<<><<<><<<<>><<<<>>>><><>>><<>>>><<>>><>><<>>><<<>>>><<<>><>>><<>><<><<<>>><<<><<<>>>><<>>>><<<<>>><<>>>><<<>>>><<><>>><<>>><<>>><<<>>><><<><<<<>><<>><><<<>>>><<<>>><<<><><<<<><<<<><<>>>><>>><>>><<<>>><<>>><<<<>>>><<<><<><<<<><<<><<<<>>><>>>><>>>><<<>>><<<<>>>><<<>><<>><<>>><<>><><<>>><<<>>><<>><<<<>><<<>>><<>><<<<>><>><><>>><><<<<>>>><<>>>><<<>><><<<<>><<<<><<<>><<<<>><><<<><<>><<<>>>><>><<<>>><><<<<>><<>><<>>>><<>><<<<>><<<<>><<>><<<<><<<<>>><<<><<<<>>>><<><>><<<<><>>><<<<><<><<<<>><>><<><<<>>>><<<<>>>><<<<><<>>>><<<<><<<><<>><>><<<>>>><>><<>>><<<<><<>>><<><<<<>><<><<<>><>><<<>>>><<<<><<<<>><>><<<>><<<>>><<>>><<<<>>><<>>><<<<><<<<>><<<<>>><<<>><><<<><>><<<<><<<<>><<<<><<<>>>><<><<><>>><<<<>><<<<>>>><>>><>><<>><<>><<<<>><>>>><<<<>>>><<<>>>><<>><><<<<>>><<<<>>>><<<>>><<><>>><<<<>>>><<<<>>>><<><>>>><<<<><<<><<<<>>><<<<><<<>>>><<<<>><<<>>><<<>>>><<><<><>>>><>>>><<<<>><>><<>>><<<><><<>>><<<>><<>>><<<><<<>>><<>>><<>>>><<<><>>>><><<<>>><>><<<>><<><<<>>><>>><<<<>>>><<<>>><>>><<>><<<>>><>><<>><>>>><<<<><<<>>>><><<<<><<<<><<<<><<>>>><<>>>><<>><<<<>><<<>>><<><<<>>>><<<<>>>><<<>>>><<<><<<>>>><<>>>><<<<>><>><<>>>><>>>><<<>><<<>><>>>><<<>>><>><>>>><>><<<<>><<>>><>><<>>><<<<>><><<<>><<<<>>><>>>><<<<>>><<<><<<>><<><<>>>><>>><<<><<>><<<><<>>>><><<<<>><<<>>><<>>><>>>><>>><>>>><<<><>><<<>>>><>>><<<>>><<><<>><<<<><<><>><<<>>><<<>>><<<>>>><<<><<<<>>><<<<><<<><<<>>>><<>>><>>>><<<>><<>>>><<><<<<><<<<>><<>>><<><<>><<><>>>><>><<<<>>><<<<>>>><<<><<<<>>>><>>>><<<><<>><<>>><<<<>><<>><<>>>><>>><>>><<>><>>><<>><<<<>>><><<>>><<<<>><<<>>><<<>><><<<<>><<<<>>><<<>><<<>>><>>>><<<>>>><<>>><>><>><<<<>>>><<<>>>><<>><<<<>>><<<<>>><><>><<><>>>><<<<>><<>>><>>>><<<><<<<>>>><>>><<<<>>>><<><<<<>>><<<<>>><<<<>>>><><<>><<>><<<>><<><<<>>>><<<>>>><<>><<<<>><>><<<>>>><<<<><<<>>>><<<>>><<<<>>>><<>>>><<<><<<<>>>><><>><<>>><<<<><><<>>>><<<>>>><<<><<<<>><<<<>>><<<><<<>><<><<<>>>><<>>><>><>><<>>>><><<><<<<>>><<>>>><<<<>>><<<<><><<<><<<>>><<><<>>>><<<>>><<<>><<>>>><<<<>>>><>><<>>><<>>>><<<><<>>>><<<>>>><<<<>>>><<<<><<<<><<<><<<<>>>><<>>><<>>><<>><<><<>>><<<>>>><>><<<><<>>>><<>><<><<<>>>><>><>>>><<>>>><><>><<<<><<<<>>><<<><<>><<>>><<<<>>>><>>>><<><<<>>><<<>>>><<>>><<>><<>";
    }


}
