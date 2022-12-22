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
    public class Day17Part2
    {
        public string[,] grid;
        public List<string[]> rockFormations = new List<string[]>();
        public int highestRock = 500000000;
        public long partBRocks = 500000000;
        int commandsSize;
        char[] commands;
        int arrayLength;
        int arrayWidth = 7;
        int currentHighestPlace;

        public void solveRocks(int spaceHeight, long totalRocks)
        {

            arrayLength = spaceHeight;
            currentHighestPlace = arrayLength;
            int findMatchLimit = 1000;
            int lastHeight = arrayLength;
            List<int> foundPatternAt = new List<int>();
            List<int> differences = new List<int>();
            grid = new string[arrayLength, arrayWidth];
            createGrid(arrayLength, arrayWidth);
            int listSize = rockFormations.Count;

            int commandIndex = 0;
            for (int i = 0; i < totalRocks; i++)
            {
                int lowestY = 7;
                int highestY = -1;
                int currentRockIndex = (i < 5 ? i : i % listSize);
                string[] rockFormation = rockFormations[currentRockIndex];
                List<string> fallingRocks = new List<string>();
                foreach (string coord in rockFormation)
                {
                    string[] parts = coord.Split(",");
                    int x = Int32.Parse(parts[0]);
                    int y = Int32.Parse(parts[1]);
                    int startingX = currentHighestPlace - Math.Abs(x) - 4;
                    fallingRocks.Add(startingX + "," + y);
                    if (y < lowestY)
                    {
                        lowestY = y;
                    }
                    if (y > highestY)
                    {
                        highestY = y;
                    }
                }

                bool rested = false;
                bool foundRested = false;
                bool foundRestedBeforeMove = false;

                while (!rested)
                {
                    // First we move with the jet
                    List<string> fallingRocksMoved = new List<string>();
                    List<string> fallingRocksBeforeMoved = fallingRocks.Select(i => new string(i)).ToList();
                    int newLowY = lowestY;
                    int newHighY = highestY;
                    foundRestedBeforeMove = false;
                    foreach (string rock in fallingRocks)
                    {
                        string[] parts = rock.Split(",");
                        int x = Int32.Parse(parts[0]);
                        int y = Int32.Parse(parts[1]);
                        int currentCommandIndex = (commandIndex < commandsSize ? commandIndex : commandIndex % commandsSize);
                        char command = commands[currentCommandIndex];
                        if (command == '<' && lowestY > 0)
                        {
                            // Push left
                            y = y - 1;
                            newLowY = lowestY - 1;
                            newHighY = highestY - 1;
                            if (grid[x, y] == "#")
                            {
                                // Can't move there!
                                foundRestedBeforeMove = true;
                            }
                        }
                        else if (command == '>' && highestY < 6)
                        {
                            // Push right
                            y = y + 1;
                            newLowY = lowestY + 1;
                            newHighY = highestY + 1;
                            if (grid[x, y] == "#")
                            {
                                // Can't move there!
                                foundRestedBeforeMove = true;
                            }
                        }
                        fallingRocksMoved.Add(x + "," + y);
                    }
                    commandIndex++;
                    if (foundRestedBeforeMove)
                    {
                        fallingRocksMoved = fallingRocks.Select(i => new string(i)).ToList();
                    }
                    else
                    {
                        highestY = newHighY;
                        lowestY = newLowY;
                    }
                    List<string> fallingRocksMovedDown = new List<string>();
                    foreach (string rock in fallingRocksMoved)
                    {
                        string[] parts = rock.Split(",");
                        int x = Int32.Parse(parts[0]);
                        int y = Int32.Parse(parts[1]);
                        x = x + 1;
                        if (x >= arrayLength)
                        {
                            //Found the bottom!
                            foundRested = true;
                        }
                        else if (grid[x, y] == "#")
                        {
                            // Can't move there!
                            foundRested = true;
                        }
                        else
                        {
                            fallingRocksMovedDown.Add(x + "," + y);
                        }

                    }
                    fallingRocks = fallingRocksMovedDown.Select(i => new string(i)).ToList();

                    if (foundRested)
                    {
                        if (foundRestedBeforeMove)
                        {
                            fallingRocks = fallingRocksBeforeMoved.Select(i => new string(i)).ToList();
                        }
                        else
                        {
                            fallingRocks = fallingRocksMoved.Select(i => new string(i)).ToList();
                        }

                        foreach (string rock in fallingRocks)
                        {
                            string[] parts = rock.Split(",");
                            int x = Int32.Parse(parts[0]);
                            int y = Int32.Parse(parts[1]);
                            grid[x, y] = "#";
                            if (x < highestRock)
                            {
                                highestRock = x;
                                currentHighestPlace = highestRock;
                            }

                        }



                        rested = true;
                    }
                }
                int diffToAdd = (lastHeight - currentHighestPlace);
                differences.Add(diffToAdd);
                lastHeight = currentHighestPlace;


                // NOW WE LOOK FOR A PATTERN
                if (i >= (2 * findMatchLimit))
                {
                    // Check for patterns?
                    string differencesString = System.String.Join("-", differences.ToArray());


                    List<int> differencesRecent = new List<int>();
                    differences.GetRange((differences.Count() - findMatchLimit), (differences.Count() - (differences.Count() - findMatchLimit))).ForEach(h => differencesRecent.Add(h));
                    string differencesRecentSearch = System.String.Join("", differencesRecent.ToArray());

                    List<int> differencesPrevious = new List<int>();
                    differences.GetRange(0, (differences.Count() - findMatchLimit)).ForEach(h => differencesPrevious.Add(h));
                    string differencesPreviousSearch = System.String.Join("", differencesPrevious.ToArray());

                    int foundRepeat = differencesPreviousSearch.LastIndexOf(differencesRecentSearch);

                    if (foundRepeat >= 0)
                    {

                        int patternLength = i - findMatchLimit - foundRepeat + 1;
                        if (patternLength > findMatchLimit)
                        {
                            findMatchLimit = patternLength;
                            continue;
                        }

                        // We have a pattern, we now need to do some things
                        // First, how high is the pattern?
                        List<int> differencesPattern = new List<int>();
                        differences.GetRange(foundRepeat, patternLength).ForEach(h => differencesPattern.Add(h));
                        string differencesPatternString = System.String.Join("", differencesPattern.ToArray());

                        long remainingSteps = totalRocks - foundRepeat;
                        long multiple = (long)Math.Floor(Convert.ToDouble(remainingSteps) / Convert.ToDouble(patternLength));
                        int remainder = Convert.ToInt32(remainingSteps % patternLength);

                        long int4 = differencesPattern.Sum(g => Convert.ToInt32(g));

                        long newInt = differences.GetRange(0, foundRepeat).Sum(g => Convert.ToInt32(g));
                        long newInt2 = multiple * int4;
                        long newInt3 = differencesPattern.GetRange(0, remainder).Sum(g => Convert.ToInt32(g));
                        partBRocks = newInt + newInt2 + newInt3;
                        return;
                    }

                    if (i > 20000)
                    {
                        return; // Lets put this here to stop it going on forever
                    }
                }

            }
        }

        public string printGrid(int xSize, int ySize)
        {
            string output = "\nGrid:\n";
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    string toWrite = grid[x, y];
                    output += "" + toWrite;
                }
                output += "\n";
            }
            return output;
        }

        public void createGrid(int xSize, int ySize)
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    grid[x, y] = ".";
                }
            }
        }
        public void createRockFormations()
        {
            // First rock formation
            string[] rockFormation = new string[4];
            rockFormation[0] = "0,2";
            rockFormation[1] = "0,3";
            rockFormation[2] = "0,4";
            rockFormation[3] = "0,5";
            rockFormations.Add(rockFormation);
            string[] rockFormationSecond = new string[5];
            rockFormationSecond[0] = "-2,3";
            rockFormationSecond[1] = "-1,2";
            rockFormationSecond[2] = "-1,3";
            rockFormationSecond[3] = "-1,4";
            rockFormationSecond[4] = "0,3";
            rockFormations.Add(rockFormationSecond);
            string[] rockFormationThird = new string[5];
            rockFormationThird[0] = "-2,4";
            rockFormationThird[1] = "-1,4";
            rockFormationThird[2] = "0,2";
            rockFormationThird[3] = "0,3";
            rockFormationThird[4] = "0,4";
            rockFormations.Add(rockFormationThird);
            string[] rockFormationFourth = new string[4];
            rockFormationFourth[0] = "-3,2";
            rockFormationFourth[1] = "-2,2";
            rockFormationFourth[2] = "-1,2";
            rockFormationFourth[3] = "0,2";
            rockFormations.Add(rockFormationFourth);
            string[] rockFormationFifth = new string[4];
            rockFormationFifth[0] = "-1,2";
            rockFormationFifth[1] = "-1,3";
            rockFormationFifth[2] = "0,2";
            rockFormationFifth[3] = "0,3";
            rockFormations.Add(rockFormationFifth);

        }


        public string output;

        [TestMethod]
        public void Test2()
        {
            commands = realData.ToCharArray();
            commandsSize = commands.Length;
            createRockFormations();
            solveRocks(45000, 2022);
            int highRock = arrayLength - highestRock;
            output += "Part A: Highest Rock: " + highRock;
            highestRock = 500000000;
            solveRocks(45000, 1000000000000);
            output += "\nPart B: Highest Rock: " + partBRocks;

            Assert.AreEqual(1504093567249, partBRocks);
        }
       

        private string testData = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
        
        private string realData = ">>>><<<><<<>><<>>>><>>><<<>><<<>><<<<>>>><>>><<>><<<>>>><<<<>>><<><>>><<<<>>>><>><<><<<><<<><<>><><><<<<>>><<<<><<>>>><<>>>><>><<<<>><<<>><<<<>>><<<>>>><<>>><>><>>><>><<>>>><<><><<<>>><<><><<<<>><<<>>><<<<>>>><<><<>>><<<>>><<<><<<<>>>><<<>><><<<>>><<<>>><<<<><<<>>>><<>>><>>><<<<>>>><>><<<<>><<<>>>><<>><>>>><<<>>><<>><<<>>>><>>>><><<>>>><<<>><<>><<>>>><<<>>><<>>><<<<>>><<<<>>>><<<<>>>><>><<<>>><<>><>>><>>><<>>><>>><<<>>><<<<>><<><<<><>>>><<<><>>>><<<<>>><<<<>><><<<<>>><<><<<<>>><<<<>><>><>>><<<><<<<>>>><><><<<>><<<<>><<<>><<<><<<<>>>><<<<>>><<<>>><>><<<<><<<>><<<>><>><<<<><><>>><<>>>><>>><>>><<<<>><<>><<>><<<>><<><<<<>><><<<<>><<>>>><<>>>><>>><<<>><<<<>><<<>>>><<<<>><<<<>>><<>>>><>>><<<<>>><<<<><<><<<><<<<>><<<>><<<><<<>>><<<<>><<<>>><><<>>><>>>><<<<>>>><<<>>><<>><><>>><<<><<>><>><<>>>><<<<><<>><<<<><<>>><<<<>><<<>>><<<>>>><>><<><<<><>><<<>>>><<<<>>><><<<<><<><<<>><<<<>><<<>><>>><<><<><<>>>><<>>>><<>>>><><<>>>><<<<>>><<<>>><<<>>><<<<>>><<<>><<<<><><><<<>><<<<>>>><<<<>>>><<<>>><<>>>><>>>><<<<>><<<><<<>>>><><><<><<<>>><<>>>><>>><>>><<>><>>>><<<>><><<<><<<<>>><<<<><><><>>><>><>>>><>>>><<<<>><<<>>><<<>>>><<<>><<>>>><<<><<<<>><<><<<>>>><<<<>>><><>>><>>>><<<<>><<><<<>>><<>>><<>><<><<>><>>><<<>><<<<>><>>><<><<>><<<<>><<<>><>>>><<<>>><<>><<><>>><<<<>>>><<<<>><<<>>>><><<>><<>>><><<<<>>>><<<<>><>>>><<<>>><<<>>>><<<<>><<><<<<>><><<>>><<<<>>>><<<<>>><<><<<>>><<<<>>><<<<><<<<>>>><<>>>><<>>><<>><<<<><<<>><<<>>>><<<<>>><<<<><>>>><<<<>>>><<<><<<>>>><<>>><<<<>>><<<<><<<>><<<<><>>><>>><<<<>>><>><<>>>><<<>><<><<<>>>><<<>>>><<<>>><<<<>>>><<>>><<<><<<<>>><<<>><<<<><><>><<>>>><<>><<><<>>>><<<>>>><<<<><>><>>><<>>><><<<>>>><<>><<><<<<>>>><<<>>><<<<>>>><<<>><<<<><<<<>><<><>>><>><<>>>><<<<>>>><<<>>><><<><<><>>>><<>>>><<<><>>><<<>><<<<>>><><<<><<>>>><><<>>><<<<>><<>>><<>>>><<<<>>>><<>>><><>>>><<<<>>><<<<>>><<<<>>>><<<>><>>><<<<><<<>><<<<>>><>><<>><<<<><<<><<>>><>>><<<>><<<>>><<>><<><>><<<>>>><>>><<<<>><<>>>><<<>>><<><<<>>>><<<><<<>>>><<<<>>><>>><>><<<>>>><<<<>>><<<>>>><<>><<<<>>>><>><>>><<<>>>><>>>><<>><<<><><<>>><<<>>>><>>>><>>><<><<<<>>>><<<>>>><<<>>><<<<>>><>>>><<<>>>><<<><<<>><<<<><<<><<<<><<<>>>><>><>><<<>><<<><<<><><<<>>><<>>>><<<<>>>><<>>>><>><<<>>><<><<<<><<<<>>>><<>>><<<><>>><>>><<<>>><>><<<<><<<<>>>><<>>>><>><<<<><><><<><<>>>><<>><>><>>>><<>>>><<<<>>>><>><>>><<<>>><<>><<<>>><><<<><<<>><<><<>>>><>>>><<>>>><><<<>>>><<<>>>><<<>>><<>>>><<>>>><<<>>><<<<>>>><<<<>><>>>><<>>><<<>>><<>>>><<<<>><<<>><<><>>>><<<>>><<>>>><<<<>>>><<>><<<>>><>><>><>>><><<>><<<>><<><<>>><>>>><<><>>><<<<><<<<>><>><<<<>>><<<>>>><>><<<>>><<<<>>>><<<>>>><<>><<><<<>>><><>><>><>>>><><<<>>><<>>>><<<<>><><<>>>><<<>>><<>><<<>><<<><<>><<>>><<>>><>><<>>>><<><<<<><<<<>>><<<<>>>><<>>><<>><<<><<<><<<>>><<<<>><>>><<>>><<>>>><<>>>><<>>>><<<>><><<<<><>><<><<<>><<<<>>>><<<<>>>><<<><<<>><<<>>><>><>>>><<<<>>><<<>>><>>>><<<>>>><>><<<><<><<<>>>><<<>>><>>><<<>>><<<><<>>>><<<>><<><<>><<<><<<<>>><<<>><<>>><<<<>><>>>><<>>><<><<<<>><><<>>>><<<><<>><<>><<>>><<<<>>>><<<<>>><<<><<<<>>><<<>>><>>><<>><<<<><>>><<<<>><<<<>>><<><<<<>>><<<>>><<<<>><<<<>>>><><><<>>>><>><<<><><<<<>>><><<<<>>>><><><<<>>><>><<<<><>><<<<>>>><<>>>><<<>>><>>><>>><><>>>><<>><<<>>>><<<>>>><<<>>>><<<<>>>><<<><>><<<<>>>><<><<<<><<<>>>><<><>>>><<><<<>>>><><<<><<>><<<<>><<>><>><<<>><<<>>><>>>><>>>><<><<<>><<<>>>><<<<><<<>>><>><<>>><<>>><<<>>><<>>><>><<>>><<<<><<>><<<<>><<<>><>>>><>><><<<>><<<>><>>><<<<><<<>><<>><<<<>>>><<<<>>><>>><<<>>>><<<>>>><<<>><<<>>>><<<>><<<>><<<<>>><><<>><<<<>><>><<>><<<>><<<>>><<<<>>>><<<><<<<>>>><>>><<<<>>><<>>>><<<<>>><>>>><<<>><>>>><<><<>>><>>>><<>>>><<<>><<<><<<<>>><<<>>><<<>>>><<><>>>><<<>>>><<<<>>>><>>><<<><>><<>>>><<<<>>><>>><<<<>>><<<<>><<<<>><<<>><<>>><<<>>>><><<>>><>>>><<>>><<<<><<><<>>>><<<<>><<<<>>>><<<>><<><<>><<<<>>>><>><<<<>><<<>>><>>>><<<>>>><<><<<<><<<>><<<>>><<<<>>><<<>>><<<>>>><<<>>><><<<>>><>><<<>>><<>>><><<<>>>><<<<>>>><<<><<<<>>><<><<<>>><<<<>><<<>><>>>><<<>><<><<<<>>>><>><<<<>><<<>>><<>>><<<>>><<<>>><<<<>>><<<<><>>><>><><<<<>><<<>>><<<<><<<>>><<>><>><<>>>><<>>>><>>>><<><<>><>>>><<><<<<><<<<>>><>><<>>>><<<<>>><>>><<<<><<>><<><<<>>>><<>>>><<>>>><<<<><<>><>><><<<>><<<<>>><<<><<<>><>><<<>><><>>>><><<<>>><<<<><<<<>>><<<>>>><>>><<>>><<>>>><>>>><><<<<>>>><<<>>>><<<>><<>>><<><<<>>>><<<>>><<<><><>><<<>>><<<>>>><<>><<<<>><><<<<>><<<>><<<<><<>>>><<>>><<>><<>>>><<>>><<>>><<<<>>>><>>><<>>><<<>>><>>>><<<><<<<>><<><<<<>><<<>><<<>>><<<<>><>><<>><<<>>>><<>>><<<>><<>>>><<<<>><<>>>><<<>>><<<<><<<>>>><<<>>><<<>><<><>>>><<<<><<<<>>><<<<>>>><>>><><>>>><<<>>><<<<>>>><>>>><<<>>>><<><<<<>>><<>><<<<>><<<><<><<<>><<<>>><<<>>><<>>>><<<<>>><<>>><<>><><<<<>>><<<<>>>><><<><>><<<>>>><<<><<>>><<>>>><<<>>><>>>><>><>>><<<><>><<<<>>><>>><>><>><<<<>>><<>>><>>>><<<>><<>>><<<>><<<>><<<<><<>>>><>>><>><<<<>>>><><<<><<><<>>><<><<<>>>><<>><<>>><<<>>>><<>>>><<><<>>><>>>><<>><<<>><><>><<<>>>><<>><>><<>>>><<<<>>>><<<<>>>><<<><<>><<<<>>><<<<>>><<<<>>><<<<>><<<<>>><<<>><<>>><<<<>>><<>>>><<<>><>><>>><>>>><>><<<<><><<>>>><>>><<<>>>><<<>>>><<>>><<<<>><>>><<<<>>>><><<<<><<>><>>>><>>><<>>>><><<><<<<>><<<><><<<<>><<>>>><<<<>><>><<>><<>><<><<<>>><><>>><<<>>>><<<<><>>>><><>>>><<<<>>><<>><<>><<<<>>>><<>>>><<<<>>>><><<<><<>>><<<<>>>><<>>>><>>>><<<<>><<<>><<>>><<<<>>>><<<<>>>><<<<>><<<<><>>>><>>><<<<><<<<>>>><<<><<<<><<>>><>>>><<<>>><<<<>>><<>>>><<>>><<<<><<<<>>>><>>>><<<>><<<<>><>>>><>>><<<<>>>><>>>><<>>><<<>>>><>><<<<>>><<>>><<><<<><<<<>><<<<>><<><<<<><<<>>><<>>>><<<><<<<>>><<>><<<<>>>><>><<>>><<<<>>>><<<>>>><><>>><>>><<<<><>><<>>>><>>>><<>>>><<<<><>>>><<<>>>><<<<>>>><>><<<<><<<<>><<<>><<>>><<><<>>><<>><>>>><><<<>>>><<<<><<<>><<<<><<><>>><<>>>><<><<<<>><><<<>>><<<<>>><<<<><<<<>><>>>><<><<<>>><<>><<<<>>>><>>>><>>>><>><<<<><<<>>>><<<>><<<>>>><>>>><<<<>>>><<<>>>><<><<><<>><<><<<>>><<<<>><>>><<><<<<>><<<<>>>><<<<>>><<>>>><>><<<<>><><<<<>><<>><<<<>>>><<>>>><<<<>><>>><<<>><<><>>><<>><<<><<<<>>><>>>><<>><<>>><<>><<><<>>><<<<><<>>>><<>>>><<>><>>>><<>><>><>><<<<>>>><>>>><<<>>>><<<<>>>><<><<>>><><<>>><>>><><<<>><<<<>>><<<><<<<>>>><<<>>>><><>>><<<><<<>>><<<<><<<<>>><<>><<>><><<>>><<<><<<<>><>><<><<<>>><<>>><<>>>><>><>>><<<>><>>>><<<<><<<<>>>><><>>><>><><<<>>>><<<<>><<>><><>>><<<><<><<>>>><<<>>><>>>><<<<>>>><>><<<<><>>>><>>>><<<>>><<><<>>>><<>>><<<>>><<<>>><><<<>><<<<>>>><<>>>><<<<>>><<<>>><<<<><<>><>>>><>>>><<><<<<>><<<<>>><<<<>>><>>><><<>><<<><<<><<<>><<>>>><>><>>><><<<><<><>>>><<<<><<<>>>><><<><>>><<<<>>><<<>><<<<>>><<>>>><>>><>><<>><<<<>><<><<>><>>>><<>>><<<>><><<>>>><<>>><<>><<>><<<>>><<<>>>><<<<><<<<>>><<<>><>>><<<>><<<>>><<<>>>><<<<>><<<<>>><<><<<<>>><><<>>>><<<><<<<>>><<<<>>><<<>>>><<><<<<>>>><>>><<><<<<>>><>>>><<<<>>><><<<>>><>>><<>>>><<<>>><<<<>><<<<>><<>>><<<<>><>>>><<<<>>>><<<<>>><>><<>>>><<<<>>>><<<<>><<<>>><<<>>><>>><>>>><>><><>><<><<><><<>><>>><<<><<<>><<<>><<<>>><>><<>>>><<>><<<>>>><><<<><<>><<<<><<<><<>>>><>><<><<>><<>>><<<><>>><<<>>>><<<<>><<>>>><<<>>>><><>>><><<<<><<>>><>><<<><<<>>>><><>>>><>>>><<<<>>><><<<>><<<>>><<>>><<<><<<<>><<>>>><<<>>>><<>><<><<<>>>><<>>><<<>><><<><<<<>>><><>>>><<>><><<<<>>>><>>>><<<<><<>>>><<>>>><<<<><>><<<>>>><<<<><<<<>>><<<>><<<<><<<>>><>>>><<<<>>><<<>>><<>>><<>><<<><<<>>><<<>>>><<<><<<<>>><<<>><>>>><>><<<<>>>><><<<>><<>>>><<<<>>><><>><<>><>>><<<>>><>>>><<<<><><<<<>><<>>>><<<<>>><<><<<<>>><<<>>>><<<<><>>><>><><<>><<<><>>><<<><><<>><<<>><<<<><<<>>>><><><<<<><<<>>>><>>>><<>>><<>>><<<>><<>>><<<><<>>>><><<><><>>><<<>><<<<><<<><<>><<><<<>>>><<>>>><<><>>>><<>>><<<<><<<<><<<<>><<<<>>>><<><<<><>>><<<<>>><<<>><<<<>>>><<<>>>><<<>><<><><><><<><<<<><<<>><<<>><<<>><>><<<<>><<>>><<><<>>><<<><<<<>><<<>>>><<>>>><>>><<><>><<<<>>><>><<<>>><<<><<>>>><<<<>>><<<<>>><<<<>>><>>><>>><>><<>>>><<<><<<><<<>><<<>><<<>><<<>>><>>><<>>><<<<><>>><<<<><<<>>><<<>>>><<<<>>><<>><>>><>>><>><<<<>>><<<<><><<<><<>><<<>>>><<<>>><<><>>><<>><>>><<<>>>><<<>>>><<<><>>>><<><<><<<<>>><<<<><<><<>>>><<<>><<<<>>>><<<<>>>><><<<<>><<>>><<<<>>>><<>>><<<>>><>>><>>>><<<>><><<>>><<<>>><<><<<><<<<><<<<><>><<>>><<<<>>>><<<><<><<<<>>>><<<>><<<<><<>><<<><<<>><<<>>>><<<<>>><<<>><<<<><<<>>><<<<>><<>>>><<<>><<><<<<><<<>><>>><>>><<>>>><<<<><<<><<<<>><<<<>>>><><>>><<>>>><<>>><>><<>>><<<>>>><<<>><>>><<>><<><<<>>><<<><<<>>>><<>>>><<<<>>><<>>>><<<>>>><<><>>><<>>><<>>><<<>>><><<><<<<>><<>><><<<>>>><<<>>><<<><><<<<><<<<><<>>>><>>><>>><<<>>><<>>><<<<>>>><<<><<><<<<><<<><<<<>>><>>>><>>>><<<>>><<<<>>>><<<>><<>><<>>><<>><><<>>><<<>>><<>><<<<>><<<>>><<>><<<<>><>><><>>><><<<<>>>><<>>>><<<>><><<<<>><<<<><<<>><<<<>><><<<><<>><<<>>>><>><<<>>><><<<<>><<>><<>>>><<>><<<<>><<<<>><<>><<<<><<<<>>><<<><<<<>>>><<><>><<<<><>>><<<<><<><<<<>><>><<><<<>>>><<<<>>>><<<<><<>>>><<<<><<<><<>><>><<<>>>><>><<>>><<<<><<>>><<><<<<>><<><<<>><>><<<>>>><<<<><<<<>><>><<<>><<<>>><<>>><<<<>>><<>>><<<<><<<<>><<<<>>><<<>><><<<><>><<<<><<<<>><<<<><<<>>>><<><<><>>><<<<>><<<<>>>><>>><>><<>><<>><<<<>><>>>><<<<>>>><<<>>>><<>><><<<<>>><<<<>>>><<<>>><<><>>><<<<>>>><<<<>>>><<><>>>><<<<><<<><<<<>>><<<<><<<>>>><<<<>><<<>>><<<>>>><<><<><>>>><>>>><<<<>><>><<>>><<<><><<>>><<<>><<>>><<<><<<>>><<>>><<>>>><<<><>>>><><<<>>><>><<<>><<><<<>>><>>><<<<>>>><<<>>><>>><<>><<<>>><>><<>><>>>><<<<><<<>>>><><<<<><<<<><<<<><<>>>><<>>>><<>><<<<>><<<>>><<><<<>>>><<<<>>>><<<>>>><<<><<<>>>><<>>>><<<<>><>><<>>>><>>>><<<>><<<>><>>>><<<>>><>><>>>><>><<<<>><<>>><>><<>>><<<<>><><<<>><<<<>>><>>>><<<<>>><<<><<<>><<><<>>>><>>><<<><<>><<<><<>>>><><<<<>><<<>>><<>>><>>>><>>><>>>><<<><>><<<>>>><>>><<<>>><<><<>><<<<><<><>><<<>>><<<>>><<<>>>><<<><<<<>>><<<<><<<><<<>>>><<>>><>>>><<<>><<>>>><<><<<<><<<<>><<>>><<><<>><<><>>>><>><<<<>>><<<<>>>><<<><<<<>>>><>>>><<<><<>><<>>><<<<>><<>><<>>>><>>><>>><<>><>>><<>><<<<>>><><<>>><<<<>><<<>>><<<>><><<<<>><<<<>>><<<>><<<>>><>>>><<<>>>><<>>><>><>><<<<>>>><<<>>>><<>><<<<>>><<<<>>><><>><<><>>>><<<<>><<>>><>>>><<<><<<<>>>><>>><<<<>>>><<><<<<>>><<<<>>><<<<>>>><><<>><<>><<<>><<><<<>>>><<<>>>><<>><<<<>><>><<<>>>><<<<><<<>>>><<<>>><<<<>>>><<>>>><<<><<<<>>>><><>><<>>><<<<><><<>>>><<<>>>><<<><<<<>><<<<>>><<<><<<>><<><<<>>>><<>>><>><>><<>>>><><<><<<<>>><<>>>><<<<>>><<<<><><<<><<<>>><<><<>>>><<<>>><<<>><<>>>><<<<>>>><>><<>>><<>>>><<<><<>>>><<<>>>><<<<>>>><<<<><<<<><<<><<<<>>>><<>>><<>>><<>><<><<>>><<<>>>><>><<<><<>>>><<>><<><<<>>>><>><>>>><<>>>><><>><<<<><<<<>>><<<><<>><<>>><<<<>>>><>>>><<><<<>>><<<>>>><<>>><<>><<>";
    }


}
